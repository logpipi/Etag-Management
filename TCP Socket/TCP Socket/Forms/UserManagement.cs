using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCP_Socket.Forms
{
    public partial class UserManagement : Form
    {
        private FormsChild.UserManagement_ModifyUserInfo_LPManagement Uml = new FormsChild.UserManagement_ModifyUserInfo_LPManagement();
        private FormsChild.UserManagement_ModifyUserInfo_ParkingSpaceManagement Ump = new FormsChild.UserManagement_ModifyUserInfo_ParkingSpaceManagement();
        private Form LPManagement = null;
        private Form PSManagement = null;
        private void UserManagement_Load(object sender, EventArgs e)
        {
            Uml.Setting();
            LPManagement = Uml;
            Ump.Setting();
            PSManagement = Ump;
        }
        private void OpenForm(Form chileForm)
        {
            activeForm = chileForm;
            chileForm.Dock = DockStyle.Fill;
            chileForm.TopLevel = false;
            chileForm.FormBorderStyle = FormBorderStyle.None;
            panelContainer.Controls.Add(chileForm);
            chileForm.BringToFront();
            chileForm.Show();
        }
        public UserManagement()
        {
            InitializeComponent();
        }
        private void ButtonActive(object OactiveButton)
        {
            foreach (Button button in panelLeft.Controls)
            {
                button.BackColor = Color.WhiteSmoke;
            }
            Button activeButton = (Button)OactiveButton;
            activeButton.BackColor = Color.LightGray;
        }
        private Form activeForm = null;
       
        private Form UserInfo = null;
        private bool isForstOpenUserInfo = true;
        private void buttonUserInfo_Click(object sender, EventArgs e)
        {
            if(isForstOpenUserInfo)
            {
                UserInfo = new FormsChild.UserManagement_UserInfo();
                OpenForm(UserInfo);
                isForstOpenUserInfo = false;
            }
            else
            {
                UserInfo.BringToFront();
            }
            ButtonActive(sender);
            
        }
        private Form ModifyUserInfo = null;
        private bool isForstOpenModifyUserInfo = true;
        private void buttonCarManagement_Click(object sender, EventArgs e)
        {
            if (isForstOpenModifyUserInfo)
            {
                FormsChild.UserManagement_ModifyUserInfo Um = new FormsChild.UserManagement_ModifyUserInfo();
                Um.Setting(LPManagement, PSManagement);
                ModifyUserInfo = Um;
                OpenForm(ModifyUserInfo);
                isForstOpenModifyUserInfo = false;
            }
            else
            {
                ModifyUserInfo.BringToFront();
            }
            ButtonActive(sender);
        }
    }
}
