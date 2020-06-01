using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCP_Socket.Usercontrol_Form
{
    public partial class IpTextbox : UserControl
    {
        public IpTextbox()
        {
            InitializeComponent();
        }

        private bool AboveThreeLetter(object sender)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.Length >= 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void Above255(object sender)
        {
            TextBox textBox = (TextBox)sender;
            if (!textBox.Text.Equals(""))
            {
                if (int.Parse(textBox.Text) > 255)
                {
                    textBox.Text = "255";
                }
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(AboveThreeLetter(sender))
            {
                textBox2.Focus();
            }
            Above255(sender);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (AboveThreeLetter(sender))
            {
                textBox3.Focus();
            }
            Above255(sender);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (AboveThreeLetter(sender))
            {
                textBox4.Focus();
            }
            Above255(sender);
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Above255(sender);
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 | (int)e.KeyChar > 57) & (int)e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Decimal)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Decimal)
            {
                textBox3.Focus();
            }
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Decimal)
            {
                textBox4.Focus();
            }
        }
    }
}
