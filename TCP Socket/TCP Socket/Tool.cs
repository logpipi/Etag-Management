using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCP_Socket
{
    class Tool
    {
        private string settingPath = Application.StartupPath + "\\DeviceInfo_Setting";

        public void WriteIPandLocation(string ip,string text)
        {
            string[] array = ip.Split('.');
            array[2] = array[2].PadLeft(3, '0');
            array[3] = array[3].PadLeft(3, '0');
            ip = array[0] + "." + array[1] + "." + array[2] + "." + array[3];
            settingPath = Application.StartupPath + "\\DeviceInfo_Setting";
            settingPath += "\\" + ip + "Location.ini";
            StreamWriter sw = new StreamWriter(settingPath);
            sw.WriteLine(ip + "_" + text);
            sw.Dispose();
        }
        public string ReadIPandLocation(string ip)
        {
            settingPath = Application.StartupPath + "\\DeviceInfo_Setting";
            string returnPath = "";
            settingPath += "\\" + ip + "Location.ini";
            if(File.Exists(settingPath))
            {
                StreamReader sr = new StreamReader(settingPath);
                returnPath = sr.ReadLine();
                sr.Dispose();
            }
            return returnPath;
        }
    }
}
