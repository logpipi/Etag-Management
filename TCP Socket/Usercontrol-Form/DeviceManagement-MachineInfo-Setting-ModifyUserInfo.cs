using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCP_Socket.Usercontrol_Form
{
    public partial class DeviceManagement_MachineInfo_Setting_ModifyUserInfo : Form
    {
        private string ipSettingPath = Application.StartupPath + "\\DeviceInfo_Setting" + "\\Device.ini";

        private CommunicationBase cb = new CommunicationBase();

        public DeviceManagement_MachineInfo_Setting_ModifyUserInfo()
        {
            InitializeComponent();
        }
        public void SetIp(string ip)
        {
            labelIp.Text = ip;
        }
        public void ListCount()
        {
            Thread thListCount = new Thread(new ThreadStart(ThListCount));
            thListCount.Start();
        }
        private string nunberCount = "0";
        private void ThListCount()
        {
            string sendMessage = "F8FA00000004230031CA";
            byte[] sendMessageByte = new byte[sendMessage.Length / 2];
            for (int i = 0; i < sendMessage.Length ; i += 2)
            {
                sendMessageByte[i / 2] = Convert.ToByte(sendMessage.Substring(i, 2), 16);
            }
            string reciveMessage = cb.Connection(sendMessageByte, labelIp.Text);
            reciveMessage = reciveMessage.Replace(" ", "");
            string count = reciveMessage.Substring(12, 4);
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    labelListCount.Text = "◆名單總數：";
                    labelListCount.Text += count + "筆";
                });
            }
            catch { }
            nunberCount = count;
        }
        private void ButtonActive(object sender)
        {
            foreach (Control control in panelTop.Controls)
            {
                if (control.GetType() == typeof(Button))
                {
                    Button button1 = (Button)control;
                    button1.BackColor = Color.White;
                }
            }
            Button button = (Button)sender;
            button.BackColor = Color.LightGray;

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            panelDo.Visible = true;
            labelTitle.ForeColor = Color.Green;
            labelTitle.Text = "新增單一名單";
            labelActive.Text = "輸入欲新增卡號：";
            buttonDo.Text = "新增";
            buttonDo.ForeColor = Color.Green;
            ButtonActive(sender);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            panelDo.Visible = true;
            labelTitle.ForeColor = Color.Red;
            labelTitle.Text = "刪除單一名單";
            labelActive.Text = "輸入欲刪除卡號：";
            buttonDo.Text = "刪除";
            buttonDo.ForeColor = Color.Red;
            ButtonActive(sender);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            panelDo.Visible = true;
            labelTitle.ForeColor = Color.Blue;
            labelTitle.Text = "搜尋單一名單";
            labelActive.Text = "輸入欲搜尋卡號：";
            buttonDo.Text = "搜尋";
            buttonDo.ForeColor = Color.Blue;
            ButtonActive(sender);
        }

        private void buttonDo_Click(object sender, EventArgs e)
        {
            panelDo.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            Thread thButtonDo = new Thread(new ThreadStart(ThButtonDo));
            thButtonDo.Start();
        }
        private void ThButtonDo()
        {
            bool isDo = true;
            string cardNumber = textBoxInput.Text;
            if (cardNumber.Length % 2 != 0 || cardNumber == "")
            {
                MessageBox.Show("輸入長度錯誤\r\n必須為偶數", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                // Stop RF.
                Byte[] sandStopMsgByte = new Byte[] { 0xFA };
                string reciveMsgForStopRF = cb.Connection(sandStopMsgByte, labelIp.Text);
                // 新增名單
                if (buttonDo.Text.Equals("新增"))
                {
                    // CRC-3334
                    byte[] CRC3334Byte = new byte[cardNumber.Length / 2];
                    for (int i = 0; i < cardNumber.Length; i += 2)
                    {
                        CRC3334Byte[i / 2] = Convert.ToByte(cardNumber.Substring(i, 2), 16);
                    }
                    ushort CRC3334 = cb.CRC16CCITT(CRC3334Byte);
                    string CRC3334String = CRC3334.ToString("X2");
                    // CRC-3536
                    string beforeCRC3536String = "0001"/*labelListCount.Text.Split('：')[1].Substring(0, 4)*/ + cardNumber +
                        "0000000000000041FFFF" + CRC3334String;
                    byte[] CRC3536Byte = new byte[beforeCRC3536String.Length / 2];
                    for (int i = 0; i < beforeCRC3536String.Length; i += 2)
                    {
                        CRC3536Byte[i / 2] = Convert.ToByte(beforeCRC3536String.Substring(i, 2), 16);
                    }
                    ushort CRC3536 = cb.CRC16CCITT(CRC3536Byte);
                    string afterCRC3536String = CRC3536.ToString("X2").PadLeft(4, '0');
                    // CRC-HeadToEnd
                    string beforeCRCHeadEndString = "F8FA000000242101" + beforeCRC3536String + afterCRC3536String + "00000000";
                    byte[] CRCHeadEndByte = new byte[beforeCRCHeadEndString.Length / 2];
                    for (int i = 0; i < beforeCRCHeadEndString.Length; i += 2)
                    {
                        CRCHeadEndByte[i / 2] = Convert.ToByte(beforeCRCHeadEndString.Substring(i, 2), 16);
                    }
                    ushort CRCHeadEnd = cb.CRC16CCITT(CRCHeadEndByte);
                    string afterCRCHeadEndtring = CRCHeadEnd.ToString("X2");

                    string sendMessage = beforeCRCHeadEndString + afterCRCHeadEndtring;
                    byte[] sendMessageByte = new byte[sendMessage.Length / 2];
                    for (int i = 0; i < sendMessage.Length; i += 2)
                    {
                        sendMessageByte[i / 2] = Convert.ToByte(sendMessage.Substring(i, 2), 16);
                    }
                    string reciveMessage = cb.Connection(sendMessageByte, labelIp.Text);
                    reciveMessage = reciveMessage.Replace(" ", "");
                    string status = reciveMessage.Substring(12, 2);
                    string showMessage = "";
                    string showMessageTitle = "";
                    MessageBoxIcon messageBoxIcon = MessageBoxIcon.Information;
                    if (status.Equals("01"))
                    {
                        messageBoxIcon = MessageBoxIcon.Information;
                        showMessageTitle = "提醒";
                        showMessage = "新增成功";
                        ListCount();
                    }
                    else if (status.Equals("02"))
                    {
                        messageBoxIcon = MessageBoxIcon.Error;
                        showMessageTitle = "錯誤";
                        showMessage = "新增失敗\r\n無法更改。";
                    }
                    else if (status.Equals("05"))
                    {
                        messageBoxIcon = MessageBoxIcon.Error;
                        showMessageTitle = "錯誤";
                        showMessage = "新增失敗\r\n已有相同卡號。";
                    }
                    else if (status.Equals("06"))
                    {
                        messageBoxIcon = MessageBoxIcon.Error;
                        showMessageTitle = "錯誤";
                        showMessage = "新增失敗\r\n名單已滿。";
                    }
                    else
                    {
                        messageBoxIcon = MessageBoxIcon.Error;
                        showMessageTitle = "錯誤";
                        showMessage = "未知錯誤\r\n請聯絡工程單位。";
                    }
                    MessageBox.Show(showMessage, showMessageTitle, MessageBoxButtons.OK, messageBoxIcon);
                }
                // Delete
                else if (buttonDo.Text.Equals("刪除"))
                {
                    string beforeCRCString = "F8FA000000102201" + cardNumber;
                    byte[] CRCbyte = new byte[beforeCRCString.Length / 2];
                    for (int i = 0; i < beforeCRCString.Length; i += 2)
                    {
                        CRCbyte[i / 2] = Convert.ToByte(beforeCRCString.Substring(i, 2), 16);
                    }
                    ushort CRC = cb.CRC16CCITT(CRCbyte);
                    string CRCString = CRC.ToString("X2");
                    string sendMsg = beforeCRCString + CRCString;
                    byte[] sendMsgByte = new byte[sendMsg.Length / 2];
                    for (int i = 0; i < sendMsg.Length; i += 2)
                    {
                        sendMsgByte[i / 2] = Convert.ToByte(sendMsg.Substring(i, 2), 16);
                    }
                    string reciveMsg = cb.Connection(sendMsgByte, labelIp.Text);
                    reciveMsg = reciveMsg.Replace(" ", "");
                    string status = reciveMsg.Substring(12, 2);
                    string showMsg = "";
                    string showTitle = "";
                    MessageBoxIcon messageBoxIcon = MessageBoxIcon.Information;
                    if (status.Equals("01"))
                    {
                        showMsg = "刪除成功";
                        showTitle = "提醒";
                        messageBoxIcon = MessageBoxIcon.Information;
                        ListCount();
                    }
                    else if (status.Equals("02"))
                    {
                        showMsg = "無法更改";
                        showTitle = "提醒";
                        messageBoxIcon = MessageBoxIcon.Error;
                    }
                    else if (status.Equals("05"))
                    {
                        showMsg = "已有相同卡號";
                        showTitle = "提醒";
                        messageBoxIcon = MessageBoxIcon.Error;
                    }
                    else
                    {
                        showMsg = "嚴重錯誤'\r\n請洽工程人員。";
                        showTitle = "錯誤";
                        messageBoxIcon = MessageBoxIcon.Error;
                    }
                    MessageBox.Show(showMsg, showTitle, MessageBoxButtons.OK, messageBoxIcon);
                }
                else if (buttonDo.Text.Equals("搜尋"))
                {
                    string beforeCRCString = "F8FA00070011526561640E" + cardNumber;
                    byte[] CRCbyte = new byte[beforeCRCString.Length / 2];
                    for (int i = 0; i < beforeCRCString.Length; i += 2)
                    {
                        CRCbyte[i / 2] = Convert.ToByte(beforeCRCString.Substring(i, 2), 16);
                    }
                    ushort CRC = cb.CRC16CCITT(CRCbyte);
                    string CRCString = CRC.ToString("X2");
                    string sendMsg = beforeCRCString + CRCString;
                    byte[] sendMsgbyte = new byte[sendMsg.Length / 2];
                    for (int i = 0; i < sendMsg.Length; i += 2)
                    {
                        sendMsgbyte[i / 2] = Convert.ToByte(sendMsg.Substring(i, 2), 16);
                    }
                    byte[] a = new byte[] { 0xF8, 0xFA, 0x00, 0x07, 0x00, 0x11, 0x52, 0x65, 0x61, 0x64, 0x0E, 0xCC, 0xBB, 0xAA, 0x11, 0x22, 0x33, 0x44, 0x55, 0x66, 0x77, 0x88, 0xAA, 0xDA, 0xC9 };
                    string reciveMsg = cb.Connection(a, labelIp.Text);
                }
                Thread.Sleep(500);
                // Start RF.
                Byte[] sandStartMsgByte = new Byte[] { 0xFA, 0xF8, 0x00, 0x05, 0x00, 0x06, 0xFF, 0x1D, 0x01, 0x01, 0xAE, 0x78 };
                string reciveMsgForStartRF = cb.Connection(sandStartMsgByte, labelIp.Text);
            }
            this.Invoke((MethodInvoker)delegate
            {
                panelDo.Enabled = true;
                this.Cursor = Cursors.Arrow;
            });
        }
        private void buttonDeleteAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("即將清除所以人員資訊", "注意", MessageBoxButtons.YesNo, MessageBoxIcon.Warning).Equals(DialogResult.Yes))
            {
                if (int.Parse(nunberCount) > 0)
                {
                    foreach (Control control in panelTop.Controls)
                    {
                        control.Enabled = false;
                    }
                    buttonDeleteAll.Text = "刪除中...";
                    this.Cursor = Cursors.WaitCursor;
                    Thread thDeleteAll = new Thread(new ThreadStart(ThDeleteAll));
                    thDeleteAll.Start();
                }
                else
                {
                    MessageBox.Show("無人員資料", "提醒");
                }
            }
        }
        private void ThDeleteAll()
        {
            // Stop RF.
            Byte[] sandStopMsgByte = new Byte[] { 0xFA };
            string reciveMsgForStopRF = cb.Connection(sandStopMsgByte, labelIp.Text);
            // Delete all.
            string sendMsgString = "F8FA000200042001303B";
            byte[] sendMsgByte = new byte[sendMsgString.Length / 2];
            for (int i = 0; i < sendMsgString.Length; i += 2)
            {
                sendMsgByte[i / 2] = Convert.ToByte(sendMsgString.Substring(i, 2), 16);
            }
            string reciveMsg = cb.Connection(sendMsgByte, labelIp.Text);
            reciveMsg = reciveMsg.Replace(" ", "");
            string status = reciveMsg.Substring(13, 1);
            string showMsg = "";
            string titleMsg = "";
            MessageBoxIcon messageBoxIcon = MessageBoxIcon.Information;
            if (status.Equals("1"))
            {
                showMsg = "已刪除全部資料";
                titleMsg = "提醒";
                messageBoxIcon = MessageBoxIcon.Information;
            }
            else if(status.Equals("2"))
            {
                showMsg = "無法更改";
                titleMsg = "提醒";
                messageBoxIcon = MessageBoxIcon.Exclamation;
            }
            else
            {
                showMsg = "嚴重錯誤\r\n請洽工程師";
                titleMsg = "錯誤";
                messageBoxIcon = MessageBoxIcon.Error;
            }
            Thread.Sleep(500);           
            // Start RF.
            Byte[] sandStartMsgByte = new Byte[] { 0xFA, 0xF8, 0x00, 0x05, 0x00, 0x06, 0xFF, 0x1D, 0x01, 0x01, 0xAE, 0x78 };
            string reciveMsgForStartRF = cb.Connection(sandStartMsgByte, labelIp.Text);
            this.Invoke((MethodInvoker)delegate
            {
                foreach (Control control in panelTop.Controls)
                {
                    control.Enabled = true;
                }
                buttonDeleteAll.Text = "刪除全部";
                this.Cursor = Cursors.Arrow;
                if (showMsg.Equals("已刪除全部資料"))
                {
                    labelListCount.Text = "◆名單總數：0000筆";
                }
            });
            MessageBox.Show(showMsg, titleMsg, MessageBoxButtons.OK, messageBoxIcon);
        }
    }
}
