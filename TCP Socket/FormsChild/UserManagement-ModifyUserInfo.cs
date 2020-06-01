using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TCP_Socket.FormsChild
{
    public partial class UserManagement_ModifyUserInfo : Form
    {
        private SQLServer sql = new SQLServer();
        //private UserManagement_ModifyUserInfo_LPManagement Uml = new UserManagement_ModifyUserInfo_LPManagement();
        //private UserManagement_ModifyUserInfo_ParkingSpaceManagement Ump = new UserManagement_ModifyUserInfo_ParkingSpaceManagement();
        private Form LPManagement = null;
        private Form PSManagement = null;

        public UserManagement_ModifyUserInfo()
        {
            InitializeComponent();
        }
        public void Setting(Form form1,Form form2)
        {
            LPManagement = form1;
            PSManagement = form2;
            OpenForm(LPManagement);
            OpenForm(PSManagement);
        }
        private void ButtonActive(object OactiveButton)
        {
            foreach (Button button in panelTop.Controls)
            {
                button.BackColor = Color.White;
            }
            Button activeButton = (Button)OactiveButton;
            activeButton.BackColor = Color.LightGray;
        }
        private Form OpenForm(Form chileForm)
        {
            chileForm.Dock = DockStyle.Fill;
            chileForm.TopLevel = false;
            chileForm.FormBorderStyle = FormBorderStyle.None;
            panelContainer.Controls.Add(chileForm);
            chileForm.Show();
            return chileForm;
        }
        private void UserManagement_ModifyUserInfo_Load(object sender, EventArgs e)
        {
            
            buttonLP.BackColor = Color.LightGray;
        }

        private void buttonLP_Click(object sender, EventArgs e)
        {
            ButtonActive(sender);
            LPManagement.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ButtonActive(sender);
            PSManagement.BringToFront();
        }
    }
}
