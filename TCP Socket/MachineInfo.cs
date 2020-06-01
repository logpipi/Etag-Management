using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCP_Socket
{
    class MachineInfo
    {
        // 00 02 68 49 54 48 65 08 237 02 176 01 45 192 168 01 15 192 168 01 254 255 255 255 00 
        /// <summary>
        /// Get all infomation.
        /// </summary>
        /// <returns></returns>
        public string MachineInfoEtc()
        {
            Byte[] sendByte = new Byte[] { 0x53, 0x46, 0x2D, 0x54, 0x45, 0x4B, 0x2D, 0x45, 0x74, 0x68, 0x65, 0x72, 0x6E, 0x65, 0x74 };

            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 50001);
            UdpClient uc = new UdpClient();

            string rerurnMsg = string.Empty;
            for (int j = 0; j < 255; j++)
            {
                try
                {
                    string receiveMsg = string.Empty;
                    uc.Send(sendByte, sendByte.Length, ipep);
                    EndPoint chechUdp = uc.Client.RemoteEndPoint;
                    byte[] receiveBytes = uc.Receive(ref ipep);
                    for (int i = 0; i < receiveBytes.Length; i++)
                    {
                        if (i >= 7 && i <= 12)
                        {
                            receiveMsg += (Convert.ToString(receiveBytes[i], 16).ToUpper()).PadLeft(2, '0') + " ";
                        }
                        else
                        {
                            receiveMsg += (Convert.ToString(receiveBytes[i], 10).ToUpper()).PadLeft(2, '0') + " ";
                        }
                    }
                    //foreach (byte temp in receiveBytes)
                    //{
                    //    receiveMsg += (Convert.ToString(temp, toBase).ToUpper()).PadLeft(2, '0') + " ";
                    //}
                    if (rerurnMsg.Contains(receiveMsg))
                    {
                        // Do nothing.
                    }
                    else
                    {
                        rerurnMsg += receiveMsg + "@";
                    }
                }
                catch
                {
                    MessageBox.Show("無符合的設備。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
                uc.Dispose();
            }
            if (rerurnMsg != "")
            {
                return rerurnMsg.Remove(rerurnMsg.Length - 1, 1);
            }
            return "";
        }
        /// <summary>
        /// Get machine IP.
        /// </summary>
        /// <returns></returns>
        public string MachineIP(string info)
        {
            if (info != "")
            {
                string[] array = info.Split(' ');
                string ip = null;
                for (int i = 13; i <= 16; i++)
                {
                    if (i != 16)
                    {
                        ip += array[i] + ".";
                    }
                    else
                    {
                        ip += array[i];
                    }
                }
                return ip;
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Get machine default gateway.
        /// </summary>
        /// <returns></returns>
        public string MachineDefaultGateway(string info)
        {
            if (info != "")
            {
                string[] array = info.Split(' ');
                string defaultGateway = null;
                for (int i = 17; i <= 20; i++)
                {
                    if (i != 20)
                    {
                        defaultGateway += array[i] + ".";
                    }
                    else
                    {
                        defaultGateway += array[i];
                    }
                }
                return defaultGateway;
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Get machine mac.
        /// </summary>
        /// <returns></returns>
        public string MachineMac(string info)
        {
            if (info != "")
            {
                string[] array = info.Split(' ');

                string networkMask = null;
                for (int i = 7; i <= 12; i++)
                {
                    if (i != 12)
                    {
                        networkMask += array[i] + ".";
                    }
                    else
                    {
                        networkMask += array[i];
                    }
                }
                return networkMask;
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Get machine number.
        /// </summary>
        /// <returns></returns>
        public string MachineNumber(string info)
        {
            if (info != "")
            {
                if (info != "")
                {
                    string[] array = info.Split(' ');

                    string number = null;
                    for (int i = 0; i <= 1; i++)
                    {
                        number += array[i];
                    }
                    string returnString = "";
                    for (int i = 0; i < number.Length; i++)
                    {
                        if (!number[i].Equals('0'))
                        {
                            for (int j = i; j < number.Length; j++)
                            {
                                returnString += number[j];
                            }
                            break;
                        }
                    }
                    return returnString;
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// Get machine mask.
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public string MachineNetworkMask(string info)
        {
            if (info != "")
            {
                string[] array = info.Split(' ');

                string defaultMask = null;
                for (int i = 21; i <= 24; i++)
                {
                    if (i != 24)
                    {
                        defaultMask += array[i] + ".";
                    }
                    else
                    {
                        defaultMask += array[i];
                    }
                }
                return defaultMask;
            }
            else
            {
                return "";
            }
        }
    }
}
