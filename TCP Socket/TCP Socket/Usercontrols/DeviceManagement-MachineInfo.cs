using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace TCP_Socket.Usercontrols
{
    public partial class DeviceManagement_MachineInfo : UserControl
    {
        private string ipSettingPath = Application.StartupPath + "\\DeviceInfo_Setting" + "\\Device.ini";
        public DeviceManagement_MachineInfo()
        {
            InitializeComponent();
        }
        string GmN = "";
        string Gip = "";
        string GgateWay = "";
        string Gmask = "";
        string Gmac = "";
        public void Setting(string mN, string ip, string gateWay, string mask, string mac)
        {
            if(File.Exists(ipSettingPath))
            {
                File.Delete(ipSettingPath);
            }
            GmN = labelNumber.Text = mN;
            Gip = labelP.Text = ip;
            GgateWay = labelGateWay.Text = gateWay;
            Gmask = labelMask.Text = mask;
            Gmac = labelMac.Text = mac;
            Thread thSetting = new Thread(new ThreadStart(ThSetting));
            thSetting.Start();
        }
        private void ThSetting()
        {
            CommunicationBase cb = new CommunicationBase();
            byte[] relockSendMsg = new byte[] { 0xF8, 0xFA, 0x00, 0x07, 0x00, 0x07, 0x52, 0x65, 0x61, 0x64, 0x02, 0x1B, 0x45 };
            string relockReciveMsg = cb.Connection(relockSendMsg, Gip);
            relockReciveMsg = relockReciveMsg.Replace(" ", "");
            int relockData = Convert.ToInt32(relockReciveMsg.Substring(12, 4), 16);
            StreamWriter sw = new StreamWriter(ipSettingPath, true);
            sw.WriteLine(GmN);
            sw.WriteLine(Gip);
            sw.WriteLine(GgateWay);
            sw.WriteLine(Gmask);
            sw.WriteLine(Gmac);
            sw.Dispose();
            string[] ipArray = Gip.Split('.');
            ipSettingPath = Application.StartupPath + "\\DeviceInfo_Setting\\" + ipArray[0].PadLeft(3, '0') + "." + ipArray[1].PadLeft(3, '0') + "." + ipArray[2].PadLeft(3, '0') + "." + ipArray[3].PadLeft(3, '0') + ".ini";
            StreamWriter sw1 = new StreamWriter(ipSettingPath);
            sw1.WriteLine(relockData);
            sw1.Dispose();

        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            buttonConnect.Text = "開啟中...";
            buttonConnect.ForeColor = Color.Black;
            Thread thConnectionn = new Thread(new ThreadStart(StartConnection));
            thConnectionn.Start();
        }
        private void StartConnection()
        {
            Byte[] sendStopMsgByte = new Byte[] { 0xFA};

            //獲取 EPC/TID 號碼
            Byte[] sandStartMsgByte = new Byte[] { 0xFA, 0xF8, 0x00, 0x05, 0x00, 0x06, 0xFF, 0x1D, 0x01, 0x01, 0xAE, 0x78 };
            CommunicationBase cb = new CommunicationBase();
            string reciveStopMsg = cb.Connection(sendStopMsgByte, labelP.Text);
            Thread.Sleep(50);
            string reciveStartMsg = cb.Connection(sandStartMsgByte, labelP.Text);
            this.Invoke((MethodInvoker)delegate
            {
                buttonConnect.Text = "已開啟";
                buttonConnect.ForeColor = Color.Green;
            });
        }

        private void labelNumber_DoubleClick(object sender, EventArgs e)
        {
            OpenSettingForm();
        }

        private void panel6_DoubleClick(object sender, EventArgs e)
        {
            OpenSettingForm();
        }
        private void OpenSettingForm()
        {
            Usercontrol_Form.DeviceManagement_MachineInfo_Setting dms = new Usercontrol_Form.DeviceManagement_MachineInfo_Setting();
            dms.Setting(labelNumber.Text, labelP.Text, labelGateWay.Text, labelMask.Text);
            dms.Show();

        }
    }
}
