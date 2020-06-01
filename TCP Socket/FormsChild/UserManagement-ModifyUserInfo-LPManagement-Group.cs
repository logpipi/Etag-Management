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
    public partial class UserManagement_ModifyUserInfo_LPManagement_Group : Form
    {
        SQLServer sql = new SQLServer();
        public UserManagement_ModifyUserInfo_LPManagement_Group()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
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
        DataTable dtGroupInfo = new DataTable();
        private void comboBoxCarModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxGroup.Items.Clear();
            if (comboBoxCarModel.Text.Equals("汽車"))
            {
                string[] condition = new string[] { "Car_Model=Car" };
                dtGroupInfo = sql.Query_Condition("Parking_Space_Group", condition, 0);
            }
            else if (comboBoxCarModel.Text.Equals("機車"))
            {
                string[] condition = new string[] { "Car_Model=Morto" };
                dtGroupInfo = sql.Query_Condition("Parking_Space_Group", condition, 0);
            }
            for (int i = 0; i < dtGroupInfo.Rows.Count; i++)
            {
                comboBoxGroup.Items.Add(dtGroupInfo.Rows[i][1].ToString());
            }
        }
        private void comboBoxGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            listViewGroup.Columns.Add("卡號");
            listViewGroup.Columns.Add("車牌");
            listViewGroup.Columns.Add("車主");
            string UUID = "";
            string car_Model = "";
            for (int i =0;i< dtGroupInfo.Rows.Count;i++)
            {
                if(comboBoxGroup.Text.Equals(dtGroupInfo.Rows[i][1].ToString()))
                {
                    UUID = dtGroupInfo.Rows[i][0].ToString();
                    car_Model = dtGroupInfo.Rows[i][3].ToString();
                }
            }
            DataTable dtMemInfo = new DataTable();
            string[] condition = new string[] { "Parking_space_Group=" + UUID };
            dtMemInfo = sql.Query_Condition("Menbers_Table", condition, 0);
            DataTable dtMemInfoReverse = new DataTable();
            string[] conditionReverse = new string[] { "Parking_space_Group!=" + UUID };
            dtMemInfoReverse = sql.Query_Condition("Menbers_Table", conditionReverse, 0);
            // Group of list.
            for (int i = 0;i< dtMemInfo.Rows.Count;i++)
            {
                if (dtMemInfo.Rows[i][5].ToString().Equals(car_Model))
                {
                    ListViewItem item = new ListViewItem(dtMemInfo.Rows[i][1].ToString());
                    item.SubItems.Add(dtMemInfo.Rows[i][2].ToString());
                    item.SubItems.Add(dtMemInfo.Rows[i][3].ToString());
                    listViewGroup.Items.Add(item);
                }
            }
            // .
        }
    }
}
