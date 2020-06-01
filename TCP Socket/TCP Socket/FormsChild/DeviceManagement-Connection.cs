using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace TCP_Socket.FormsChild
{
    public partial class DeviceManagement_Connection : Form
    {
        private string ipSettingPath = Application.StartupPath + "\\DeviceInfo_Setting" + "\\Device.ini";
        private string settingFolderPath = Application.StartupPath + "\\DeviceInfo_Setting";

        public DeviceManagement_Connection()
        {
            InitializeComponent();
        }
        private void buttonSearchIP_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(settingFolderPath))
            {
                Directory.CreateDirectory(settingFolderPath);
            }
            if (File.Exists(ipSettingPath))
            {
                File.Delete(ipSettingPath);
            }
            panelContainer.Controls.Clear();
            MachineInfo machineInfo = new MachineInfo();
            string receiveMsg = machineInfo.MachineInfoEtc();
            string[] mashineArray = receiveMsg.Split('@');
            for (int i = 0; i < mashineArray.Length; i++)
            {
                Usercontrols.DeviceManagement_MachineInfo deviceManagement_MachineInfo = new Usercontrols.DeviceManagement_MachineInfo();
                deviceManagement_MachineInfo.Setting(machineInfo.MachineNumber(mashineArray[i]), 
                    machineInfo.MachineIP(mashineArray[i]), 
                    machineInfo.MachineDefaultGateway(mashineArray[i]),
                    machineInfo.MachineNetworkMask(mashineArray[i]), 
                    machineInfo.MachineMac(mashineArray[i]));
                deviceManagement_MachineInfo.Dock = DockStyle.Top;
                panelContainer.Controls.Add(deviceManagement_MachineInfo);
            }
        }

        private void buttonSchoolTime_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("即將開始校正時間。", "注意", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation).Equals(DialogResult.Yes))
            {
                Thread thSchoolTime = new Thread(new ThreadStart(SchoolTime));
                thSchoolTime.Start();
                MessageBox.Show("校正時間成功。", "提醒");
            }
        }
        private void SchoolTime()
        {
            CommunicationBase cb = new CommunicationBase();
            string week = "";
            if (DateTime.Now.DayOfWeek.ToString().Equals("Monday"))
            {
                week = "01";
            }
            else if (DateTime.Now.DayOfWeek.ToString().Equals("Tuesday"))
            {
                week = "02";
            }
            else if (DateTime.Now.DayOfWeek.ToString().Equals("Wednesday"))
            {
                week = "03";
            }
            else if (DateTime.Now.DayOfWeek.ToString().Equals("Thursday"))
            {
                week = "04";
            }
            else if (DateTime.Now.DayOfWeek.ToString().Equals("Friday"))
            {
                week = "05";
            }
            else if (DateTime.Now.DayOfWeek.ToString().Equals("Satursday"))
            {
                week = "06";
            }
            else if (DateTime.Now.DayOfWeek.ToString().Equals("Sunday"))
            {
                week = "07";
            }
            string date = DateTime.Now.ToString("yyyy MM dd " + week + " HH mm ss");
            //date = "2017 04 11 02 16 13 00";
            string[] dateArray = date.Split(' ');
            string dateHex = "";
            for (int i = 0; i < dateArray.Length; i++)
            {
                if (i == 0)
                {
                    for (int j = 0; j < dateArray[i].Length; j += 2)
                    {
                        dateHex += int.Parse(dateArray[i].Substring(j, 2)).ToString("X2").PadLeft(2, '0');
                    }
                }
                else
                {
                    dateHex += int.Parse(dateArray[i]).ToString("X2").PadLeft(2, '0');
                }
            }
            //for (int i = 0; i < dateArray.Length; i++)
            //{
            //    string temp = "";
            //    temp= int.Parse(dateArray[i]).ToString("X2");
            //    if (temp.Length == 3)
            //    {
            //        temp = temp.PadLeft(4, '0');
            //    }
            //    else
            //    {
            //        temp = temp.PadLeft(2, '0');
            //    }
            //    dateHex += temp;
            //}
            string beforeCRCMsg = "F8FC0000000A" + dateHex;
            byte[] CRCByte = new byte[beforeCRCMsg.Length / 2];
            for (int i = 0; i < beforeCRCMsg.Length; i += 2)
            {
                CRCByte[i / 2] = Convert.ToByte(beforeCRCMsg.Substring(i, 2), 16);
            }
            ushort CRC = cb.CRC16CCITT(CRCByte);
            string afterCRCMsg = CRC.ToString("X2");
            string sendMsg = /*"f8fc0000000a14140306050f2e2336a6"*/ beforeCRCMsg + afterCRCMsg.PadLeft(4, '0');
            byte[] sendMsgByte = new byte[sendMsg.Length / 2];
            for (int i = 0; i < sendMsg.Length; i += 2)
            {
                sendMsgByte[i / 2] = Convert.ToByte(sendMsg.Substring(i, 2), 16);
            }
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 50001);
            UdpClient uc = new UdpClient();
            uc.Send(sendMsgByte, sendMsgByte.Length, ipep);
            byte[] receiveBytes = uc.Receive(ref ipep);
            uc.Dispose();
        }
    }
}
