using System;
using System.Data.SqlClient;
using System.Data;
using BAG.CommonConstants;
using Microsoft.ApplicationBlocks.Data;
using System.Collections.Generic;
using BAG.DataObject;
using BAG.CustomObject;

namespace BAG.Contacts.DataAccess
{
    public class U_USR_ContactsDAL
    {
        private const string SQL_INSERT_U_USR_Contacts = "INSERT INTO U_USR_Contacts VALUES(@Contact_Id, @Email_Id, @Mobile_Number, @Person_Name, @Contact_Status, @Contact_Source, @Created_Date, @Updated_Date, @Created_by, @Updated_by)";
        private const string SQL_Check_Contacts = "SELECT Contact_Id from U_USR_Contacts where Email_Id=@Email_Id";
        private const string SQL_GetUser_Contacts = "SELECT c.Contact_Id,c.Email_Id,c.Person_Name,c.Mobile_Number FROM U_USR_Contacts c inner join U_USR_Map_Contact m on c.Contact_Id=m.Contact_Id where m.Usr_Id=@Contact_Id";
        private const string SQL_GetGroup_Contacts = "SELECT c.Contact_Id,c.Email_Id,c.Person_Name,c.Mobile_Number FROM U_USR_Contacts c inner join U_USR_Map_Usr_To_Contact m on c.Contact_Id=m.Contact_Id  where m.Group_Id=@Contact_Id";
        private const string SQL_Update_Contacts = "UPDATE U_USR_Contacts set  Mobile_Number=@Mobile_Number,Person_Name=@Person_Name where Contact_Id=@Contact_Id";

        private const string PARAM_Contact_Id = "@Contact_Id";
        private const string PARAM_Email_Id = "@Email_Id";
        private const string PARAM_Mobile_Number = "@Mobile_Number";
        private const string PARAM_Person_Name = "@Person_Name";
        private const string PARAM_Contact_Status = "@Contact_Status";
        private const string PARAM_Contact_Source = "@Contact_Source";
        private const string PARAM_Created_Date = "@Created_Date";
        private const string PARAM_Updated_Date = "@Updated_Date";
        private const string PARAM_Created_by = "@Created_by";
        private const string PARAM_Updated_by = "@Updated_by";
        public U_USR_ContactsDAL()
        {

        }

        public bool InsertU_USR_Contacts(U_USR_Contacts tobjU_USR_Contacts)
        {
            if (tobjU_USR_Contacts != null)
            {
                //Get the parameter list needed by the given object
                SqlParameter[] lParamArray = GetParameters(tobjU_USR_Contacts);
                SetParameters(lParamArray, tobjU_USR_Contacts);
                //Get the connection
                SqlConnection con = General.GetConnection();
                if (con == null)
                    //Connection is not created 
                    return false;
                //Execute the insertion
                int i = SqlHelper.ExecuteNonQuery(
                    con,
                    CommandType.Text,
                    SQL_INSERT_U_USR_Contacts,
                    lParamArray);
                //Dispose the Sql connection 
                con.Dispose();
                if (i == 1)
                    //Done and insert the object to the table
                    return true;
                else
                    //Fail to execute the insertion
                    return false;
            }
            else
                //No object found to insert
                return false;
        }

