using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCP_Socket.FormsChild
{
    public partial class UserManagement_ModifyUserInfo_LPManagement_Import : Form
    {
        SQLServer sql = new SQLServer();
        public UserManagement_ModifyUserInfo_LPManagement_Import()
        {
            InitializeComponent();
        }
        private int toMove, x, y;
        private void panelContainer_MouseDown(object sender, MouseEventArgs e)
        {
            toMove = 1;
            x = e.X;
            y = e.Y;
        }

        private void panelContainer_MouseUp(object sender, MouseEventArgs e)
        {
            toMove = 0;
        }
        private void panelContainer_MouseMove(object sender, MouseEventArgs e)
        {
            if (toMove == 1)
                this.SetDesktopLocation(MousePosition.X - x, MousePosition.Y - y);
        }

        private void buttonChoosePath_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "請選擇檔案";
            dialog.Filter = "(*.csv)|*.csv";
            bool isEnter = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBoxPath.Text = dialog.FileName;
                buttonImport.Enabled = true;
                FileStream fs1 = null;
                try
                {
                    fs1 = new FileStream(textBoxPath.Text, FileMode.Open, FileAccess.Read);
                }
                catch
                {
                    isEnter = false;
                    MessageBox.Show("請先關閉'" + textBoxPath.Text.Split('\\')[textBoxPath.Text.Split('\\').Length - 1] + "'再重選一次", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxPath.Text = "";
                }
                if (fs1 != null)
                {
                    fs1.Dispose();
                }
                if (isEnter)
                {
                    FileStream fs = new FileStream(textBoxPath.Text, FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(fs, Encoding.Unicode);
                    string[] columnName = new string[7];
                    int columnValidCount = 0;
                    bool columnValid = true;
                    string errorMsg = "";
                    int count = 0;
                    List<string> cardNumber = new List<string>();
                    while (!sr.EndOfStream)
                    {
                        if (count == 0)
                        {
                            columnName = sr.ReadLine().Split(',');
                            for (int i = 0; i < columnName.Length; i++)
                            {
                                string addString = "";
                                if (columnName[i].Equals("卡號"))
                                {
                                    columnValidCount++;
                                }
                                else if (columnName[i].Equals("車牌"))
                                {
                                    columnValidCount++;
                                }
                                else if (columnName[i].Equals("車主"))
                                {
                                    columnValidCount++;
                                }
                                else if (columnName[i].Equals("車群"))
                                {
                                    columnValidCount++;
                                }
                                else if (columnName[i].Equals("車種"))
                                {
                                    columnValidCount++;
                                }
                                else if (columnName[i].Equals("備註"))
                                {
                                    columnValidCount++;
                                }
                                else if (columnName[i].Equals("是否在庫"))
                                {
                                    columnValidCount++;
                                }
                            }
                            if (columnValidCount != columnName.Length)
                            {
                                textBoxPath.Text = "";
                                columnValid = false;
                                labelMsg.Visible = true;
                                labelMsg.Text = "欄位數量錯誤。";
                                errorMsg += "欄位數量錯誤";
                                labelMsg.ForeColor = Color.Yellow;
                                MessageBox.Show("欄位數量錯誤", "欄位錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                break;
                            }
                            count++;
                        }
                        else
                        {
                            string[] stringArray = sr.ReadLine().Split(',');
                            for (int i = 0; i < stringArray.Length; i++)
                            {
                                if (columnName[i].Equals("卡號"))
                                {
                                    if (stringArray[i].Equals(""))
                                    {
                                        errorMsg += "資料格有空值";
                                        break;
                                    }
                                    else
                                    {
                                        if (stringArray[i].Length % 2 != 0)
                                        {
                                            errorMsg += "卡號(" + stringArray[i] + ")長度錯誤";
                                            break;
                                        } 
                                        if (i == 0)
                                        {
                                            cardNumber.Add(stringArray[0]);
                                        }
                                        else
                                        {
                                            for (int j = 0; j < cardNumber.Count; j++)
                                            {
                                                if (stringArray[i].Equals(cardNumber[j]))
                                                {
                                                    errorMsg += "卡號(" + stringArray[i] + ")重複";
                                                    break;
                                                }
                                            }
                                            cardNumber.Add(stringArray[i]);
                                        }
                                    }
                                }
                                else if (columnName[i].Equals("車牌"))
                                {
                                    if (stringArray[i].Equals(""))
                                    {
                                        errorMsg += "資料格有空值";
                                        break;
                                    }
                                }
                                else if (columnName[i].Equals("車主"))
                                {
                                    if (stringArray[i].Equals(""))
                                    {
                                        errorMsg += "資料格有空值\r\n";
                                    }
                                }
                                else if (columnName[i].Equals("車群"))
                                {
                                    if (stringArray[i].Equals(""))
                                    {
                                        errorMsg += "資料格有空值";
                                        break;
                                    }
                                }
                                else if (columnName[i].Equals("車種"))
                                {
                                    if (stringArray[i].Equals(""))
                                    {
                                        errorMsg += "資料格有空值";
                                        break;
                                    }
                                    else if (!stringArray[i].Equals("汽車") &&
                                       !stringArray[i].Equals("機車") &&
                                       !stringArray[i].Equals("摩托車"))
                                    {
                                        errorMsg += "車種輸入錯誤";
                                        break;
                                    }
                                }
                                else if (columnName[i].Equals("備註"))
                                {
                                    // Do nothing.
                                }
                                else if (columnName[i].Equals("是否在庫"))
                                {
                                    if (stringArray[i].Equals(""))
                                    {
                                        errorMsg += "資料格有空值";
                                        break;
                                    }
                                }
                            }
                            if (!errorMsg.Equals(""))
                            {
                                columnValid = false;
                                labelMsg.Visible = true;
                                labelMsg.Text = "資料格錯誤。";
                                labelMsg.ForeColor = Color.Yellow;
                                MessageBox.Show(errorMsg, "資料格錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                break;
                            }
                        }
                    }
                    if (columnValid)
                    {
                        labelMsg.Visible = true;
                        labelMsg.Text = "資料正確";
                        labelMsg.ForeColor = Color.FromArgb(128, 255, 128);
                    }
                    else
                    {
                        labelMsg.Visible = true;
                        labelMsg.Text = "資料錯誤，無法匯入。("+errorMsg+")";
                        labelMsg.ForeColor = Color.Yellow;
                        textBoxPath.Text = "";
                        buttonImport.Enabled = false;
                    }
                    fs.Dispose();
                }
            }
        }
        private void buttonImport_Click(object sender, EventArgs e)
        {
            if (sql.InsetDataForMember(textBoxPath.Text))
            {
                MessageBox.Show("匯入成功", "提醒");
            }
            else
            {
                MessageBox.Show("匯入失敗", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }
    }
}
