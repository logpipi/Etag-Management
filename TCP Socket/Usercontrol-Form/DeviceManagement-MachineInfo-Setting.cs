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

namespace TCP_Socket.Usercontrol_Form
{
    public partial class DeviceManagement_MachineInfo_Setting : Form
    {
        Tool tool = new Tool();
        public DeviceManagement_MachineInfo_Setting()
        {
            InitializeComponent();
            buttonModifyNet.BackColor = Color.LightGray;
        }
        private void ButtonActive(Button button)
        {
            foreach(Control control in panelTop1.Controls)
            {
                if(control.GetType() == typeof(Button))
                {
                    Button button1 = (Button)control;
                    button1.BackColor = Color.White;
                }
            }
            button.BackColor = Color.LightGray;
        }
        private Form modifyNet = null;
        private Form modifyUser = null;
        private Form accessControls = null;
        private void OpenForm(Form chileForm)
        {
            chileForm.Dock = DockStyle.Fill;
            chileForm.TopLevel = false;
            chileForm.FormBorderStyle = FormBorderStyle.None;
            panelContainer.Controls.Add(chileForm);
            chileForm.Show();
        }
        private DeviceManagement_MachineInfo_Setting_ModifyIP_M_G dmsmI = new DeviceManagement_MachineInfo_Setting_ModifyIP_M_G();
        private DeviceManagement_MachineInfo_Setting_AccessControls dmsa = new DeviceManagement_MachineInfo_Setting_AccessControls();
        private DeviceManagement_MachineInfo_Setting_ModifyUserInfo dmsm = new DeviceManagement_MachineInfo_Setting_ModifyUserInfo();
        private string[] netInfo = new string[4];
        public void Setting(string mN, string ip, string gateWay, string mask)
        {
          
            netInfo[0] = mN;
            netInfo[1] = ip;
            netInfo[2] = gateWay;
            netInfo[3] = mask;
            labelMachine.Text = "機碼：" + mN;
            labelAddress.Text = ip;
            //----
            string ipp = "";
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
            string settingPath = Application.StartupPath + "\\DeviceInfo_Setting";
            settingPath += "\\" + ipp + "Location.ini";
            if (!File.Exists(settingPath))
            {
                tool.WriteIPandLocation(ipp, "進入");
            }
            //-----
            dmsmI.Setting(mN, ip, gateWay, mask);
            modifyNet = dmsmI;
            OpenForm(modifyNet);
            //-----
            dmsm.SetIp(netInfo[1]);
            dmsm.ListCount();
            modifyUser = dmsm;
            OpenForm(modifyUser);
            //-----
            Thread.Sleep(50);
            accessControls = dmsa;
            dmsa.Setting(ip);
            OpenForm(accessControls);
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
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void buttonModifyNet_Click(object sender, EventArgs e)
        {
            dmsmI.Setting(netInfo[0], netInfo[1], netInfo[2], netInfo[3]);
            modifyNet.BringToFront();
            ButtonActive(buttonModifyNet);
        }

        private void buttonAccessControl_Click(object sender, EventArgs e)
        {
            accessControls.BringToFront();
            ButtonActive(buttonAccessControl);
        }

        private void buttonModifyUser_Click(object sender, EventArgs e)
        {
            modifyUser.BringToFront();
            ButtonActive(buttonModifyUser);
        }
        private void buttonTime_Click(object sender, EventArgs e)
        {
            
        }
    }
}
