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
    public partial class UserManagement_ModifyUserInfo_LPManagement_Update : Form
    {
        private SQLServer sql = new SQLServer();
        public UserManagement_ModifyUserInfo_LPManagement_Update()
        {
            InitializeComponent();
        }
        private DataTable dtCar = new DataTable();
        private DataTable dtMorto = new DataTable();
        private DataTable dtMember = new DataTable();
        private List<string> origelInfo = new List<string>();
        private List<string> origelOtherInfo = new List<string>();
        public void Setting(List<string> displayInfo)
        {
            GetCarOrMortoGroup();
            labelCardNumber.Text = displayInfo[0];
            textBoxLP.Text = displayInfo[2];
            textBoxCOwner.Text = displayInfo[1];
            comboBoxCarModel.Text = displayInfo[5];
            //if (displayInfo[5].Equals("Car"))
            //{
            //    comboBoxCarModel.Text = "汽車";
            //}
            //else if (displayInfo[5].Equals("Morto"))
            //{
            //    comboBoxCarModel.Text = "機車";
            //}
            comboBoxGroup.Text = displayInfo[4];
            if (displayInfo[7].Equals("離席中"))
            {
                comboBoxIsParked.Text = "否";
            }
            else if (displayInfo[7].Equals("在位中"))
            {
                comboBoxIsParked.Text = "是";
            }
            //-----------------------
            string[] array = displayInfo[6].Split(' ');
            textBoxNickName.Text = array[0].Split('：')[1];
            textBoxP1.Text = array[1].Split('：')[1];
            textBoxP2.Text = array[2].Split('：')[1];
            textBoxAddress.Text = array[3].Split('：')[1];
            textBoxOther.Text = array[4].Split('：')[1];
            origelInfo.Add(textBoxLP.Text);
            origelInfo.Add(textBoxCOwner.Text);
            origelInfo.Add(comboBoxGroup.Text);
            origelInfo.Add(comboBoxCarModel.Text);
            origelInfo.Add(comboBoxIsParked.Text);

            origelOtherInfo.Add(textBoxNickName.Text);
            origelOtherInfo.Add(textBoxP1.Text);
            origelOtherInfo.Add(textBoxP2.Text);
            origelOtherInfo.Add(textBoxAddress.Text);
            origelOtherInfo.Add(textBoxOther.Text);
        }
        private void GetCarOrMortoGroup()
        {
            string[] carCondition = new string[] { "Car_Model=Car" };
            string[] mortoCondition = new string[] { "Car_Model=Morto" };
            dtCar = sql.Query_Condition("Parking_Space_Group", carCondition,0);
            dtMorto = sql.Query_Condition("Parking_Space_Group", mortoCondition,0);
            dtMember = sql.Query("Menbers_Table",0);
        }
        private void comboBoxCarModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCarOrMortoGroup();
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
        private List<string> inputList = new List<string>();
        private List<string> inputOtherList = new List<string>();
        private List<Label> labelList = new List<Label>();
        private List<string> labelTextList = new List<string>();
        private void listSet()
        {
            inputList.Clear();
            labelList.Clear();
            labelTextList.Clear();
            inputOtherList.Clear();

            inputList.Add(textBoxLP.Text);
            inputList.Add(textBoxCOwner.Text);
            inputList.Add(comboBoxGroup.Text);
            inputList.Add(comboBoxCarModel.Text);
            inputList.Add(comboBoxIsParked.Text);

            inputOtherList.Add(textBoxNickName.Text);
            inputOtherList.Add(textBoxP1.Text);
            inputOtherList.Add(textBoxP2.Text);
            inputOtherList.Add(textBoxAddress.Text);
            inputOtherList.Add(textBoxOther.Text);

            labelList.Add(labelLP);
            labelList.Add(labelCO);
            labelList.Add(labelG);
            labelList.Add(labelCarModel);
            labelList.Add(labelIsParked);

            labelTextList.Add("*車牌");
            labelTextList.Add("*車主");
            labelTextList.Add("*群組");
            labelTextList.Add("*車種");
            labelTextList.Add("*在位");
        }
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            listSet();
            bool isUpdate = true;
            for (int i = 0; i < inputList.Count; i++)
            {
                if (inputList[i].Equals(""))
                {
                    isUpdate = false;
                    labelList[i].ForeColor = Color.Red;
                    labelList[i].Text = labelTextList[i];
                }
                else
                {
                    labelList[i].ForeColor = Color.Blue;
                    labelList[i].Text = labelTextList[i].Substring(1, 2);
                }
            }
            int count = 0;
            for (int i = 0; i < inputList.Count; i++)
            {
                if (inputList[i].Equals(origelInfo[i]))
                {
                    count++;
                }
            }
            for (int i = 0; i < inputOtherList.Count; i++)
            {
                if (inputOtherList[i].Equals(origelOtherInfo[i]))
                {
                    count++;
                }
            }
            if (count == inputList.Count + inputOtherList.Count)
            {
                MessageBox.Show("未修改任何資料", "提醒");
                isUpdate = false;
            }
            if (isUpdate)
            {
                StartUpdate();
            }
        }
        List<string> addInfo = new List<string>();
        private void StartUpdate()
        {
            if (MessageBox.Show("確定修改？", "提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
            {
                if (DeleteOldOne())
                {
                    //-----------------------
                    addInfo.Clear();
                    addInfo.Add(labelCardNumber.Text);
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
                    else if (comboBoxCarModel.Text.Equals("機車"))
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
                        MessageBox.Show("修改成功。", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("修改失敗。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("修改失敗。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool DeleteOldOne()
        {
            List<string> setInfo = new List<string>();
            setInfo.Add("IsDeleted=1");
            List<string> conditionInfo = new List<string>();
            conditionInfo.Add("Card_number='" + labelCardNumber.Text+"'");
            return sql.Update("Menbers_Table", setInfo, conditionInfo);
        }
    }
}
