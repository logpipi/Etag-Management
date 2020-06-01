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

namespace TCP_Socket
{
    public partial class CheckSQL : Form
    {
        SQLServer sql = new SQLServer();
        public CheckSQL()
        {
            InitializeComponent();
        }

        private void CheckSQL_Load(object sender, EventArgs e)
        {
            Thread thCheckSQL = new Thread(new ThreadStart(ConnectSQL));
            thCheckSQL.Start();
        }
        private void ConnectSQL()
        {
            if (sql.CheckConnect())
            {
                this.DialogResult = DialogResult.Yes;
            }
            else
            {
                this.Invoke((MethodInvoker)delegate
                {
                    panelError.Visible = true;
                });
            }
            timer1.Stop();
        }
        private int count = 1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            labelPast.Text = "經過..." + count + " s";
            count++;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
    }
}
