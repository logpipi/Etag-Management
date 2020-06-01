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

namespace TCP_Socket.Forms
{
    public partial class SoftWarwControl : Form
    {
        CommunicationBase cb = new CommunicationBase();

        private string ipSettingPath = Application.StartupPath + "\\DeviceInfo_Setting" + "\\Device.ini";

        public SoftWarwControl()
        {
            InitializeComponent();
        }
        public void ComboBoxItem()
        {
            comboBoxMachine.Items.Clear();
            ipSettingPath = Application.StartupPath + "\\DeviceInfo_Setting" + "\\Device.ini";
            // 1 2 6 7
            if (File.Exists(ipSettingPath))
            {
                StreamReader sr = new StreamReader(ipSettingPath);
                int i = 1;// machine number .
                int j = 2;// IP
                int o = 1;
                string machine_ip = "";
                List<string> machie_ip = new List<string>();
                while (!sr.EndOfStream)
                {
                    string text = sr.ReadLine();
                    if (o == i)
                    {
                        i += 5;
                        machine_ip = "機碼：" + text;
                    }
                    if (o == j)
                    {
                        j += 5;
                        machine_ip += "   IP：" + text;
                        machie_ip.Add(machine_ip);
                    }
                    o++;
                }
                for (int p = 0; p < machie_ip.Count; p++)
                {
                    comboBoxMachine.Items.Add(machie_ip[p]);
                }
            }
        }
        bool isRead = false;
        private void buttonOpenControls_Click(object sender, EventArgs e)
        {
            isRead = true;
            buttonCloseControl.Enabled = true;
            buttonOpenControls.Enabled = false;
            List<string> ipList = new List<string>();
            List<string> mNList = new List<string>();
            if (File.Exists(ipSettingPath))
            {
                labelError.Visible = false;
                StreamReader sr = new StreamReader(ipSettingPath);
                int count = 1;
                int ipCount = 2;
                int mNCount = 1;
                string ip = "";
                while (!sr.EndOfStream)
                {
                    ip = sr.ReadLine();
                    if (count == ipCount)
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
                for (int i = 0; i < ipList.Count; i++)
                {
                    Thread thStartRead = new Thread(new ParameterizedThreadStart(ReadUserInfo));
                    thStartRead.Name = "thStartRead(" + ipList[i] + ")";
                    thStartRead.Start(ipList[i] + "@" + mNList[i]);
                }
            }
            else
            {
                labelError.Visible = true;
                isRead = false;
                buttonCloseControl.Enabled = false;
                buttonOpenControls.Enabled = true;
            }
        }

        private void buttonCloseControl_Click(object sender, EventArgs e)
        {
            isRead = false;
            buttonCloseControl.Enabled = false;
            buttonOpenControls.Enabled = true;
        }
        private string startPath = Application.StartupPath + "\\DeviceInfo_Setting";
        private Tool tool = new Tool();
        SQLServer sql = new SQLServer();
        private bool SetValidInfo(string cardN, string ip)
        {
            dtMemValid.Clear();
            dtParkValid.Clear();

            string[] conditinInfo = new string[] { "Card_number=" + cardN };
            dtMemValid = sql.Query_Condition("Menbers_Table", conditinInfo, 0);

            if (dtMemValid.Rows.Count == 1)
            {
                parkSpaceNumber = dtMemValid.Rows[0][4].ToString();
                isParkValid = dtMemValid.Rows[0][8].ToString();
                string[] conditinInfo1 = new string[] { "Group_UUID=" + dtMemValid.Rows[0][4].ToString() };
                dtParkValid = sql.Query_Condition("Parking_Space_Group", conditinInfo1, 0);
            }
            else
            {
                return false;
            }

            if (dtMemValid.Rows.Count == 1)
            {
                string[] ip_array = ip.Split('.');
                string ipp = "";
                for (int i = 0; i < ip_array.Length; i++)
                {
                    if (i == ip_array.Length - 1)
                    {
                        ipp += ip_array[i].PadLeft(3, '0');
                    }
                    else
                    {
                        ipp += ip_array[i].PadLeft(3, '0') + ".";
                    }
                }
                startPath += ipp + "Location.ini";
                stageValid = tool.ReadIPandLocation(ipp);
                stageValid = stageValid.Split('_')[1];
            }
            else
            {
                return false;
            }

            if (dtParkValid.Rows.Count == 1)
            {
                availableParkValid = int.Parse(dtParkValid.Rows[0][4].ToString());
            }
            else
            {
                return false;
            }
            return true;
        }
        DataTable dtMemValid = new DataTable();
        DataTable dtParkValid = new DataTable();
        string parkSpaceNumber = "";
        string isParkValid = "";
        int availableParkValid = 0;
        string stageValid = "";
        private bool isEnterValid = false;
        private string Valid(string cardN, string ip)
        {
            string returnString = "";
            if (SetValidInfo(cardN, ip))
            {
                if (stageValid.Equals("進入"))
                {
                    if (isParkValid.Equals("0"))
                    {
                        List<string> setInfo = new List<string>();
                        setInfo.Add("IsParked=1");
                        List<string> conditionInfo = new List<string>();
                        conditionInfo.Add("Card_number='" + cardN + "'" + " and IsDeleted='0'");
                        if (sql.Update("Menbers_Table", setInfo, conditionInfo))
                        {
                            availableParkValid--;
                            List<string> setInfo1 = new List<string>();
                            setInfo1.Add("Number_of_Available=" + availableParkValid);
                            List<string> conditionInfo1 = new List<string>();
                            conditionInfo1.Add("Group_UUID='" + parkSpaceNumber + "'" + " and IsDeleted='0'");
                            if (sql.Update("Parking_Space_Group", setInfo1, conditionInfo1))
                            {
                                returnString = "進入。開門";
                            }
                        }
                    }
                }
                else if (stageValid.Equals("離開"))
                {
                    if (isParkValid.Equals("1"))
                    {
                        List<string> setInfo = new List<string>();
                        setInfo.Add("IsParked=0");
                        List<string> conditionInfo = new List<string>();
                        conditionInfo.Add("Card_number='" + cardN + "'" + " and IsDeleted='0'");
                        if (sql.Update("Menbers_Table", setInfo, conditionInfo))
                        {
                            availableParkValid++;
                            List<string> setInfo1 = new List<string>();
                            setInfo1.Add("Number_of_Available=" + availableParkValid);
                            List<string> conditionInfo1 = new List<string>();
                            conditionInfo1.Add("Group_UUID='" + parkSpaceNumber + "'" + " and IsDeleted='0'");
                            if (sql.Update("Parking_Space_Group", setInfo1, conditionInfo1))
                            {
                                returnString = "離開。開門";
                            }
                        }
                    }
                }
            }
            return returnString;
        }
        private void ReadUserInfo(object Oip_mN)
        {
            string ip_mN = (string)Oip_mN;
            string[] ip_mNArray = ip_mN.Split('@');
           
            //取得Reader同卡間隔內不重複的Tag資料
            Byte[] _SensorData = new Byte[] { 0xF8, 0xFA, 0x00, 0x00, 0x00, 0x02, 0xCB, 0x54 };
            while (isRead)
            {
                string openDoor = "";
                string reciveText = cb.Connection(_SensorData, ip_mNArray[0]);
                string cardN = cb.GetCardNumber(reciveText);
                if (!cardN.Equals(""))
                {
                    while (isEnterValid)
                    {
                        Thread.Sleep(500);
                        // Do nothing.
                    }
                    isEnterValid = true;
                    string sueecssString = Valid(cardN, ip_mNArray[0]);
                    DataTable dtMen = new DataTable();
                    string[] conditinInfo = new string[] { "Card_number=" + cardN };
                    dtMen = sql.Query_Condition("Menbers_Table", conditinInfo, 0);
                    if (!sueecssString.Equals(""))
                    {
                        if (reciveText.Length > 3)
                        {
                            WriteLog("◆卡號：" + cardN + "      ◆時間：" + cb.GetTime(reciveText) + "      ◆車牌：" + dtMen.Rows[0][2].ToString() + "      ◆車主：" + dtMen.Rows[0][3].ToString() + "      ◆機碼：" + ip_mNArray[1] + "      ◆門禁狀態：" + sueecssString);
                        }
                    }
                    isEnterValid = false;
                }
            }
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
        private string ipForOpen = "";
        private void buttonOpenDoor_Click(object sender, EventArgs e)
        {
            if(comboBoxMachine.Text.Equals(""))
            {
                buttonError.Visible = true;
            }
            else
            {
                buttonError.Visible = false;
                ipForOpen = comboBoxMachine.Text.Split('：')[comboBoxMachine.Text.Split('：').Length - 1];
                Thread thOpenDoor = new Thread(new ThreadStart(ThOpenDoor));
                thOpenDoor.Start();
            }
        }
        private void ThOpenDoor()
        {
            byte[] sendMsg = new byte[] { 0xF8, 0xFA, 0x00, 0x05, 0x00, 0x07, 0x63, 0x74, 0x6C, 0x00, 0x00, 0xFA, 0xB2 };
            string reciveMsg = cb.Connection(sendMsg, ipForOpen);
        }

        private void buttonDeleteTextbox_Click(object sender, EventArgs e)
        {
            textBoxLog.Text = "";
        }
    }
}
