using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCP_Socket.FormsChild
{
    public partial class UserManagement_UserInfo : Form
    {
        private string ipSettingPath = Application.StartupPath + "\\DeviceInfo_Setting" + "\\Device.ini";
        public UserManagement_UserInfo()
        {
            InitializeComponent();
        }
        private int whileCount = 1;
        private void ReadUserInfo(object Oip_mN)
        {
            string ip_mN = (string)Oip_mN;
            string[] ip_mNArray = ip_mN.Split('@');
            //取得Reader同卡間隔內不重複的Tag資料
            Byte[] _SensorData = new Byte[] { 0xF8, 0xFA, 0x00, 0x00, 0x00, 0x02, 0xCB, 0x54 };

            while (toRead)
            {
                CommunicationBase cb = new CommunicationBase();
                string reciveText = cb.Connection(_SensorData, ip_mNArray[0]);
                if (reciveText.Length > 3)
                {
                    WriteLog("◆卡號：" + cb.GetCardNumber(reciveText) + "      ◆時間：" + cb.GetTime(reciveText) + "      ◆機碼：" + ip_mNArray[1]);
                }
            }
        }
        private bool toRead = false;
        private void buttonStart_Click(object sender, EventArgs e)
        {
            List<string> ipList = new List<string>();
            List<string> mNList = new List<string>();
            StreamReader sr = new StreamReader(ipSettingPath);
            int count = 1;
            int ipCount = 2;
            int mNCount = 1;
            string ip = "";
            while (!sr.EndOfStream)
            {
                ip = sr.ReadLine();
                if(count == ipCount)
                {
                    ipList.Add(ip);
                    ipCount += 5;
                }
                if (count == mNCount)
                {
                    mNList.Add(ip);
                    mNCount += 5;
                }
                count++;
            }
            sr.Dispose();
            toRead = true;
            buttonStop.Enabled = true;
            buttonStart.Enabled = false;
            for (int i = 0; i < ipList.Count; i++)
            {
                Thread thStartRead = new Thread(new ParameterizedThreadStart(ReadUserInfo));
                thStartRead.Name = "thStartRead(" + ipList[i] + ")";
                thStartRead.Start(ipList[i] + "@" + mNList[i]);
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
            toRead = false;
        }
        private void WriteLog(string text)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    textBoxLog.Text += text + "\r\n";
                });
            }
            catch { }
        }

        private void buttonDeleteIntime_Click(object sender, EventArgs e)
        {
            textBoxLog.Text = "";
        }
    }
}
