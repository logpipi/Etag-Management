using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TCP_Socket
{
    class CommunicationBase
    {
        /// <summary>
        /// Connect with the Tcp/Ip socket devices.
        /// </summary>
        /// <param name="_SensorData">Input byte.</param>
        /// <param name="ip">Ip of target device.</param>
        /// <returns></returns>
        public string Connection(Byte[] _SensorData, string ip)
        {
            try
            {
                //取得Reader Flash內未回傳的資料
                while (!LoadFlashTag(ip).Equals("00"))
                {
                    Thread.Sleep(500);
                    //Do nothing.
                }

                //預設主機IP
                string hostIP = ip;
                //先建立IPAddress物件,IP為欲連線主機之IP
                IPAddress ipa = IPAddress.Parse(hostIP);
                //建立IPEndPoint
                IPEndPoint ipe = new IPEndPoint(ipa, 50000);
                //先建立一個TcpClient;
                TcpClient tcpClient = new TcpClient();
                tcpClient.Connect(ipe);
                string tt = "";
                int whileCount = 0;
                if (tcpClient.Connected)
                {
                    if (SendMsg(_SensorData, tcpClient))
                    {
                        while (tt.Equals(""))
                        {
                            tt = ReceiveMsg(tcpClient);
                            whileCount++;
                            if (whileCount > 1)
                            {
                                break;
                            }
                            Thread.Sleep(1000);
                        }
                    }
                }
                tcpClient.Dispose();
                return tt;
            }
            catch
            {
                return "";
            }
        }
        public string LoadFlashTag(string ip)
        {
            byte[] _SensorData = new byte[] { 0xF8, 0xFA, 0x00, 0x01, 0x00, 0x02, 0xFC, 0x64 };
            //預設主機IP
            string hostIP = ip;
            //先建立IPAddress物件,IP為欲連線主機之IP
            IPAddress ipa = IPAddress.Parse(hostIP);
            //建立IPEndPoint
            IPEndPoint ipe = new IPEndPoint(ipa, 50000);
            //先建立一個TcpClient;
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect(ipe);
            string tt = "";
            int whileCount = 0;
            if (tcpClient.Connected)
            {
                if (SendMsg(_SensorData, tcpClient))
                {
                    while (tt.Equals(""))
                    {
                        tt = ReceiveMsg(tcpClient);
                        whileCount++;
                        if (whileCount > 1)
                        {
                            break;
                        }
                        Thread.Sleep(1000);
                    }
                }
            }
            tcpClient.Dispose();
            return tt;
        }

        private void SendMsg(string msg, TcpClient tmpTcpClient)
        {
            NetworkStream ns = tmpTcpClient.GetStream();
            if (ns.CanWrite)
            {
                byte[] msgByte = Encoding.Default.GetBytes(msg);
                ns.Write(msgByte, 0, msgByte.Length);
            }
        }
        private bool SendMsg(byte[] msg, TcpClient tmpTcpClient)
        {
            NetworkStream ns = tmpTcpClient.GetStream();
            try
            {
                if (ns.CanWrite)
                {
                    ns.Write(msg, 0, msg.Length);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        private string ReceiveMsg(TcpClient tmpTcpClient)
        {
            string receiveMsg = string.Empty;
            byte[] receiveBytes = new byte[tmpTcpClient.ReceiveBufferSize];
            int numberOfBytesRead = 0;
            NetworkStream ns = tmpTcpClient.GetStream();
            if (ns.CanRead)
            {
                do
                {
                    numberOfBytesRead = ns.Read(receiveBytes, 0, tmpTcpClient.ReceiveBufferSize);
                    //receiveMsg = Encoding.Default.GetString(receiveBytes, 0, numberOfBytesRead);
                }
                while (ns.DataAvailable);

                Array.Resize(ref receiveBytes, numberOfBytesRead);

                foreach (byte temp in receiveBytes)
                {
                    receiveMsg += (Convert.ToString(temp, 16).ToUpper()).PadLeft(2, '0') + " ";
                }
            }
            return receiveMsg;
        }
        /// <summary>
        /// CRC16-CCITT algorithm.
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public ushort CRC16CCITT(byte[] bytes)
        {
            const ushort poly = 4129;
            ushort[] table = new ushort[256];
            ushort initialValue = 0xffff;
            ushort temp, a;
            ushort crc = initialValue;
            for (int i = 0; i < table.Length; ++i)
            {
                temp = 0;
                a = (ushort)(i << 8);
                for (int j = 0; j < 8; ++j)
                {
                    if (((temp ^ a) & 0x8000) != 0)
                        temp = (ushort)((temp << 1) ^ poly);
                    else
                        temp <<= 1;
                    a <<= 1;
                }
                table[i] = temp;
            }
            for (int i = 0; i < bytes.Length; ++i)
            {
                crc = (ushort)((crc << 8) ^ table[((crc >> 8) ^ (0xff & bytes[i]))]);
            }
            return crc;
        }
        /// <summary>
        /// Get card number.
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public string GetCardNumber(string info)
        {
            try
            {
                string[] array = info.Split(' ');
                string cardNumber = "";
                for (int i = 12; i <= 23; i++)
                {
                    cardNumber += array[i];
                }
                return cardNumber;
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// Get scan card time.
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public string GetTime(string info)
        {
            string[] array = info.Split(' ');
            string cardNumber = "";
            for (int i = 1; i <= 8; i++)
            {
                int num = Int32.Parse(array[i], System.Globalization.NumberStyles.HexNumber);
                if (i == 1 || i == 2)
                {
                    cardNumber += num;
                }
                else if (i == 3 || i == 4)
                {
                    cardNumber += "/" + num;
                }
                else if (i == 5)
                {
                    string date = "";
                    if (num == 1)
                    {
                        date = "星期一";
                    }
                    else if (num == 2)
                    {
                        date = "星期二";
                    }
                    else if (num == 3)
                    {
                        date = "星期三";
                    }
                    else if (num == 4)
                    {
                        date = "星期四";
                    }
                    else if (num == 5)
                    {
                        date = "星期五";
                    }
                    else if (num == 6)
                    {
                        date = "星期六";
                    }
                    else if (num == 7)
                    {
                        date = "星期日";
                    }
                    cardNumber += " " + date;
                }
                else if (i == 6)
                {
                    if (num < 10)
                    {
                        cardNumber += " 0" + num;
                    }
                    else
                    {
                        cardNumber += " " + num;
                    }
                }
                else if (i == 7 || i == 8)
                {
                    if (num < 10)
                    {
                        cardNumber += ":0" + num;
                    }
                    else
                    {
                        cardNumber += ":" + num;
                    }
                }
            }
            return cardNumber;
        }
    }
}