        public string CheckContact_Exist(string Email_Id)
        {
            SqlConnection connection = null;
            SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_Email_Id, Email_Id) };
            try
            {
                try
                {
                    connection = General.GetConnection();
                }
                catch (System.Exception e)
                {
                    Console.Write(e);
                    return string.Empty;
                }
                SqlDataReader reader = SqlHelper.ExecuteReader(connection, CommandType.Text, SQL_Check_Contacts, aParms);

                while (reader.Read())
                {
                    return reader.GetString(0);
                }
                reader.Close();
                return string.Empty;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
                return string.Empty;
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();
            }
        }

        public GoogleContacts[] GetUser_Contacts(string UserId)
        {
            SqlConnection connection = null;
            SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_Contact_Id, UserId) };
            List<GoogleContacts> olist = new List<GoogleContacts>();
            try
            {
                try
                {
                    connection = General.GetConnection();
                }
                catch (System.Exception e)
                {
                    Console.Write(e);
                    return null;
                }
                SqlDataReader reader = SqlHelper.ExecuteReader(connection, CommandType.Text, SQL_GetUser_Contacts, aParms);

                while (reader.Read())
                {
                    olist.Add(new GoogleContacts(
                        reader.GetString(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3)));
                }
                reader.Close();
                return olist.ToArray();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();
            }
        }

        public GoogleContacts[] GetGroupContacts(string GroupId)
        {
            SqlConnection connection = null;
            SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_Contact_Id, GroupId) };
            List<GoogleContacts> olist = new List<GoogleContacts>();
            try
            {
                try
                {
                    connection = General.GetConnection();
                }
                catch (System.Exception e)
                {
                    Console.Write(e);
                    return null;
                }
                SqlDataReader reader = SqlHelper.ExecuteReader(connection, CommandType.Text, SQL_GetGroup_Contacts, aParms);

                while (reader.Read())
                {
                    olist.Add(new GoogleContacts(
                        reader.GetString(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3)));
                }
                reader.Close();
                return olist.ToArray();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();
            }
        }

        public string Edit_Contact(string UserId,string Phone_No,string Name)
        {
            SqlConnection connection = null;
            SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_Contact_Id, UserId),
                new SqlParameter(PARAM_Mobile_Number, Phone_No),new SqlParameter(PARAM_Person_Name, Name) };
            try
            {
                try
                {
                    connection = General.GetConnection();
                }
                catch (System.Exception e)
                {
                    Console.Write(e);
                    return string.Empty;
                }
                int i = SqlHelper.ExecuteNonQuery(connection, CommandType.Text, SQL_Update_Contacts, aParms);
                if (i == 1)
                    //Done and insert the object to the table
                    return "1";
                else
                    //Fail to execute the insertion
                    return "";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
                return string.Empty;
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();
            }
        }

        private SqlParameter[] GetParameters(U_USR_Contacts tobjU_USR_Contacts)
        {
            SqlParameter[] objParamArray = SqlHelperParameterCache.GetCachedParameterSet(General.SQL_CONN_STRING, SQL_INSERT_U_USR_Contacts);
            if (objParamArray == null)
            {
                //Represents a parameter to a System.Data.SqlClient.SqlCommand, 
                //and optionally, its mapping to System.Data.DataSet columns. 
                objParamArray = new SqlParameter[]
                {
                new SqlParameter(PARAM_Contact_Id, tobjU_USR_Contacts.Contact_Id),
                new SqlParameter(PARAM_Email_Id, tobjU_USR_Contacts.Email_Id),
                new SqlParameter(PARAM_Mobile_Number, tobjU_USR_Contacts.Mobile_Number),
                new SqlParameter(PARAM_Person_Name, tobjU_USR_Contacts.Person_Name),
                new SqlParameter(PARAM_Contact_Status, tobjU_USR_Contacts.Contact_Status),
                new SqlParameter(PARAM_Contact_Source, tobjU_USR_Contacts.Contact_Source),
                new SqlParameter(PARAM_Created_Date, tobjU_USR_Contacts.Created_Date),
                new SqlParameter(PARAM_Updated_Date, tobjU_USR_Contacts.Updated_Date),
                new SqlParameter(PARAM_Created_by, tobjU_USR_Contacts.Created_by),
                new SqlParameter(PARAM_Updated_by, tobjU_USR_Contacts.Updated_by),
                };
                SqlHelperParameterCache.CacheParameterSet(General.SQL_CONN_STRING, SQL_INSERT_U_USR_Contacts, objParamArray);
            }
            return objParamArray;
        }

        private void SetParameters(SqlParameter[] U_USR_ContactsParms, U_USR_Contacts tobjU_USR_Contacts)
        {
            U_USR_ContactsParms[0].Value = tobjU_USR_Contacts.Contact_Id;
            U_USR_ContactsParms[1].Value = tobjU_USR_Contacts.Email_Id;
            U_USR_ContactsParms[2].Value = tobjU_USR_Contacts.Mobile_Number;
            U_USR_ContactsParms[3].Value = tobjU_USR_Contacts.Person_Name;
            U_USR_ContactsParms[4].Value = tobjU_USR_Contacts.Contact_Status;
            U_USR_ContactsParms[5].Value = tobjU_USR_Contacts.Contact_Source;
            U_USR_ContactsParms[6].Value = tobjU_USR_Contacts.Created_Date;
            U_USR_ContactsParms[7].Value = tobjU_USR_Contacts.Updated_Date;
            U_USR_ContactsParms[8].Value = tobjU_USR_Contacts.Created_by;
            U_USR_ContactsParms[9].Value = tobjU_USR_Contacts.Updated_by;
        }
    }
}