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
    public partial class DeviceManagement : Form
    {
        public DeviceManagement()
        {
            InitializeComponent();
        }
        private void ButtonActive(object OactiveButton)
        {
            foreach(Button button in panelLeft.Controls)
            {
                button.BackColor = Color.WhiteSmoke;
            }
            Button activeButton = (Button)OactiveButton;
            activeButton.BackColor = Color.LightGray;
        }
        private Form activeForm = null;
        private void OpenForm(Form chileForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            if (chileForm != null)
            {
                activeForm = chileForm;
                chileForm.Dock = DockStyle.Fill;
                chileForm.TopLevel = false;
                chileForm.FormBorderStyle = FormBorderStyle.None;
                panelContainer.Controls.Add(chileForm);
                chileForm.BringToFront();
                chileForm.Show();
            }
        }
        private void buttonConnection_Click(object sender, EventArgs e)
        {
            OpenForm(new FormsChild.DeviceManagement_Connection());
            ButtonActive(sender);
        }

        private void buttonControl_Click(object sender, EventArgs e)
        {
            OpenForm(null);

            ButtonActive(sender);
        }
    }
}
