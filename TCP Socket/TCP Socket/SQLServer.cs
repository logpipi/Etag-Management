using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;
using System.Text;

namespace TCP_Socket
{
    class SQLServer
    {
        private SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["BCInfo"].ConnectionString);
        private string Menbers_Table_FieldName = "(Card_number,License_Plate,Car_Owner,Parking_space_Group,Car_Model,Note,IsDeleted,IsParked)";
        private string Parking_Space_Group_FieldName = "(Group_Name,Car_Model,Parking_Space_ID,Number_of_Available,Note,IsDeleted)";
        private void Connect()
        {
            if(connect.State.ToString().Equals("Closed"))
            {
                connect.Open();
            }
            else if(connect.State.ToString().Equals("Open"))
            {
                connect.Close();
            }
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
            DataTable returnTable = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            string conditionString = "IsDeleted = '"+ isdelete + "' and ";
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
            cmd.CommandText = @"select * from " + tableName +" where "+ conditionString;

            Connect();
            string a = connect.State.ToString();
            returnTable.Load(cmd.ExecuteReader());
            Connect();
            return returnTable;
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
                    updateSet += array[0] + " = " + name + ",";
                }
            }
            string updateCondition = "";

            for (int i = 0; i < condition.Count; i++)
            {
                if (i == condition.Count - 1)
                {
                    updateCondition += condition[i];
                }
                else
                {
                    updateCondition += ""+condition[i]+"" + " and ";
                }
            }
            cmd.CommandText = @"update " + tableName + " set " + updateSet + " where " + updateCondition;
            Connect();
            if (cmd.ExecuteNonQuery() == 0)
            {
                isSuccess = false;
            }
            Connect();
            return isSuccess;
        }
        public DataTable GetExcelDatatable(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs, Encoding.Unicode);
            string a = sr.ReadLine();
            a = sr.ReadLine();
            return null;
        }
        public int InsetData(DataTable dt)
        {
            int i = 0;
            string Group_Name = "";
            string Parking_Space_ID = "";
            string Car_Model = "";
            string Number_of_Available = "";
            string Note = "";
            string IsDeleted = "";

            foreach (DataRow dr in dt.Rows)
            {
                Group_Name = dr["Group_Name"].ToString().Trim();
                Parking_Space_ID = dr["Parking_Space_ID"].ToString().Trim();
                Car_Model = dr["Car_Model"].ToString().Trim();
                Number_of_Available = dr["Number_of_Available"].ToString().Trim();
                Note = dr["Note"].ToString().Trim();
                IsDeleted = dr["IsDeleted"].ToString().Trim();

                //sw = string.IsNullOrEmpty(sw) ? “null” : sw;
                //kr = string.IsNullOrEmpty(kr) ? “null” : kr;

                string strSql = string.Format("Insert into Parking_Space_Group(Group_Name, Parking_Space_ID" +
                    ", Car_Model, Number_of_Available,Note,IsDeleted) Values('{ 0}','{1}',{2},{3},{4},{5})",
                    Group_Name, Parking_Space_ID, Car_Model, Number_of_Available, Note, IsDeleted);
                try
                {
                    // SqlConnection sqlConnection = new SqlConnection(strConnection);
                    SqlCommand sqlCmd = new SqlCommand();
                    sqlCmd.CommandText = strSql;
                    sqlCmd.Connection = connect;
                    Connect();
                    SqlDataReader sqlDataReader = sqlCmd.ExecuteReader();
                    //i;
                    sqlDataReader.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    Connect();

                }
                //if (opdb.ExcSQL(strSql))
                //    i ;
            }
            return i;
        }
    }
}
