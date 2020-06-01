using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCP_Socket.FormsChild
{
    public partial class UserManagement_ModifyUserInfo_LPManagement_Add : Form
    {
        private SQLServer sql = new SQLServer();
        public UserManagement_ModifyUserInfo_LPManagement_Add()
        {
            InitializeComponent();
        }
        private void UserManagement_ModifyUserInfo_LPManagement_Add_Load(object sender, EventArgs e)
        {
            comboBoxCarModel.Text = "汽車";
            comboBoxIsParked.Text = "否";
            Setting();
        }
        DataTable dtCar = new DataTable();
        DataTable dtMorto = new DataTable();
        DataTable dtMember = new DataTable();

        private void Setting()
        {  
            string[] carCondition = new string[] { "Car_Model=Car" };
            string[] mortoCondition = new string[] { "Car_Model=Morto" };
            dtCar = sql.Query_Condition("Parking_Space_Group", carCondition,0);
            dtMorto = sql.Query_Condition("Parking_Space_Group", mortoCondition,0);
            dtMember = sql.Query("Menbers_Table",0);            
        }
        private int toMove = 0,x,y;
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

        private void textBoxCardnumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            //int ch = Convert.ToInt32(e.KeyChar);

            //if ( (ch >= 97 && ch <= 122) || ((ch >= 48 && ch <= 57)) || ch == 8)
            //{
            //    // Do nothing.
            //}
            //else
            //{
            //    e.Handled = true;
            //}
        }
        private void textBoxCardnumber_TextChanged(object sender, EventArgs e)
        {

        }
        private void ControlsListAdd()
        {
            addInfo.Clear();
            labels.Clear();

            addInfo.Add(textBoxCardnumber.Text);
            addInfo.Add(textBoxLP.Text);
            addInfo.Add(textBoxCOwner.Text);
            addInfo.Add(comboBoxGroup.Text);
            addInfo.Add(comboBoxCarModel.Text);
            addInfo.Add(comboBoxIsParked.Text);

            labels.Add(labelCN);
            labels.Add(labelLP);
            labels.Add(labelCO);
            labels.Add(labelG);
            labels.Add(labelCarModel);
            labels.Add(labelIsParked);

            labelsText.Add("*卡號：");
            labelsText.Add("*車牌：");
            labelsText.Add("*車主：");
            labelsText.Add("*族群：");
            labelsText.Add("*車種：");
            labelsText.Add("*在位：");
        }
        List<string> addInfo = new List<string>();
        List<Label> labels = new List<Label>();
        List<string> labelsText = new List<string>();
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ControlsListAdd();
            bool isEmpty = false;
            for (int i = 0; i < addInfo.Count; i++)
            {
                if (addInfo[i].Equals(""))
                {
                    isEmpty = true;
                    labels[i].ForeColor = Color.Red;
                    labels[i].Text = labelsText[i];
                }
                else 
                {
                    labels[i].ForeColor = Color.Green;
                    labels[i].Text = labelsText[i].Substring(1, 3);
                }
            }
            Regex regex = new Regex(@"^[A-Za-z0-9]+$");
            if (!regex.IsMatch(textBoxCardnumber.Text) || textBoxCardnumber.Text.Length % 2 != 0)
            {
                isEmpty = true;
                labelCN.Text = "*卡號：";
                labelCN.ForeColor = Color.Red;
                MessageBox.Show("卡號格式錯誤","提醒");
            }
            for (int i = 0; i < dtMember.Rows.Count; i++)
            {
                if (textBoxCardnumber.Text.Equals(dtMember.Rows[i][1]))
                {
                    isEmpty = true;
                    labelCN.Text = "*卡號：";
                    labelCN.ForeColor = Color.Red;
                    MessageBox.Show("卡號重複", "提醒");
                    break;
                }
            }
            // Start insert.
            if (!isEmpty)
            {
                label1Title.Text = "√ 完成。";
                label1Title.ForeColor = Color.Green;
                if (MessageBox.Show("確定新增？", "提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                {
                    addInfo.Clear();
                    addInfo.Add(textBoxCardnumber.Text);
                    addInfo.Add(textBoxLP.Text);
                    addInfo.Add(textBoxCOwner.Text);
                    if (comboBoxCarModel.Text.Equals("汽車"))
                    {
                        for (int i = 0; i < dtCar.Rows.Count; i++)
                        {
                            if (dtCar.Rows[i][1].Equals(comboBoxGroup.Text))
                            {
                                addInfo.Add(dtCar.Rows[i][0].ToString());
                                break;
                            }
                        }
                        addInfo.Add("Car");
                    }
                    else if(comboBoxCarModel.Text.Equals("機車"))
                    {
                        for (int i = 0; i < dtMorto.Rows.Count; i++)
                        {
                            if (dtMorto.Rows[i][1].Equals(comboBoxGroup.Text))
                            {
                                addInfo.Add(dtMorto.Rows[i][0].ToString());
                                break;
                            }
                        }
                        addInfo.Add("Morto");
                    }
                    addInfo.Add("" + textBoxNickName.Text + "@" + textBoxP1.Text + "@" + textBoxP2.Text
                        + "@" + textBoxAddress.Text + "@" + textBoxOther.Text);
                    addInfo.Add("0");
                    if (comboBoxIsParked.Text.Equals("是"))
                    {
                        addInfo.Add("1");
                    }
                    else
                    {
                        addInfo.Add("0");
                    }
                    if (sql.Insert("Menbers_Table", addInfo, null))
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
            else
            {
                label1Title.Text = "*以下必填";
                label1Title.ForeColor = Color.Red;
            }
        }
        private void comboBoxCarModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            Setting();
            comboBoxGroup.Items.Clear();
            if (comboBoxCarModel.Text.Equals("汽車"))
            {
                for (int i = 0; i < dtCar.Rows.Count; i++)
                {
                    comboBoxGroup.Items.Add(dtCar.Rows[i][1]);
                }
            } 
            else if (comboBoxCarModel.Text.Equals("機車"))
            {
                for (int i = 0; i < dtMorto.Rows.Count; i++)
                {
                    comboBoxGroup.Items.Add(dtMorto.Rows[i][1]);
                }
            }
        }
    }
}
