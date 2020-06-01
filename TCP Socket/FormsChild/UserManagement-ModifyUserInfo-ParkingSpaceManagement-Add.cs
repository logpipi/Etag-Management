using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCP_Socket.FormsChild
{
    public partial class UserManagement_ModifyUserInfo_ParkingSpaceManagement_Add : Form
    {
        private SQLServer sql = new SQLServer();
        public UserManagement_ModifyUserInfo_ParkingSpaceManagement_Add()
        {
            InitializeComponent();
        }
        private void UserManagement_ModifyUserInfo_ParkingSpaceManagement_Add_Load(object sender, EventArgs e)
        {
            Setting();
        }
        DataTable dtParkInfo = new DataTable();
        private void Setting()
        {
            dtParkInfo = sql.Query("Parking_Space_Group",0);
        }
        private int toMove, x, y;
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
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            bool isInsert = true;
            if(comboBoxCarModel.Text.Equals(""))
            {
                labelCarModel.Text = "*車種：";
                labelCarModel.ForeColor = Color.Red;
                isInsert = false;
            }
            else
            {
                labelCarModel.Text = "車種：";
                labelCarModel.ForeColor = Color.Blue;  
            }
            if (textBoxGroupName.Text.Equals(""))
            {
                labelGroupName.Text = "*群組名稱：";
                labelGroupName.ForeColor = Color.Red;
                isInsert = false;
            }
            else
            {
                labelGroupName.Text = "群組名稱：";
                labelGroupName.ForeColor = Color.Blue;
            }
            if (textBoxAvailable.Text.Equals(""))
            {
                labelParkingID.Text = "*可停車位數：";
                labelParkingID.ForeColor = Color.Red;
                isInsert = false;
            }
            else
            {
                labelParkingID.Text = "可停車位數：";
                labelParkingID.ForeColor = Color.Blue;
            }
            for(int i =0;i< dtParkInfo.Rows.Count;i++)
            {
                if(textBoxGroupName.Text.Equals(dtParkInfo.Rows[i][1].ToString()))
                {
                    isInsert = false;
                    labelGroupName.Text = "*群組名稱：";
                    labelGroupName.ForeColor = Color.Red;
                    MessageBox.Show("群組名稱重複。", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                }
            }
            // Start insert.
            if (isInsert)
            {
                label1Title.Text = "完成";
                label1Title.ForeColor = Color.Blue;
                List<string> addInfo = new List<string>();
                addInfo.Add(textBoxGroupName.Text);
                if (comboBoxCarModel.Text.Equals("汽車"))
                {
                    addInfo.Add("Car");
                }
                else if (comboBoxCarModel.Text.Equals("機車"))
                {
                    addInfo.Add("Morto");
                }
                //string parkingID = "";
                //for (int i = 0; i < flowLayoutPanelParjingID.Controls.Count; i++)
                //{
                //    if (flowLayoutPanelParjingID.Controls[i].GetType() == typeof(Button))
                //    {
                //        Button button = (Button)flowLayoutPanelParjingID.Controls[i];
                //        if (i != flowLayoutPanelParjingID.Controls.Count - 1)
                //        {
                //            parkingID += button.Text + ",";
                //        }
                //        else
                //        {
                //            parkingID += button.Text;
                //        }
                //    }
                //}
                addInfo.Add("無");
                addInfo.Add(textBoxAvailable.Text);
                addInfo.Add(textBoxOther.Text);
                addInfo.Add("0");
                if (sql.Insert("Parking_Space_Group", null, addInfo))
                {
                    MessageBox.Show("新增成功。", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("新增失敗。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonToPool_Click(object sender, EventArgs e)
        {
            AddTOPool();
        }

        private void textBoxAvailable_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 | (int)e.KeyChar > 57) & (int)e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBoxParkingNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                AddTOPool();
            }
        }
        private void AddTOPool()
        {
            Button button = new Button();
            button.Font = new Font("Microsoft JhengHei UI", 9);
            button.Size = new Size(44, 25);
            button.ContextMenuStrip = contextMenuStrip1;
            button.AutoSize = true;
            button.Text = textBoxParkingNumber.Text;
            if (!button.Text.Equals(""))
            {
                flowLayoutPanelParjingID.Controls.Add(button);
            }
            textBoxParkingNumber.Text = "";
            textBoxParkingNumber.Focus();
        }

    }
}
