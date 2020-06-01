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

namespace TCP_Socket.FormsChild
{
    public partial class UserManagement_ModifyUserInfo_ParkingSpaceManagement : Form
    {
        private SQLServer sql = new SQLServer();
        public UserManagement_ModifyUserInfo_ParkingSpaceManagement()
        {
            InitializeComponent();
        }
        private Form activeForm = null;

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            UserManagement_ModifyUserInfo_ParkingSpaceManagement_Add Umpa = new UserManagement_ModifyUserInfo_ParkingSpaceManagement_Add();
            activeForm = Umpa;
            Umpa.Show();
            Thread thWaitModify = new Thread(new ThreadStart(ThWaitModify));
            thWaitModify.Start();
        }
        private void ThWaitModify()
        {
            bool isDo = true;
            while (isDo)
            {
                if (activeForm.DialogResult.Equals(DialogResult.OK))
                {
                    isDo = false;
                    this.Invoke((MethodInvoker)delegate
                    {
                        Setting();
                    });
                }
                Thread.Sleep(500);
            }
        }
        private void UserManagement_ModifyUserInfo_ParkingSpaceManagement_Load(object sender, EventArgs e)
        {
            //Setting();
        }
        DataTable dtPar = new DataTable();
        public void Setting()
        {
            comboBoxSelection.Items.Clear();
            for (int i = 0; i < columnsArray.Length - 1; i++)
            {
                if (columnsArray[i].Contains("車位號碼") ||
                    columnsArray[i].Contains("可停車車位數量"))
                    continue;
                comboBoxSelection.Items.Add(columnsArray[i].Split(',')[0]);
            }
            dtPar = sql.Query("Parking_Space_Group",0);
            Listview(dtPar);
        }
        private string[] columnsArray = new string[] { "車位群名稱,Group_Name", "車位號碼,Parking_Space_ID", "可停車車位數量,Number_of_Available", "車種,Car_Model", "備註"};

        private void Listview(DataTable dtInfo)
        {
            listViewShow.Clear();
            listViewShow.Font = new Font("Microsoft JhengHei UI", 10);
            listViewShow.GridLines = true;
            listViewShow.LabelEdit = false;
            listViewShow.FullRowSelect = true;
            listViewShow.Columns.Add("車位群名稱", 100);
            //listViewShow.Columns.Add("車位號碼", 100);
            listViewShow.Columns.Add("可停車車位數量", 100);
            listViewShow.Columns.Add("車種", 100);
            listViewShow.Columns.Add("備註", 100);
            for (int i = 0; i < dtInfo.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(dtInfo.Rows[i][1].ToString());
                //item.SubItems.Add(dtInfo.Rows[i][2].ToString());
                item.SubItems.Add(dtInfo.Rows[i][4].ToString());
                if (dtInfo.Rows[i][3].ToString().Equals("Car"))
                {
                    item.SubItems.Add("汽車");
                }
                else if (dtInfo.Rows[i][3].ToString().Equals("Morto"))
                {
                    item.SubItems.Add("機車");
                }
                item.SubItems.Add(dtInfo.Rows[i][5].ToString());
                listViewShow.Items.Add(item);
            }
        }
        private int listviewIndex = 0;
        private List<string> showInfo = new List<string>();
        private void SetShowInfo()
        {
            showInfo.Clear();
            for (int i = 0; i < listViewShow.Items[listviewIndex].SubItems.Count; i++)
            {
                showInfo.Add(listViewShow.Items[listviewIndex].SubItems[i].Text);
            }
        }
        private void listViewShow_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {    
            listviewIndex = e.Item.Index;
        }

        private void RightClickUpdate_Click(object sender, EventArgs e)
        {
            SetShowInfo();
            UserManagement_ModifyUserInfo_ParkingSpaceManagement_Update Umpu = new UserManagement_ModifyUserInfo_ParkingSpaceManagement_Update();
            Umpu.Setting(showInfo);
            Umpu.Show();
            activeForm = Umpu;
            Thread thWaitModify = new Thread(new ThreadStart(ThWaitModify));
            thWaitModify.Start();
        }

        private void RightClickDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("確認刪除？", "提醒", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
            {
                SetShowInfo();
                string UUID = "";
                for (int i = 0; i < dtPar.Rows.Count; i++)
                {
                    if (dtPar.Rows[i][1].Equals(showInfo[0]))
                    {
                        UUID = dtPar.Rows[i][0].ToString();
                        break;
                    }
                }
                listViewShow.Items.RemoveAt(listviewIndex);
                List<string> setInfo = new List<string>();
                setInfo.Add("IsDeleted=1");
                List<string> conditionInfo = new List<string>();
                conditionInfo.Add("Group_UUID='" + UUID + "'");
                sql.Update("Parking_Space_Group", setInfo, conditionInfo);
            }
        }

        private void buttonRe_Click(object sender, EventArgs e)
        {
            Setting();
        }
        private void Search()
        {
            bool isSearch = true;
            if (comboBoxSelection.Text.Equals(""))
            {
                isSearch = false;
            }
            if (textBoxSearchText.Text.Equals(""))
            {
                isSearch = false;
            }
            if (isSearch)
            {
                for (int i = 0; i < columnsArray.Length; i++)
                {
                    if (columnsArray[i].Contains(comboBoxSelection.Text))
                    {
                        string fieldName = columnsArray[i].Split(',')[1];
                        string saerchName = textBoxSearchText.Text;
                        if (textBoxSearchText.Text.Equals("汽車"))
                        {
                            saerchName = "Car";
                        }
                        else if (textBoxSearchText.Text.Equals("機車"))
                        {
                            saerchName = "Morto";
                        }
                        string[] condition = new string[] { fieldName + "=" + saerchName };
                        DataTable dtSearch = new DataTable();
                        dtSearch = sql.Query_Condition("Parking_Space_Group", condition, 0);
                        Listview(dtSearch);
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("搜尋條件未寫完整", "提醒");
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void labelEmptyTextbox_Click(object sender, EventArgs e)
        {
            textBoxSearchText.Text = "";
        }

        private void textBoxSearchText_TextChanged(object sender, EventArgs e)
        {
            if(textBoxSearchText.Text.Equals(""))
            {
                //Setting();
            }
        }

        private void textBoxSearchText_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }

        private void listViewShow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                Setting();
            }
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            UserManagement_ModifyUserInfo_ParkingSpaceManagement_Import Umpi = new UserManagement_ModifyUserInfo_ParkingSpaceManagement_Import();
            activeForm = Umpi;
            Umpi.Show();
            Thread thWaitModify = new Thread(new ThreadStart(ThWaitModify));
            thWaitModify.Start();
        }
    }
}
