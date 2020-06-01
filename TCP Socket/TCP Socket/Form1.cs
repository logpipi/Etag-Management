using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TCP_Socket
{
    public partial class FormETagControlSystem : Form
    {
        private CommunicationBase cb = new CommunicationBase();
        public FormETagControlSystem()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = Application.StartupPath;
            labelTime.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            Thread thSocket = new Thread(new ThreadStart(DoSocket));
            thSocket.Start();
        }

        private void DoSocket()
        {
            //預設主機IP
            string hostIP = "192.168.1.15";

            //先建立IPAddress物件,IP為欲連線主機之IP
            IPAddress ipa = IPAddress.Parse(hostIP);

            //建立IPEndPoint
            IPEndPoint ipe = new IPEndPoint(ipa, 50000);

            //先建立一個TcpClient;
            TcpClient tcpClient = new TcpClient();

            //獲取 EPC/TID 號碼
            //Byte[] _SensorData = new Byte[] { 0xFA, 0xF8, 0x00, 0x05, 0x00, 0x06, 0xFF, 0x1D, 0x01, 0x01, 0xAE, 0x78 };

            //取得Reader同卡間隔內不重複的Tag資料
            Byte[] _SensorData = new Byte[] { 0xF8, 0xFA, 0x00, 0x00, 0x00, 0x02, 0xCB, 0x54 };

            //遠端手動開門
            //Byte[] _SensorData = new Byte[] { 0xF8, 0xFA, 0x00, 0x05, 0x00, 0x07, 0x63, 0x74, 0x6C, 0x00, 0x00, 0xFA, 0xB2 };

            //讀取開門時間
            //Byte[] _SensorData = new Byte[] { 0xF8, 0xFA, 0x00, 0x07, 0x00, 0x07, 0x52, 0x65, 0x61, 0x64, 0x02, 0x1B, 0x45 };

            //設定啟用/禁用蜂鳴器
            //Byte[] _SensorData = new Byte[] { 0xF8, 0xFA, 0x00, 0x05, 0x00, 0x09, 0x45, 0x6E, 0x6F, 0x70, 0x62, 0x7A, 0x01, 0x18, 0xC8 };

            //string loCRC, hiCRC;

            //UInt16 CRC = ModRTU_CRC(_SensorData, _SensorData.Length - 2);
            //string hexValue = CRC.ToString("X2");

            //if (hexValue.Length == 3)
            //{
            //    hiCRC = hexValue.Substring(1, 2); //crc low byte   
            //    loCRC = hexValue.Substring(0, 1); //crc high byte  
            //}
            //else
            //{
            //    hiCRC = hexValue.Substring(2, 2); //crc low byte   
            //    loCRC = hexValue.Substring(0, 2); //crc high byte  
            //}
            //_SensorData[_SensorData.Length - 2] = Convert.ToByte(hiCRC, 16);
            //_SensorData[_SensorData.Length - 1] = Convert.ToByte(loCRC, 16);



            //開始連線
            try
            {
                //WriteLog("主機IP=" + ipa.ToString());
                //WriteLog("連線至主機中...\n");
                //tcpClient.Connect(ipe);
                //if (tcpClient.Connected)
                //{
                //    WriteLog("連線成功...\n");
                //    CommunicationBase cb = new CommunicationBase();

                //    //if (cb.SendMsg(_SensorData, tcpClient))
                //    //{
                //        WriteLog("\r\n已經啟動連續讀卡...");
                //        Thread.Sleep(1000);
                //        string tt = "";
                //        while (tt.Equals(""))
                //        {
                //            cb.SendMsg(_SensorData, tcpClient);
                //            tt = cb.ReceiveMsg(tcpClient);
                //            Thread.Sleep(1000);
                //        }

                //        WriteLog(tt);
                //    //}
                //    //else
                //    //{
                //    //    WriteLog("\r\n啟動連續讀卡失敗...");
                //    //}

                //}
                //else
                //{
                //    WriteLog("連線失敗!");
                //}
            }
            catch (Exception ex)
            {
                tcpClient.Close();
                WriteLog("Error : " + ex.Message);
            }
        }

        static UInt16 ModRTU_CRC(byte[] buf, int len)
        {
            UInt16 crc = 0xFFFF;

            for (int pos = 0; pos < len; pos++)
            {
                crc ^= (UInt16)buf[pos];

                for (int i = 8; i != 0; i--)
                {
                    if ((crc & 0x0001) != 0)
                    {
                        crc >>= 1;
                        crc ^= 0xA001;
                    }
                    else
                        crc >>= 1;
                }
            }

            return crc;
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
        private void timerTime_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }
        private int toZoom = 0;
        private void buttonZoom_Click(object sender, EventArgs e)
        {
            if (toZoom == 0)
            {
                this.WindowState = FormWindowState.Maximized;
                toZoom = 1;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                toZoom = 0;
            }
        }

        private void buttonMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private int toMove = 0, x, y;
        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            toMove = 1;
            x = e.X;
            y = e.Y;
        }
        private void panelTop_MouseUp(object sender, MouseEventArgs e)
        {
            toMove = 0;
        }

        private void panelTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (toMove == 1)
                this.SetDesktopLocation(MousePosition.X - x, MousePosition.Y - y);
        }

        private void OpenForm(Form chileForm)
        {
            chileForm.Dock = DockStyle.Fill;
            chileForm.TopLevel = false;
            chileForm.FormBorderStyle = FormBorderStyle.None;
            panelContainer.Controls.Add(chileForm);
            chileForm.BringToFront();
            chileForm.Show();
        }
        private bool isFirstOpenDeviceManegement = true;
        private bool isFirstOpenUserManagement = true;
        private bool isFirstOpenSoftWareControl = true;

        private Form DeviceManagement = null;
        private Form UserManagement = null;
        private Form SoftWareControl = null;
        Forms.SoftWarwControl sc = new Forms.SoftWarwControl();

        private void buttonSoftControls_Click(object sender, EventArgs e)
        {
            if (isFirstOpenSoftWareControl)
            {
                sc.ComboBoxItem();
                SoftWareControl = sc;
                OpenForm(SoftWareControl);
                isFirstOpenSoftWareControl = false;
            }
            else
            {
                sc.ComboBoxItem();
                SoftWareControl.BringToFront();
            }
        }

        private void buttonDeviceManegement_Click(object sender, EventArgs e)
        {
            if (isFirstOpenDeviceManegement)
            {
                DeviceManagement = new Forms.DeviceManagement();
                OpenForm(DeviceManagement);
                isFirstOpenDeviceManegement = false;
            }
            else
            {
                DeviceManagement.BringToFront();
            }
        }
        private void buttonUserManagement_Click(object sender, EventArgs e)
        {
            if (isFirstOpenUserManagement)
            {
                UserManagement = new Forms.UserManagement();
                OpenForm(UserManagement);
                isFirstOpenUserManagement = false;
            }
            else
            {
                UserManagement.BringToFront();
            }
        }
    }
}
