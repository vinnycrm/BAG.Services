using System;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Text;
using BAG.Admin.Dataobject;
using BAG.CommonConstants;
using Microsoft.ApplicationBlocks.Data;

namespace BAG.Admin.Dataaccess
{
public class U_USR_Map_Usr_To_ContactDAL
{
    private const string SQL_INSERT_U_USR_Map_Usr_To_Contact = "INSERT INTO U_USR_Map_Usr_To_Contact VALUES(@UsrMap_Seq_Id, @Usr_Id, @Contact_Id, @Group_Id, @Comments, @Created_Date, @Updated_Date, @Created_by, @Updated_by)";
    private const string SQL_Delete_Map_Id = "Delete from U_USR_Map_Usr_To_Contact where Group_Id=@Group_Id and Contact_Id=@Contact_Id";
    private const string SQL_Map_Id_IsExists = "Select UsrMap_Seq_Id from U_USR_Map_Usr_To_Contact where Group_Id=@Group_Id and Contact_Id=@Contact_Id";

	private const string PARAM_UsrMap_Seq_Id = "@UsrMap_Seq_Id";
	private const string PARAM_Usr_Id = "@Usr_Id";
	private const string PARAM_Contact_Id = "@Contact_Id";
	private const string PARAM_Group_Id = "@Group_Id";
	private const string PARAM_Comments = "@Comments";
	private const string PARAM_Created_Date = "@Created_Date";
	private const string PARAM_Updated_Date = "@Updated_Date";
	private const string PARAM_Created_by = "@Created_by";
	private const string PARAM_Updated_by = "@Updated_by";
	public U_USR_Map_Usr_To_ContactDAL()
	{

	}
	
	public bool InsertU_USR_Map_Usr_To_Contact(U_USR_Map_Usr_To_Contact tobjU_USR_Map_Usr_To_Contact)
	{
		if(tobjU_USR_Map_Usr_To_Contact != null)
		{
			//Get the parameter list needed by the given object
			SqlParameter[] lParamArray =  GetParameters(tobjU_USR_Map_Usr_To_Contact);
			SetParameters(lParamArray, tobjU_USR_Map_Usr_To_Contact);
			//Get the connection
			SqlConnection con = General.GetConnection();
			if (con == null)
				//Connection is not created 
				return false;
			//Execute the insertion
			int i = SqlHelper.ExecuteNonQuery(
				con, 
				CommandType.Text, 
				SQL_INSERT_U_USR_Map_Usr_To_Contact, 
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

    public string IsGroupContact_Exist(string Group_Id, string Contact_Id)
    {
        SqlConnection connection = null;
        SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_Group_Id, Group_Id), new SqlParameter(PARAM_Contact_Id, Contact_Id) };
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
            SqlDataReader reader = SqlHelper.ExecuteReader(connection, CommandType.Text, SQL_Map_Id_IsExists,aParms);

            while (reader.Read())
            {
                return reader.GetString(0);
            }
            reader.Close();
            return "";
        }
        catch (Exception ex)
        {
            //lobjError = ManGoErrors.ERROR_UNKNOWN;
            System.Diagnostics.Trace.WriteLine(ex.Message);
            return "";
        }
        finally
        {
            if (connection != null)
                connection.Dispose();
        }
    }

    public bool Delete_GroupContact(string Group_Id, string Contact_Id)
    {
        SqlConnection connection = null;
        SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_Group_Id, Group_Id), new SqlParameter(PARAM_Contact_Id, Contact_Id) };
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
	
	private SqlParameter[] GetParameters(U_USR_Map_Usr_To_Contact tobjU_USR_Map_Usr_To_Contact)
	{
		SqlParameter[] objParamArray = SqlHelperParameterCache.GetCachedParameterSet(General.SQL_CONN_STRING, SQL_INSERT_U_USR_Map_Usr_To_Contact);
		if (objParamArray == null)
		{
			//Represents a parameter to a System.Data.SqlClient.SqlCommand, 
			//and optionally, its mapping to System.Data.DataSet columns. 
			objParamArray = new SqlParameter[]
			{
				new SqlParameter(PARAM_UsrMap_Seq_Id, tobjU_USR_Map_Usr_To_Contact.UsrMap_Seq_Id),
				new SqlParameter(PARAM_Usr_Id, tobjU_USR_Map_Usr_To_Contact.Usr_Id),
				new SqlParameter(PARAM_Contact_Id, tobjU_USR_Map_Usr_To_Contact.Contact_Id),
				new SqlParameter(PARAM_Group_Id, tobjU_USR_Map_Usr_To_Contact.Group_Id),
				new SqlParameter(PARAM_Comments, tobjU_USR_Map_Usr_To_Contact.Comments),
				new SqlParameter(PARAM_Created_Date, tobjU_USR_Map_Usr_To_Contact.Created_Date),
				new SqlParameter(PARAM_Updated_Date, tobjU_USR_Map_Usr_To_Contact.Updated_Date),
				new SqlParameter(PARAM_Created_by, tobjU_USR_Map_Usr_To_Contact.Created_by),
				new SqlParameter(PARAM_Updated_by, tobjU_USR_Map_Usr_To_Contact.Updated_by),
			};
			SqlHelperParameterCache.CacheParameterSet(General.SQL_CONN_STRING, SQL_INSERT_U_USR_Map_Usr_To_Contact, objParamArray);
		}
		return objParamArray;
	}
	
	private void SetParameters(SqlParameter[] U_USR_Map_Usr_To_ContactParms,U_USR_Map_Usr_To_Contact tobjU_USR_Map_Usr_To_Contact)
	{
		U_USR_Map_Usr_To_ContactParms[0].Value = tobjU_USR_Map_Usr_To_Contact.UsrMap_Seq_Id;
		U_USR_Map_Usr_To_ContactParms[1].Value = tobjU_USR_Map_Usr_To_Contact.Usr_Id;
		U_USR_Map_Usr_To_ContactParms[2].Value = tobjU_USR_Map_Usr_To_Contact.Contact_Id;
		U_USR_Map_Usr_To_ContactParms[3].Value = tobjU_USR_Map_Usr_To_Contact.Group_Id;
		U_USR_Map_Usr_To_ContactParms[4].Value = tobjU_USR_Map_Usr_To_Contact.Comments;
		U_USR_Map_Usr_To_ContactParms[5].Value = tobjU_USR_Map_Usr_To_Contact.Created_Date;
		U_USR_Map_Usr_To_ContactParms[6].Value = tobjU_USR_Map_Usr_To_Contact.Updated_Date;
		U_USR_Map_Usr_To_ContactParms[7].Value = tobjU_USR_Map_Usr_To_Contact.Created_by;
		U_USR_Map_Usr_To_ContactParms[8].Value = tobjU_USR_Map_Usr_To_Contact.Updated_by;
	}
}
}