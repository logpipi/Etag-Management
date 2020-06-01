using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TCP_Socket
{
    class SQLServer
    {
        private SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["BCInfo"].ConnectionString);
        private string Menbers_Table_FieldName = "(Card_number,License_Plate,Car_Owner,Parking_space_Group,Car_Model,Note,IsDeleted,IsParked)";
        private string Parking_Space_Group_FieldName = "(Group_Name,Car_Model,Parking_Space_ID,Number_of_Available,Note,IsDeleted)";
        private void Connect()
        {
            if (connect.State.ToString().Equals("Closed"))
            {
                connect.Open();
            }
            else if (connect.State.ToString().Equals("Open"))
            {
                try
                {
                    connect.Close();
                }
                catch { }
            }
        }
        public bool CheckConnect()
        {
            if (connect.State.ToString().Equals("Closed"))
            {
                try
                {
                    connect.Open();
                }
                catch
                {
                    return false;
                }
            }
            else if (connect.State.ToString().Equals("Open"))
            {
                try
                {
                    connect.Close();
                }
                catch { return false; }
            }
            return true;
        }
        /// <summary>
        ///  Insert infomantion.
        ///  Order of add*Info array : "cardNumber lp carOwner ParkingGroup CarModel Note" or
        ///  "Group_Name Car_Model Parking_Space_ID Number_of_Available Note ". 
        /// </summary>
        /// <param name="addInfo"></param>
        /// <returns></returns>
        public bool Insert(string tableName , List<string> addMemInfo,List<string> addParkInfo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            string insertString = "";
            string field = "";
            bool isSuccess = false;
            if (addParkInfo == null)
            {
                field = Menbers_Table_FieldName;
                for (int i = 0; i < addMemInfo.Count; i++)
                {
                    string addName = "@para" + i.ToString();
                    if (i == 3)
                    {
                        cmd.Parameters.Add(addName, SqlDbType.NVarChar, 300);
                        cmd.Parameters[addName].Value = addMemInfo[i];
                    }
                    else if (i == 5)
                    {
                        // nickName phone1 phone2 address other
                        string[] array = addMemInfo[i].Split('@');
                        string noteInfo = "◆小名：" + array[0] + " ◆電話1：" + array[1] + " ◆電話2：" + array[2] + " ◆地址：" + array[3]
                            + " ◆其他：" + array[4];
                        cmd.Parameters.Add(addName, SqlDbType.NVarChar, 300);
                        cmd.Parameters[addName].Value = noteInfo;
                    }
                    else
                    {
                        cmd.Parameters.Add(addName, SqlDbType.NVarChar, 50);
                        cmd.Parameters[addName].Value = addMemInfo[i];
                    }
                     if (i != addMemInfo.Count - 1)
                    {
                        insertString += "@para" + i.ToString() + ",";
                    }
                    else
                    {
                        insertString += "@para" + i.ToString();
                    }
                }
            }
            else if (addMemInfo == null)
            {
                //  "Group_Name Car_Model Parking_Space_ID Number_of_Available Note". 
                field = Parking_Space_Group_FieldName;
                for (int i = 0; i < addParkInfo.Count; i++)
                {
                    string addName = "@para" + i.ToString();
                    if (i == 3)
                    {
                        cmd.Parameters.Add(addName, SqlDbType.Int);
                        cmd.Parameters[addName].Value = int.Parse(addParkInfo[i]);
                    }
                    else if (i == 4)
                    {
                        cmd.Parameters.Add(addName, SqlDbType.NVarChar, 300);
                        cmd.Parameters[addName].Value = addParkInfo[i];
                    }
                    else
                    {
                        cmd.Parameters.Add(addName, SqlDbType.NVarChar, 50);
                        cmd.Parameters[addName].Value = addParkInfo[i];
                    }
                    if (i != addParkInfo.Count - 1)
                    {
                        insertString += "@para" + i.ToString() + ",";
                    }
                    else
                    {
                        insertString += "@para" + i.ToString();
                    }
                }
            }
            
            cmd.CommandText = @"insert into " + tableName + field
                 + "values("+ insertString + ")";
            Connect();
            if (cmd.ExecuteNonQuery() == 1)
            {
                isSuccess = true;
            }
            Connect();
            return isSuccess;
        }

        /// <summary>
        /// Query the infomation.
        /// isdelete : 0 or 1.
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public DataTable Query(string tableName,int isdelete)
        {
            DataTable returnTable = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = @"select * from "+ tableName + " where IsDeleted='"+ isdelete + "'";
            Connect();
            returnTable.Load(cmd.ExecuteReader());
            Connect();
            return returnTable;
        }
        /// <summary>
        /// Query the infomation.
        /// With condition. Condition : FieldName = condition.
        /// isdelete = 0 or 1.
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public DataTable Query_Condition(string tableName, string[] condition,int isdelete)
        {
            string[] splitArray1 = condition[0].Split('=');
            if (!splitArray1[1].Equals(" "))
            {
                DataTable returnTable = new DataTable();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                string conditionString = "IsDeleted = '" + isdelete + "' and ";
                for (int i = 0; i < condition.Length; i++)
                {
                    string[] splitArray = condition[i].Split('=');
                    string name = "@para" + i.ToString();

                    if (splitArray[0].Contains("UUID"))
                    {
                        Guid guid = new Guid(splitArray[1]);
                        cmd.Parameters.Add(name, SqlDbType.UniqueIdentifier);
                        cmd.Parameters[name].Value = guid;
                    }
                    else
                    {
                        cmd.Parameters.Add(name, SqlDbType.NVarChar, 50);
                        cmd.Parameters[name].Value = splitArray[1];
                    }
                    condition[i] = splitArray[0] + "=" + name;
                    if (i == condition.Length - 1)
                    {
                        conditionString += condition[i];
                    }
                    else
                    {
                        conditionString += condition[i] + " and ";
                    }

                }
                cmd.CommandText = @"select * from " + tableName + " where " + conditionString;

                Connect();
                string a = connect.State.ToString();
                returnTable.Load(cmd.ExecuteReader());
                Connect();
                return returnTable;
            }
            else
                return null;
        }
        /// <summary>
        /// Update the info.
        /// setInfo : field=newValue. 
        /// Condition : field = 'condition'.
        /// </summary>
        /// <returns></returns>
        public bool Update(string tableName, List<string> setInfo, List<string> condition)
        {
            bool isSuccess = true;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            string updateSet = "";
            for (int i = 0; i < setInfo.Count; i++)
            {
                string name =  "@para" +i.ToString();
                string[] array = setInfo[i].Split('=');
                if(array[0].Equals("IsDeleted"))
                {
                    Int32 data = Int32.Parse(array[1]);
                    cmd.Parameters.Add(name,SqlDbType.Int);
                    cmd.Parameters[name].Value = data;
                }
                else if (array[0].Contains("UUID"))
                {
                    Guid data = new Guid(array[1]);
                    cmd.Parameters.Add(name, SqlDbType.UniqueIdentifier);
                    cmd.Parameters[name].Value = data;
                }
                else
                {
                    cmd.Parameters.Add(name, SqlDbType.NVarChar, 10);
                    cmd.Parameters[name].Value = array[1];
                }
                if (i == setInfo.Count - 1)
                {
                    updateSet += array[0] + " = " + name;
                }
                else
                {
                    if (condition != null)
                    {
                        updateSet += array[0] + " = " + name + ",";
                    }
                    else
                    {
                        updateSet += array[0] + " = " + name ;
                    }
                }
            }
            string updateCondition = "";
            if (condition != null)
            {
                updateCondition = " where ";
                for (int i = 0; i < condition.Count; i++)
                {
                    if (i == condition.Count - 1)
                    {
                        updateCondition += condition[i];
                    }
                    else
                    {
                        updateCondition += "" + condition[i] + "" + " and ";
                    }
                }
            }
            cmd.CommandText = @"update " + tableName + " set " + updateSet  + updateCondition;
            Connect();
            if (cmd.ExecuteNonQuery() == 0)
            {
                isSuccess = false;
            }
            Connect();
            return isSuccess;
        }
        public bool InsetDataForMember(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs, Encoding.Unicode);
            bool returnString = true;
            int count = 0;
            string[] columnName = new string[7];
            string amdText = "";
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
                            addString = "Card_number";
                        }
                        else if (columnName[i].Equals("車牌"))
                        {
                            addString = "License_Plate";
                        }
                        else if (columnName[i].Equals("車主"))
                        {
                            addString = "Car_Owner";
                        }
                        else if (columnName[i].Equals("車群"))
                        {
                            addString = "Parking_space_Group";
                        }
                        else if (columnName[i].Equals("車種"))
                        {
                            addString = "Car_Model";
                        }
                        else if (columnName[i].Equals("備註"))
                        {
                            addString = "Note";
                        }
                        else if (columnName[i].Equals("是否在庫"))
                        {
                            addString = "IsParked";
                        }
                        amdText += addString + ",";
                    }
                    amdText += "IsDeleted";
                    count++;
                }
                else
                {
                    string[] stringArray = sr.ReadLine().Split(',');
                    SqlCommand cmd = new SqlCommand();
                    string insertString = "";
                    for (int i = 0; i < stringArray.Length; i++)
                    {
                        if (columnName[i].Equals("卡號"))
                        {
                            cmd.Parameters.Add("@para" + i, SqlDbType.NVarChar, 50);
                            cmd.Parameters["@para" + i].Value = stringArray[i];
                        }
                        else if (columnName[i].Equals("車牌"))
                        {
                            cmd.Parameters.Add("@para" + i, SqlDbType.NVarChar, 50);
                            cmd.Parameters["@para" + i].Value = stringArray[i];
                        }
                        else if (columnName[i].Equals("車主"))
                        {
                            cmd.Parameters.Add("@para" + i, SqlDbType.NVarChar, 50);
                            cmd.Parameters["@para" + i].Value = stringArray[i];
                        }
                        else if (columnName[i].Equals("車群"))
                        {
                            string[] condition = new string[] { "Group_Name=" + stringArray[i] };
                            DataTable dt = Query_Condition("Parking_Space_Group", condition, 0);
                            if (dt.Rows.Count > 0)
                            {
                                cmd.Parameters.Add("@para" + i, SqlDbType.NVarChar, 300);
                                cmd.Parameters["@para" + i].Value = dt.Rows[0][0].ToString();
                            }
                            else
                            {
                                cmd.Parameters.Add("@para" + i, SqlDbType.NVarChar, 300);
                                cmd.Parameters["@para" + i].Value = "";
                            }
                        }
                        else if (columnName[i].Equals("車種"))
                        {
                            if (stringArray[i].Equals("汽車"))
                            {
                                cmd.Parameters.Add("@para" + i, SqlDbType.NVarChar, 50);
                                cmd.Parameters["@para" + i].Value = "Car";
                            }
                            else if (stringArray[i].Equals("機車") ||
                                stringArray[i].Equals("摩托車"))
                            {
                                cmd.Parameters.Add("@para" + i, SqlDbType.NVarChar, 50);
                                cmd.Parameters["@para" + i].Value = "Morto";
                            }
                            else
                            {
                                cmd.Parameters.Add("@para" + i, SqlDbType.NVarChar, 50);
                                cmd.Parameters["@para" + i].Value = "";
                            }
                        }
                        else if (columnName[i].Equals("備註"))
                        {
                            cmd.Parameters.Add("@para" + i, SqlDbType.NVarChar, 300);
                            cmd.Parameters["@para" + i].Value = stringArray[i];
                        }
                        else if (columnName[i].Equals("是否在庫"))
                        {
                            int insertInt = 0;
                            if (stringArray[i].Equals("是"))
                            {
                                insertInt = 1;
                            }
                            cmd.Parameters.Add("@para" + i, SqlDbType.Int);
                            cmd.Parameters["@para" + i].Value = insertInt;
                        }
                        insertString += "@para" + i + ",";
                    }
                    cmd.Parameters.Add("@para" + stringArray.Length, SqlDbType.Int);
                    cmd.Parameters["@para" + stringArray.Length].Value = 0;
                    insertString += "@para" + stringArray.Length;
                    cmd.Connection = connect;
                    cmd.CommandText = @"insert into Menbers_Table(" + amdText + ")" +
                        "values(" + insertString + ")";
                    Connect();
                    if (cmd.ExecuteNonQuery() != 1)
                    {
                        returnString = false;
                        break;
                    }
                    else
                    {
                        int a = 0;
                    }
                    Connect();
                }
            }
            fs.Dispose();
            return returnString;
        }
        public bool InsertDataForParkingSpace(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs, Encoding.Unicode);
            bool returnString = true;
            int count = 0;
            string[] columnName = new string[4];
            string amdText = "";
            while (!sr.EndOfStream)
            {
                if (count == 0)
                {
                    columnName = sr.ReadLine().Split(',');
                    for (int i = 0; i < columnName.Length; i++)
                    {
                        string addString = "";
                        if (columnName[i].Equals("名稱"))
                        {
                            addString = "Group_Name";
                        }
                        else if (columnName[i].Equals("車種"))
                        {
                            addString = "Car_Model";
                        }
                        else if (columnName[i].Equals("剩餘車位"))
                        {
                            addString = "Number_of_Available";
                        }
                        else if (columnName[i].Equals("備註"))
                        {
                            addString = "Note";
                        }
                        amdText += addString + ",";
                    }
                    amdText += "IsDeleted,Parking_Space_ID";
                    count++;
                }
                else
                {
                    string[] stringArray = sr.ReadLine().Split(',');
                    SqlCommand cmd = new SqlCommand();
                    string insertString = "";
                    for (int i = 0; i < stringArray.Length; i++)
                    {
                        if (columnName[i].Equals("名稱"))
                        {
                            cmd.Parameters.Add("@para" + i, SqlDbType.NVarChar, 50);
                            cmd.Parameters["@para" + i].Value = stringArray[i];
                        }
                        else if (columnName[i].Equals("車種"))
                        {
                            if (stringArray[i].Equals("汽車"))
                            {
                                cmd.Parameters.Add("@para" + i, SqlDbType.NVarChar, 50);
                                cmd.Parameters["@para" + i].Value = "Car";
                            }
                            else if (stringArray[i].Equals("機車") ||
                                stringArray[i].Equals("摩托車"))
                            {
                                cmd.Parameters.Add("@para" + i, SqlDbType.NVarChar, 50);
                                cmd.Parameters["@para" + i].Value = "Morto";
                            }
                            else
                            {
                                cmd.Parameters.Add("@para" + i, SqlDbType.NVarChar, 50);
                                cmd.Parameters["@para" + i].Value = "";
                            }
                        }
                        else if (columnName[i].Equals("備註"))
                        {
                            cmd.Parameters.Add("@para" + i, SqlDbType.NVarChar, 300);
                            cmd.Parameters["@para" + i].Value = stringArray[i];
                        }
                        else if (columnName[i].Equals("剩餘車位"))
                        {
                            int addInt = int.Parse(stringArray[i]);
                            cmd.Parameters.Add("@para" + i, SqlDbType.Int);
                            cmd.Parameters["@para" + i].Value = addInt;
                        }
                        insertString += "@para" + i + ",";
                    }

                    cmd.Parameters.Add("@para" + stringArray.Length, SqlDbType.Int);
                    cmd.Parameters["@para" + stringArray.Length].Value = 0;
                    insertString += "@para" + stringArray.Length+",";

                    cmd.Parameters.Add("@para" + (stringArray.Length + 1), SqlDbType.NVarChar, 50);
                    cmd.Parameters["@para" + (stringArray.Length + 1)].Value = "無";
                    insertString += "@para" + (stringArray.Length + 1).ToString();

                    cmd.Connection = connect;
                    cmd.CommandText = @"insert into Parking_Space_Group(" + amdText + ")" +
                        "values(" + insertString + ")";
                    Connect();
                    if (cmd.ExecuteNonQuery() != 1)
                    {
                        returnString = false;
                        break;
                    }
                    else
                    {
                        int a = 0;
                    }
                    Connect();
                }
            }
            fs.Dispose();
            return returnString;
        }
    }
}
