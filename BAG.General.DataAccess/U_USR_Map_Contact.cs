using System;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Text;
using BAG.DataObject;
using BAG.CommonConstants;
using Microsoft.ApplicationBlocks.Data;

namespace BAG.Contacts.DataAccess
{
public class U_USR_Map_ContactDAL
{
	private const string SQL_INSERT_U_USR_Map_Contact = "INSERT INTO U_USR_Map_Contact VALUES(@Id, @Usr_Id, @Contact_Id, @Comments, @Created_Date, @Updated_Date, @Created_by, @Updated_by)";
    private const string SQL_Select_Map_Id = "SELECT Id from U_USR_Map_Contact  where Usr_Id=@Usr_Id and Contact_Id=@Contact_Id";
    private const string SQL_Delete_Map_Id = "Delete from U_USR_Map_Contact where Usr_Id=@Usr_Id and Contact_Id=@Contact_Id";

    private const string PARAM_Id = "@Id";
	private const string PARAM_Usr_Id = "@Usr_Id";
	private const string PARAM_Contact_Id = "@Contact_Id";
	private const string PARAM_Comments = "@Comments";
	private const string PARAM_Created_Date = "@Created_Date";
	private const string PARAM_Updated_Date = "@Updated_Date";
	private const string PARAM_Created_by = "@Created_by";
	private const string PARAM_Updated_by = "@Updated_by";
	public U_USR_Map_ContactDAL()
	{

	}

	public bool InsertU_USR_Map_Contact(U_USR_Map_Contact tobjU_USR_Map_Contact)
	{
		if(tobjU_USR_Map_Contact != null)
		{
			//Get the parameter list needed by the given object
			SqlParameter[] lParamArray =  GetParameters(tobjU_USR_Map_Contact);
			SetParameters(lParamArray, tobjU_USR_Map_Contact);
			//Get the connection
			SqlConnection con = General.GetConnection();
			if (con == null)
				//Connection is not created 
				return false;
			//Execute the insertion
			int i = SqlHelper.ExecuteNonQuery(
				con, 
				CommandType.Text, 
				SQL_INSERT_U_USR_Map_Contact, 
				lParamArray);
			//Dispose the Sql connection 
			con.Dispose();
			if (i ==1)
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


        public string CheckMaping_Exist(string UserId,string contactId)
        {
            SqlConnection connection = null;
            SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_Usr_Id, UserId),
            new SqlParameter(PARAM_Contact_Id, contactId)};
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
                SqlDataReader reader = SqlHelper.ExecuteReader(connection, CommandType.Text, SQL_Select_Map_Id, aParms);

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

        public bool Delete_UserContact(string User_Id,string Contact_Id)
        {
            SqlConnection connection = null;
            SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_Usr_Id, User_Id), new SqlParameter(PARAM_Contact_Id, Contact_Id) };
            try
            {
                connection = General.GetConnection();
                if (connection == null)
                    return false;
                // Call ExecuteNoneQuery static method of SqlHelper class that returns an Int
                // We pass in an open database connection object, command type, and command text
                int i = SqlHelper.ExecuteNonQuery(connection, CommandType.Text, SQL_Delete_Map_Id, aParms);
                return true;
            }
            catch (Exception ex)
            {
                //lobjError = ManGoErrors.ERROR_UNKNOWN;
                System.Diagnostics.Trace.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();
            }
        }


        private SqlParameter[] GetParameters(U_USR_Map_Contact tobjU_USR_Map_Contact)
	{
		SqlParameter[] objParamArray = SqlHelperParameterCache.GetCachedParameterSet(General.SQL_CONN_STRING, SQL_INSERT_U_USR_Map_Contact);
		if (objParamArray == null)
		{
			//Represents a parameter to a System.Data.SqlClient.SqlCommand, 
			//and optionally, its mapping to System.Data.DataSet columns. 
			objParamArray = new SqlParameter[]
			{
				new SqlParameter(PARAM_Id, tobjU_USR_Map_Contact.Id),
				new SqlParameter(PARAM_Usr_Id, tobjU_USR_Map_Contact.Usr_Id),
				new SqlParameter(PARAM_Contact_Id, tobjU_USR_Map_Contact.Contact_Id),
				new SqlParameter(PARAM_Comments, tobjU_USR_Map_Contact.Comments),
				new SqlParameter(PARAM_Created_Date, tobjU_USR_Map_Contact.Created_Date),
				new SqlParameter(PARAM_Updated_Date, tobjU_USR_Map_Contact.Updated_Date),
				new SqlParameter(PARAM_Created_by, tobjU_USR_Map_Contact.Created_by),
				new SqlParameter(PARAM_Updated_by, tobjU_USR_Map_Contact.Updated_by),
			};
			SqlHelperParameterCache.CacheParameterSet(General.SQL_CONN_STRING, SQL_INSERT_U_USR_Map_Contact, objParamArray);
		}
		return objParamArray;
	}
	
	private void SetParameters(SqlParameter[] U_USR_Map_ContactParms,U_USR_Map_Contact tobjU_USR_Map_Contact)
	{
		U_USR_Map_ContactParms[0].Value = tobjU_USR_Map_Contact.Id;
		U_USR_Map_ContactParms[1].Value = tobjU_USR_Map_Contact.Usr_Id;
		U_USR_Map_ContactParms[2].Value = tobjU_USR_Map_Contact.Contact_Id;
		U_USR_Map_ContactParms[3].Value = tobjU_USR_Map_Contact.Comments;
		U_USR_Map_ContactParms[4].Value = tobjU_USR_Map_Contact.Created_Date;
		U_USR_Map_ContactParms[5].Value = tobjU_USR_Map_Contact.Updated_Date;
		U_USR_Map_ContactParms[6].Value = tobjU_USR_Map_Contact.Created_by;
		U_USR_Map_ContactParms[7].Value = tobjU_USR_Map_Contact.Updated_by;
	}
	
}
}