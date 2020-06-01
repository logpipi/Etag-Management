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
    public partial class UserManagement_ModifyUserInfo_ParkingSpaceManagement_Update : Form
    {
        SQLServer sql = new SQLServer();
        public UserManagement_ModifyUserInfo_ParkingSpaceManagement_Update()
        {
            InitializeComponent();
        }
        // name type parking_id_list
        List<string> origalInfo = new List<string>();
        DataTable dtPar = new DataTable();
        public void Setting(List<string> showInfo)
        {
            comboBoxCarModel.Text = showInfo[3];
            labelGroupName1.Text = showInfo[0];
            textBoxOther.Text = showInfo[4];
            textBoxAvailable.Text = showInfo[2];
            origalInfo.Add(comboBoxCarModel.Text);
            string[] parkingS = showInfo[1].Split(',');
            origalInfo.Add(parkingS.Length.ToString());
            for (int i = 0; i < parkingS.Length; i++)
            {
                Button button = new Button();
                button.Font = new Font("Microsoft JhengHei UI", 9);
                button.Size = new Size(44, 25);
                button.ContextMenuStrip = contextMenuStrip1;
                button.MouseDown += new MouseEventHandler(ButtonDown);
                button.AutoSize = true;
                button.Text = parkingS[i];
                if (!button.Text.Equals(""))
                {
                    flowLayoutPanelParjingID.Controls.Add(button);
                }
            }
            dtPar = sql.Query("Parking_Space_Group", 0);
        }
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            bool isSuccess = true;
            if (flowLayoutPanelParjingID.Controls.Count == 0)
            {
                isSuccess = false;
                labelParkingID.Text = "*車位號碼";
                labelParkingID.ForeColor = Color.Red;
            }
            else
            {
                labelGroupName.Text = "車位號碼";
                labelGroupName.ForeColor = Color.Blue;
            }
            if(comboBoxCarModel.Text.Equals(""))
            {
                isSuccess = false;
                comboBoxCarModel.Text = "*車種";
                comboBoxCarModel.ForeColor = Color.Red;
            }
            else
            {
                comboBoxCarModel.Text = "車種";
                comboBoxCarModel.ForeColor = Color.Blue;
            }
            // Start update.
            if (isSuccess)
            {
                if (MessageBox.Show("確認修改？", "提醒", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                {
                    if (UPdate())
                    {
                        MessageBox.Show("修改成功", "提醒");
                        this.DialogResult = DialogResult.OK;
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("修改失敗", "提醒");
                    }
                }
            }
        }
        private bool Delete()
        {
            bool isSuccess =  false;
            List<string> setInfo = new List<string>();
            setInfo.Add("IsDeleted=1");
            List<string> conditionInfo = new List<string>();
            conditionInfo.Add("Group_Name='" + labelGroupName1 .Text+ "'");
            if (sql.Update("Parking_Space_Group", setInfo, conditionInfo))
            {
                isSuccess = true;
            }
            return isSuccess;
        }
        private bool UPdate()
        {
            bool isSuccess = false;
            List<string> setInfo = new List<string>();
            setInfo.Add("Group_Name="+labelGroupName1.Text);
            if (comboBoxCarModel.Text.Equals("汽車"))
            {
                setInfo.Add("Car_Model=" + "Car");
            }
            else if (comboBoxCarModel.Text.Equals("機車"))
            {
                setInfo.Add("Car_Model=" + "Morto");
            }
            string ParkingID = "";
            for(int i =0;i< flowLayoutPanelParjingID.Controls.Count;i++)
            {
                if (i == flowLayoutPanelParjingID.Controls.Count - 1)
                {
                    ParkingID += flowLayoutPanelParjingID.Controls[i].Text;
                }
                else
                {
                    ParkingID += flowLayoutPanelParjingID.Controls[i].Text + ",";
                }
            }
            setInfo.Add("Parking_Space_ID="+ParkingID);
            setInfo.Add("Number_of_Available="+textBoxAvailable.Text);
            setInfo.Add("Note="+textBoxOther.Text);
            setInfo.Add("IsDeleted=0");
            List<string> conditionInfo = new List<string>();
            conditionInfo.Add("Group_Name='" + labelGroupName1.Text + "' and IsDeleted='0'");
            if (sql.Update("Parking_Space_Group", setInfo, conditionInfo))
            {
                isSuccess = true;
            }
            return isSuccess;
        }
        private Button nowButton = new Button();
        private void ButtonDown(object sender, MouseEventArgs e)
        {
            nowButton = (Button)sender;
        }
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            nowButton.Dispose();
            flowLayoutPanelParjingID.Controls.Remove(nowButton); 
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

        private void buttonToPool_Click(object sender, EventArgs e)
        {
            AddTOPool();
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
    }
}
