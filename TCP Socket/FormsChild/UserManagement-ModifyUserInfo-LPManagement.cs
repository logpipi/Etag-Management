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
    public partial class UserManagement_ModifyUserInfo_LPManagement : Form
    {
        private bool isAddListView = true;
        private SQLServer sql = new SQLServer();
        public UserManagement_ModifyUserInfo_LPManagement()
        {
            InitializeComponent();
        }
        private Form activeForm = null;
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            UserManagement_ModifyUserInfo_LPManagement_Add Umla = new UserManagement_ModifyUserInfo_LPManagement_Add();
            activeForm = Umla;
            Umla.Show();
            Thread thWaitModify = new Thread(new ThreadStart(ThWaitModify));
            thWaitModify.Start();
            //Setting();
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
            isAddListView = true;
            listviewList.Clear();
        }

        private void UserManagement_ModifyUserInfo_LPManagement_Load(object sender, EventArgs e)
        {
            //Setting();
        }
        DataTable dtMem = new DataTable();
        DataTable dtPar = new DataTable();
        public void Setting()
        {
            comboBoxSelection.Items.Clear();
            for (int i = 0; i < columnsArray.Length - 1; i++)
            {
                if (columnsArray[i].Contains("車位號碼"))
                    continue;
                comboBoxSelection.Items.Add(columnsArray[i].Split(',')[0]);
            }
            dtMem = sql.Query("Menbers_Table", 0);
            dtPar = sql.Query("Parking_Space_Group", 0);
            Listview(dtMem);
        }
        private string[] columnsArray = new string[] { "卡號,Card_number", "車主名稱,Car_Owner", "車牌,License_Plate", /*"車位號碼",*/ "車位群組,Parking_space_Group", "車種,Car_Model", "備註", "在位狀況" };
        private void Listview(DataTable dtInfo)
        {
            listViewShow.Clear();
            listViewShow.Font = new Font("Microsoft JhengHei UI", 10);
            listViewShow.GridLines = true;
            listViewShow.LabelEdit = false;
            listViewShow.FullRowSelect = true;
            for (int i = 0; i < columnsArray.Length; i++)
            {
                listViewShow.Columns.Add(columnsArray[i].Split(',')[0], 100);
            }

            for (int i = 0; i < dtInfo.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(dtInfo.Rows[i][1].ToString());
                item.SubItems.Add(dtInfo.Rows[i][3].ToString());
                item.SubItems.Add(dtInfo.Rows[i][2].ToString());
                string[] parkingID = new string[] { "Group_UUID = " + dtInfo.Rows[i][4].ToString() };
                DataTable dtParkingID = sql.Query_Condition("Parking_Space_Group", parkingID, 0);
                if (dtParkingID != null)
                {
                    if (dtParkingID.Rows.Count > 0)
                    {
                        //item.SubItems.Add(dtParkingID.Rows[0][2].ToString());
                        item.SubItems.Add(dtParkingID.Rows[0][1].ToString());
                    }
                    else
                    {
                        //item.SubItems.Add("無");
                        item.SubItems.Add("無");
                    }
                    if (dtInfo.Rows[i][5].Equals("Car"))
                    {
                        item.SubItems.Add("汽車");
                    }
                    else if (dtInfo.Rows[i][5].Equals("Morto"))
                    {
                        item.SubItems.Add("機車");
                    }
                    item.SubItems.Add(dtInfo.Rows[i][6].ToString());
                    if (dtInfo.Rows[i][8].ToString().Equals("1"))
                    {
                        item.SubItems.Add("在位中");
                    }
                    else if (dtInfo.Rows[i][8].ToString().Equals("0"))
                    {
                        item.SubItems.Add("離席中");
                    }
                    listViewShow.Items.Add(item);
                }
            }

            if (dtInfo.Rows.Count == 0)
            {
                buttonDeleteAll.Enabled = false;
            }
            else
            {
                buttonDeleteAll.Enabled = true;
            }
            labelNumber.Text = dtInfo.Rows.Count + "筆";
        }

        private void RightClickUpdate_Click(object sender, EventArgs e)
        {
            isAddListView = false;
            Update(listviewList[listviewList.Count - 1].Index);
            UserManagement_ModifyUserInfo_LPManagement_Update Umlu = new UserManagement_ModifyUserInfo_LPManagement_Update();
            Umlu.Setting(updateInfo);
            Umlu.Show();
            activeForm = Umlu;
            Thread thWaitModify = new Thread(new ThreadStart(ThWaitModify));
            thWaitModify.Start();
        }
        private void RightClickDelete_Click(object sender, EventArgs e)
        {
            isAddListView = false;
            //Update(listviewIndex);
            if (MessageBox.Show("確認刪除"+ listviewList.Count+"項？", "提醒", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
            {
                this.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                for (int i = 0; i < listviewList.Count; i++)
                {
                    List<string> upInfo = new List<string>();
                    upInfo.Add("IsDeleted=1");
                    List<string> conditionInfo = new List<string>();
                    conditionInfo.Add("Card_number='" + listviewList[i].Text + "'");
                    if (sql.Update("Menbers_Table", upInfo, conditionInfo))
                    {
                        listViewShow.Items.Remove(listViewShow.Items[listviewList[i].Index]);
                    }
                }
                this.Enabled = true;
                this.Cursor = Cursors.Arrow;
            }
            isAddListView = true;
            listviewList.Clear();
        }
        private int listviewIndex = 0;
        private List<ListViewItem> listviewList = new List<ListViewItem>();
        private void listViewShow_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (isAddListView)
            {
                listviewIndex = e.Item.Index;
                listviewList.Add(e.Item);
                for (int i = 0; i < listviewList.Count;)
                {
                    if (listviewList[i].Selected == false)
                    {
                        listviewList.RemoveAt(i);
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }
        private List<string> updateInfo = new List<string>();
        private void Update(int index)
        {
            updateInfo.Clear();
            for (int j = 0; j < listViewShow.Items[index].SubItems.Count; j++)
            {
                updateInfo.Add(listViewShow.Items[index].SubItems[j].Text);
            }           
        }

        private void buttonRe_Click(object sender, EventArgs e)
        {
            Setting();
        }
        private void Search()
        {
            bool isSearch = true;
            if(comboBoxSelection.Text.Equals(""))
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
                        if (columnsArray[i].Contains("車位群組"))
                        {
                            for (int j = 0; j < dtPar.Rows.Count; j++)
                            {
                                if(dtPar.Rows[j][1].Equals(saerchName))
                                {
                                    saerchName = dtPar.Rows[j][0].ToString();
                                }
                            }
                        }
                        else if (textBoxSearchText.Text.Equals("汽車"))
                        {
                            saerchName = "Car";
                        }
                        else if (textBoxSearchText.Text.Equals("機車"))
                        {
                            saerchName = "Morto";
                        }
                        string[] condition = new string[] { fieldName + "=" + saerchName };
                        DataTable dtSearch = new DataTable();
                        dtSearch = sql.Query_Condition("Menbers_Table", condition, 0);
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

        private void button1Search_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void textBoxSearchText_TextChanged(object sender, EventArgs e)
        {
            if(textBoxSearchText.Text.Length == 0)
            {
                //Setting();
            }
        }

        private void labelEmptyTextbox_Click(object sender, EventArgs e)
        {
            textBoxSearchText.Text = "";
        }

        private void textBoxSearchText_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            UserManagement_ModifyUserInfo_LPManagement_Import Umli = new UserManagement_ModifyUserInfo_LPManagement_Import();
            activeForm = Umli;
            Umli.Show();
            Thread thWaitModify = new Thread(new ThreadStart(ThWaitModify));
            thWaitModify.Start();
        }
        //private void ExcelExport()
        //{
        //    // 設定儲存檔名，不用設定副檔名，系統自動判斷 excel 版本，產生 .xls 或 .xlsx 副檔名
        //    string pathFile = Application.StartupPath + "\\"+DateTime.Now.ToString();

        //    Excel.Application excelApp;
        //    Excel._Workbook wBook;
        //    Excel._Worksheet wSheet;
        //    Excel.Range wRange;

        //    // 開啟一個新的應用程式
        //    excelApp = new Excel.Application();

        //    // 讓Excel文件可見
        //    excelApp.Visible = true;

        //    // 停用警告訊息
        //    excelApp.DisplayAlerts = false;

        //    // 加入新的活頁簿
        //    excelApp.Workbooks.Add(Type.Missing);

        //    // 引用第一個活頁簿
        //    wBook = excelApp.Workbooks[1];

        //    // 設定活頁簿焦點
        //    wBook.Activate();

        //    try
        //    {
        //        // 引用第一個工作表
        //        wSheet = (Excel._Worksheet)wBook.Worksheets[1];

        //        // 命名工作表的名稱
        //        wSheet.Name = "工作表測試";

        //        // 設定工作表焦點
        //        wSheet.Activate();

        //        excelApp.Cells[1, 1] = "Excel測試";

        //        // 設定第1列資料
        //        excelApp.Cells[1, 1] = "名稱";
        //        excelApp.Cells[1, 2] = "數量";
        //        // 設定第1列顏色
        //        wRange = wSheet.Range[wSheet.Cells[1, 1], wSheet.Cells[1, 2]];
        //        wRange.Select();
        //        //wRange.Font.Color = ColorTranslator.ToOle(Color.White);
        //        //wRange.Interior.Color = ColorTranslator.ToOle(Color.DimGray);

        //        // 設定第2列資料
        //        excelApp.Cells[2, 1] = "AA";
        //        excelApp.Cells[2, 2] = "10";

        //        // 設定第3列資料
        //        excelApp.Cells[3, 1] = "BB";
        //        excelApp.Cells[3, 2] = "20";

        //        // 設定第4列資料
        //        excelApp.Cells[4, 1] = "CC";
        //        excelApp.Cells[4, 2] = "30";

        //        // 設定第5列資料
        //        excelApp.Cells[5, 1] = "總計";
        //        // 設定總和公式 =SUM(B2:B4)
        //        excelApp.Cells[5, 2].Formula = string.Format("=SUM(B{0}:B{1})", 2, 4);
        //        // 設定第5列顏色
        //        wRange = wSheet.Range[wSheet.Cells[5, 1], wSheet.Cells[5, 2]];
        //        wRange.Select();
        //        // wRange.Font.Color = ColorTranslator.ToOle(Color.Red);
        //        // wRange.Interior.Color = ColorTranslator.ToOle(Color.Yellow);

        //        // 自動調整欄寬
        //        wRange = wSheet.Range[wSheet.Cells[1, 1], wSheet.Cells[5, 2]];
        //        wRange.Select();
        //        wRange.Columns.AutoFit();

        //        try
        //        {
        //            //另存活頁簿
        //            wBook.SaveAs(pathFile, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        //            Console.WriteLine("儲存文件於 " + Environment.NewLine + pathFile);
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine("儲存檔案出錯，檔案可能正在使用" + Environment.NewLine + ex.Message);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("產生報表時出錯！" + Environment.NewLine + ex.Message);
        //    }

        //    //關閉活頁簿
        //    wBook.Close(false, Type.Missing, Type.Missing);

        //    //關閉Excel
        //    excelApp.Quit();

        //    //釋放Excel資源
        //    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
        //    wBook = null;
        //    wSheet = null;
        //    wRange = null;
        //    excelApp = null;
        //    GC.Collect();

        //    Console.Read();
        //}

        private void listViewShow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                Setting();
            }
            if (e.Control && e.KeyCode == Keys.A)
            {
                this.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                for (int i = 0; i < listViewShow.Items.Count; i++)
                {
                    listViewShow.Items[i].Selected = true;
                }
                this.Cursor = Cursors.Arrow;
                this.Enabled = true;
            }
        }

        private void buttonDeleteAll_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("確認全部刪除？","注意",MessageBoxButtons.YesNo,MessageBoxIcon.Warning).Equals(DialogResult.Yes))
            {
                List<string> setInfo = new List<string>();
                setInfo.Add("IsDeleted=1");
                if(sql.Update("Menbers_Table", setInfo,null))
                {
                    Setting();
                }
                else
                {
                    MessageBox.Show("刪除失敗", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void buttonGroup_Click(object sender, EventArgs e)
        {
            UserManagement_ModifyUserInfo_LPManagement_Group Umlg = new UserManagement_ModifyUserInfo_LPManagement_Group();
            activeForm = Umlg;
            Umlg.Show();
            Thread thWaitModify = new Thread(new ThreadStart(ThWaitModify));
            thWaitModify.Start();
        }
    }
}
