using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCP_Socket.Usercontrol_Form
{
    public partial class DeviceManagement_MachineInfo_Setting_ModifyIP_M_G : Form
    {
        private Tool tool = new Tool();
        private CommunicationBase cb = new CommunicationBase();
        private string ipSettingPath = Application.StartupPath + "\\DeviceInfo_Setting" + "\\Device.ini";
        private string ip = "";
        public DeviceManagement_MachineInfo_Setting_ModifyIP_M_G()
        {
            InitializeComponent();
        }
        private List<string> mNList = new List<string>();
        public void SetmNList(List<string> OmNList)
        {
            mNList = OmNList;
        }
        public void Setting(string mN, string ip, string gateway, string mask)
        {
            labelIP.Text = "IpAddress：" + ip;
            textBoxmN.Text = mN;
            string[] ipArray = ip.Split('.');
            string[] gatewayArray = gateway.Split('.');
            string[] maskArray = mask.Split('.');
            string[] searchName = { "textBox1", "textBox2", "textBox3", "textBox4" };
            List<IpTextbox> controlName = new List<IpTextbox>();
            controlName.Add(ipTextboxIP);
            controlName.Add(ipTextboxGateway);
            controlName.Add(ipTextboxMask);

            for (int i = 0; i < controlName.Count; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Control[] controls = controlName[i].Controls.Find(searchName[j], true);
                    if (i == 0)
                    {
                        controls[0].Text = ipArray[j];
                    }
                    else if (i == 1)
                    {
                        controls[0].Text = gatewayArray[j];
                    }
                    else if (i == 2)
                    {
                        controls[0].Text = maskArray[j];
                    }
                }
            }
        }
        private string mN_Ip_Mask_Gateway = "";
        private void CollectionSettingInfo()
        {
            mN_Ip_Mask_Gateway = "";
            string[] controlName = { "ipTextboxIP", "ipTextboxMask", "ipTextboxGateway" };
            mN_Ip_Mask_Gateway += textBoxmN.Text + "|";
            for (int i = 0; i < 3; i++)
            {
                Control[] control = panelDown.Controls.Find(controlName[i], true);
                IpTextbox ipTextbox = (IpTextbox)control[0];
                string[] searchName = { "textBox1", "textBox2", "textBox3", "textBox4" };
                for (int j = 0; j < 4; j++)
                {
                    Control[] control1 = ipTextbox.Controls.Find(searchName[j], true);
                    if (j != 3)
                    {
                        mN_Ip_Mask_Gateway += control1[0].Text + ".";
                    }
                    else
                    {
                        mN_Ip_Mask_Gateway += control1[0].Text;
                    }
                }
                mN_Ip_Mask_Gateway += "|";
            }
        }
        private Byte[] IP_Mask_Gateway_ToHex()
        {
            string returnString = "";
            string mN = mN_Ip_Mask_Gateway.Split('|')[0];
            string ip = mN_Ip_Mask_Gateway.Split('|')[1];
            string mask = mN_Ip_Mask_Gateway.Split('|')[2];
            string gateway = mN_Ip_Mask_Gateway.Split('|')[3];

            string[] ipArray = ip.Split('.');
            string[] maskArray = mask.Split('.');
            string[] gatewayArray = gateway.Split('.');

            for (int i = 0; i < ipArray.Length; i++)
            {
                string hex = Convert.ToString(Int32.Parse(ipArray[i]), 16).ToUpper();
                if (hex.Length < 2)
                {
                    returnString += "0" + hex;
                }
                else
                {
                    returnString += hex;
                }
            }
            for (int i = 0; i < maskArray.Length; i++)
            {
                string hex = Convert.ToString(Int32.Parse(maskArray[i]), 16).ToUpper();
                if (hex.Length < 2)
                {
                    returnString += "0" + hex;
                }
                else
                {
                    returnString += hex;
                }

            }
            for (int i = 0; i < gatewayArray.Length; i++)
            {
                string hex = Convert.ToString(Int32.Parse(gatewayArray[i]), 16).ToUpper();
                if (hex.Length < 2)
                {
                    returnString += "0" + hex;
                }
                else
                {
                    returnString += hex;
                }
            }
            returnString = "F8FA0001000F00" + returnString;
            Byte[] crcByte = new byte[returnString.Length / 2];
            for (int i = 0; i < returnString.Length; i = i + 2)
            {
                crcByte[i / 2] = Convert.ToByte(returnString.Substring(i, 2), 16);
            }
            Byte[] sendMessage = new byte[] { 0xF8, 0xFA, 0x00, 0x01, 0x00, 0x0F, 0x00, 0xC0, 0xA8, 0x01, 0x03, 0xFF, 0xFF, 0x00, 0x00, 0xC0, 0xA8, 0x01, 0xFE };

            CommunicationBase cb = new CommunicationBase();
            ushort crc = cb.CRC16CCITT(crcByte);

            string crcString = crc.ToString("X2");
            if (crc < 1000)
            {
                crcString = "0" + crc.ToString();
            }
            returnString = returnString + crcString;
            Byte[] returnByte = new byte[returnString.Length / 2];
            for (int i = 0; i < returnString.Length; i = i + 2)
            {
                returnByte[i / 2] = Convert.ToByte(returnString.Substring(i, 2), 16);
            }
            return returnByte;
        }
        private Byte[] mN_ToHex(string SmN)
        {
            int mN = int.Parse(SmN);
            string mNHex = Convert.ToString(mN, 16);
            string returnString = "";
            string mNSendMessage = "F8FA0006000A4E756D626572" + mNHex.PadLeft(4, '0').ToUpper();
            Byte[] crcByte = new byte[mNSendMessage.Length / 2];
            for (int i = 0; i < mNSendMessage.Length; i = i + 2)
            {
                crcByte[i / 2] = Convert.ToByte(mNSendMessage.Substring(i, 2), 16);
            }
            CommunicationBase cb = new CommunicationBase();
            ushort crc = cb.CRC16CCITT(crcByte);
            string crcString = crc.ToString("X2");
            if (crc < 1000)
            {
                crcString = "0" + crc.ToString();
            }
            returnString = mNSendMessage + crcString;
            Byte[] returnByte = new byte[returnString.Length / 2];
            // string to byte.
            for (int i = 0; i < returnString.Length; i = i + 2)
            {
                returnByte[i / 2] = Convert.ToByte(returnString.Substring(i, 2), 16);
            }
            return returnByte;
        }
        private string settingPath = Application.StartupPath + "\\DeviceInfo_Setting";
        string ipp = "";
        private void Modify()
        {
            CollectionSettingInfo();
            ip = labelIP.Text.Split('：')[1];
            string[] ippArray = ip.Split('.');
            for (int i = 0; i < ippArray.Length; i++)
            {
                if (i == ippArray.Length - 1)
                {
                    ipp += ippArray[i].PadLeft(3, '0');
                }
                else
                {
                    ipp += ippArray[i].PadLeft(3, '0') + ".";
                }
            }
            settingPath += "\\" + ipp + "Location.ini";

            if (File.Exists(settingPath))
            {
                string backString = tool.ReadIPandLocation(ipp);
                File.Delete(settingPath);
                string modifyIP = mN_Ip_Mask_Gateway.Split('|')[1];
                string[] mArray = modifyIP.Split('.');
                ipp = "";
                for (int i = 0; i < mArray.Length; i++)
                {
                    if (i == mArray.Length - 1)
                    {
                        ipp += mArray[i].PadLeft(3, '0');
                    }
                    else
                    {
                        ipp += mArray[i].PadLeft(3, '0') + ".";
                    }
                }
                tool.WriteIPandLocation(ipp, backString.Split('_')[1]);
            }
            // Stop RF.
            Byte[] sandStopMsgByte = new Byte[] { 0xFA };
            string reciveMsgForStopRF = cb.Connection(sandStopMsgByte, labelIP.Text.Split('：')[1]);
            // Search ip.
            //StreamReader sr = new StreamReader(ipSettingPath);
            //ip = sr.ReadLine();
            //ip = sr.ReadLine();
            //sr.Dispose();
            Thread.Sleep(300);
            //---------//
            // Set machine number.
            Byte[] mNModifySendMessage = mN_ToHex(textBoxmN.Text);
            string mNReciveMessage = cb.Connection(mNModifySendMessage, ip);
            mNReciveMessage = mNReciveMessage.Replace(" ", "");
            string mNStatus = mNReciveMessage.Substring(12, 2);
            string mwssageText = "";
            Thread.Sleep(300);
            // Set ip,mask,gateway
            Byte[] ipModifySendMessage = IP_Mask_Gateway_ToHex();
            string ipReciveMessage = cb.Connection(ipModifySendMessage, ip);
            ipReciveMessage = ipReciveMessage.Replace(" ", "");
            string ipStatus = ipReciveMessage.Substring(12, 2);
            if (ipStatus.Equals("01") && mNStatus.Equals("01"))
            {
                mwssageText = "修改成功";
            }
            else 
            {
                mwssageText += "(IP、遮罩、閘道)修改失敗";
            }
            MessageBox.Show(mwssageText, "提醒");
            this.Invoke((MethodInvoker)delegate
            {
                this.Cursor = Cursors.Arrow;
                panelDown.Enabled = true;
                buttonModify.Text = "修改";
                this.ParentForm.Dispose();
            });
            settingPath += "\\" + ip + "Location.ini";
        }
        private void buttonModify_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            panelDown.Enabled = false;
            Thread thModifyIp = new Thread(new ThreadStart(Modify));
            thModifyIp.Start();
        }

        private void textBoxmN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 | (int)e.KeyChar > 57) & (int)e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBoxmN_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(textBoxmN.Text) > 255)
            {
                textBoxmN.Text = "255";
            }
        }
    }
}
