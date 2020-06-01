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
    public partial class DeviceManagement_MachineInfo_Setting_AccessControls : Form
    {
        Tool tool = new Tool();
        CommunicationBase cb = new CommunicationBase();
        public DeviceManagement_MachineInfo_Setting_AccessControls()
        {
            InitializeComponent();
        }
        string ip = "";
        string ipp = "";
        string ip_locationInfo = "";
        public void Setting(string Oip)
        {
            string settingPath = Application.StartupPath + "\\DeviceInfo_Setting";
            ip = Oip;
           
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
            Thread thSetting = new Thread(new ThreadStart(ThSetting));
            thSetting.Start();
            if (File.Exists(settingPath))
            {
                panelContainer.Enabled = false;
                ip_locationInfo = tool.ReadIPandLocation(ipp);
                comboBoxLocation.Text = ip_locationInfo.Split('_')[1];
            }
        }
        string recordTime = "";
        string timeout = "";
        string relock = "";
        bool buzzer = false;
        string GDOActive = "";
        private void ThSetting()
        {
            // Read Record Time.
            byte[] recordTimeSendMsg = new byte[] { 0xF8, 0xFA, 0x00, 0x07, 0x00, 0x07, 0x52, 0x65, 0x61, 0x64, 0x01, 0x2B, 0x26 };
            string recordTimeReciveMsg = cb.Connection(recordTimeSendMsg, ip);
            recordTimeReciveMsg = recordTimeReciveMsg.Replace(" ", "");
            int recordTimeData = Convert.ToInt32(recordTimeReciveMsg.Substring(12, 2), 16);
            int recordTimeStatus = Convert.ToInt32(recordTimeReciveMsg.Substring(14, 2), 16);
            
            // Read Timeout Time
            byte[] timeoutSendMsg = new byte[] { 0xF8, 0xFA, 0x00, 0x07, 0x00, 0x07, 0x52, 0x65, 0x61, 0x64, 0x07, 0x4B, 0xE0 };
            string timeoutReciveMsg = cb.Connection(timeoutSendMsg, ip);
            timeoutReciveMsg = timeoutReciveMsg.Replace(" ", "");
            int timeoutData = Convert.ToInt32(timeoutReciveMsg.Substring(12, 4), 16);
            int timeouStatus = Convert.ToInt32(timeoutReciveMsg.Substring(16, 2), 16);
            
            // Read Relock Time
            byte[] relockSendMsg = new byte[] { 0xF8, 0xFA, 0x00, 0x07, 0x00, 0x07, 0x52, 0x65, 0x61, 0x64, 0x02, 0x1B, 0x45 };
            string relockReciveMsg = cb.Connection(relockSendMsg, ip);
            relockReciveMsg = relockReciveMsg.Replace(" ", "");
            int relockData = Convert.ToInt32(relockReciveMsg.Substring(12, 4), 16);
            int relockStatus = Convert.ToInt32(relockReciveMsg.Substring(16, 2), 16);

            // Read En Buzzer
            byte[] buzzerSendMsg = new byte[] { 0xF8, 0xFA, 0x00, 0x07, 0x00, 0x07, 0x52, 0x65, 0x61, 0x64, 0x04, 0x7B, 0x83 };
            string buzzerReciveMsg = cb.Connection(buzzerSendMsg, ip);
            buzzerReciveMsg = buzzerReciveMsg.Replace(" ", "");
            int buzzerData = Convert.ToInt32(buzzerReciveMsg.Substring(12, 2), 16);
            int buzzerStatus = Convert.ToInt32(buzzerReciveMsg.Substring(14, 2), 16);

            // Read DO Mode
            byte[] doSendMsg = new byte[] { 0xF8, 0xFA, 0x00, 0x07, 0x00, 0x07, 0x52, 0x65, 0x61, 0x64, 0x06, 0x5B, 0xC1 };
            string doReciveMsg = cb.Connection(doSendMsg, ip);
            doReciveMsg = doReciveMsg.Replace(" ", "");
            string doData = doReciveMsg.Substring(12, 8);
            int doStatus = Convert.ToInt32(doReciveMsg.Substring(20, 2), 16);
            string DOActive = "";
            //if (doData.Equals("01010101"))
            //{
            //    DOActive = "開門";
            //}
            //else if (doData.Equals("03010101"))
            //{
            //    DOActive = "逾時";
            //}

            // Show
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    if (recordTimeStatus == 1)
                    {
                        comboBoxSameCardIRecord.Text = recordTimeData.ToString();
                        recordTime = recordTimeData.ToString();
                    }
                    if (timeouStatus == 1)
                    {
                        textBoxITimeout.Text = timeoutData.ToString();
                        timeout = timeoutData.ToString();
                    }
                    if (relockStatus == 1)
                    {
                        textBoxDoorTime.Text = relockData.ToString();
                        relock = relockData.ToString();
                    }
                    if (buzzerStatus == 1)
                    {
                        if (buzzerData == 1)
                        {
                            checkBoxBuzzer.Checked = true;
                            buzzer = checkBoxBuzzer.Checked;
                        }
                        else
                        {
                            checkBoxBuzzer.Checked = false;
                            buzzer = checkBoxBuzzer.Checked;
                        }
                    }
                    if (doStatus == 1)
                    {
                        comboBoxDO.Text = DOActive;
                        GDOActive = DOActive;
                    }
                    panelContainer.Enabled = true;
                    labelLoading.Text = "就緒";
                    labelLoading.ForeColor = Color.Black;
                });
            }
            catch { }
        }
        private List<bool> isModifyFinish = new List<bool>();
        private void buttonModify_Click(object sender, EventArgs e)
        {
            if (!comboBoxSameCardIRecord.Text.Equals(recordTime))
            {
                Thread thSetting = new Thread(new ParameterizedThreadStart(ThModify));
                thSetting.Start("F8FA000400095265636F7264*" + comboBoxSameCardIRecord.Text + "*" + isModifyFinish.Count + "*12");
                isModifyFinish.Add(false);
                recordTime = comboBoxSameCardIRecord.Text;
            }
            if (!textBoxITimeout.Text.Equals(timeout))
            {
                //Thread thSetting = new Thread(new ParameterizedThreadStart(ThModify));
                //thSetting.Start("F8FA000500085365740200*" + textBoxITimeout.Text + "*" + isModifyFinish.Count + "*12");
                //isModifyFinish.Add(false);
            }
            if (!textBoxDoorTime.Text.Equals(relock))
            {
                Thread thSetting = new Thread(new ParameterizedThreadStart(ThModify));
                thSetting.Start("F8FA0005000A52656C6F636B00*" + textBoxDoorTime.Text + "*" + isModifyFinish.Count + "*12");
                isModifyFinish.Add(false);
                relock=textBoxDoorTime.Text ;
            }
            if(!checkBoxBuzzer.Checked == buzzer)
            {
                string msg = "";
                if(checkBoxBuzzer.Checked)
                {
                    msg = "01";
                }
                else
                {
                    msg = "00";
                }
                Thread thSetting = new Thread(new ParameterizedThreadStart(ThModify));
                thSetting.Start("F8FA00050009456E6F70627A*" + msg + "*" + isModifyFinish.Count + "*12");
                isModifyFinish.Add(false);
                buzzer = checkBoxBuzzer.Checked;
            }
            //if (!comboBoxDO.Text.Equals(GDOActive))
            //{
            //    string thMsg = "";
            //    if(comboBoxDO.Text.Equals("開門"))
            //    {
            //        thMsg = "01010101";
            //    }
            //    else if (comboBoxDO.Text.Equals("逾時"))
            //    {
            //        thMsg = "03010101";
            //    }
            //    Thread thSetting = new Thread(new ParameterizedThreadStart(ThModify));
            //    thSetting.Start("F8FA0005000A53657400*" + thMsg + "*" + isModifyFinish.Count + "*12");
            //    isModifyFinish.Add(false);
            //}
            string msg1 = "未修改任何資訊";
            if (!comboBoxLocation.Text.Equals(ip_locationInfo.Split('_')[1]))
            {
                tool.WriteIPandLocation(ipp, comboBoxLocation.Text);
                msg1 = "地點已修改";
            }
            if (isModifyFinish.Count > 0)
            {
                panelContainer.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                Thread thWaitModifyg = new Thread(new ThreadStart(WaitModify));
                thWaitModifyg.Start();
            }
            else
            {
                panelContainer.Enabled = true;
                MessageBox.Show(msg1, "提醒");
                if(msg1.Equals("地點已修改"))
                {
                    this.ParentForm.Dispose();
                }
            }
        }
        private void WaitModify()
        {
            string msg = "";
            bool isFinish = false;
            int count = 0;
            while (!isFinish)
            {
                count++;
                if (count >= 5)
                {
                    msg = "失敗";
                    isFinish = true;
                }
                else
                {
                    isFinish = true;
                    for (int i = 0; i < isModifyFinish.Count; i++)
                    {
                        if (isModifyFinish[i].Equals(false))
                        {
                            isFinish = false;
                            msg = "修改完成";
                            break;
                        }
                    }
                }
                Thread.Sleep(1000);
            }
            this.Invoke((MethodInvoker)delegate
            {
                panelContainer.Enabled = true;
                this.Cursor = Cursors.Arrow;
            });
            isModifyFinish.Clear();
            MessageBox.Show(msg,"提醒");
        }
        private void ThModify(object sender)
        {
            
            string thRecordTime_index = (string)sender;
            string head = thRecordTime_index.Split('*')[0];
            string thRecordTime = thRecordTime_index.Split('*')[1].PadLeft(2,'0');
            int index =int.Parse(thRecordTime_index.Split('*')[2]);
            int statusPosition = int.Parse(thRecordTime_index.Split('*')[3]);
            string recordTimeHex = "";
            if(head.Equals("F8FA0005000A52656C6F636B00"))
            {
                Thread.Sleep(500);
            }
            for (int i = 0; i < thRecordTime.Length; i += 2)
            {
                recordTimeHex += int.Parse(thRecordTime.Substring(i, 2)).ToString("X2").PadLeft(2, '0');
            }
            recordTimeHex = head + recordTimeHex;
            byte[] CrcByte = new byte[recordTimeHex.Length / 2];
            for (int i = 0; i < recordTimeHex.Length; i += 2)
            {
                CrcByte[i / 2] = Convert.ToByte(recordTimeHex.Substring(i, 2), 16);
            }
            ushort CRC = cb.CRC16CCITT(CrcByte);
            string CRCInt = CRC.ToString("X2").PadLeft(4, '0');
            string sendMsg = recordTimeHex + CRCInt;
            byte[] sendMsgByte = new byte[sendMsg.Length / 2];
            for (int i = 0; i < sendMsg.Length; i += 2)
            {
                sendMsgByte[i / 2] = Convert.ToByte(sendMsg.Substring(i, 2), 16);
            }
            string reciveMsg = cb.Connection(sendMsgByte, ip);
            reciveMsg = reciveMsg.Replace(" ", "");
            string status = reciveMsg.Substring(statusPosition, 2);
            if (status.Equals("01"))
            {
                isModifyFinish[index] = true;
            }
            string[] ipArray = ip.Split('.');
            string ipSettingPath = Application.StartupPath + "\\DeviceInfo_Setting\\" + ipArray[0].PadLeft(3, '0') + "." + ipArray[1].PadLeft(3, '0') + "." + ipArray[2].PadLeft(3, '0') + "." + ipArray[3].PadLeft(3, '0') + ".ini";
            StreamWriter sw1 = new StreamWriter(ipSettingPath);
            sw1.WriteLine(thRecordTime);
            sw1.Dispose();
        }
    }
}
