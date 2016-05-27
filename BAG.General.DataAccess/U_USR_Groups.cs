using System;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Text;
using BAG.DataObject;
using BAG.CommonConstants;
using Microsoft.ApplicationBlocks.Data;
using System.Collections.Generic;
using BAG.CustomObject;

namespace BAG.Contacts.DataAccess
{
public class U_USR_GroupsDAL
{
	private const string SQL_INSERT_U_USR_Groups = "INSERT INTO U_USR_Groups VALUES(@Group_Id, @Usr_Id, @Group_Name, @Group_Desc, @Group_Source, @Group_Status, @Created_Date, @Updated_Date, @Created_by, @Updated_by)";
    private const string SQL_Select_U_USR_Groups = "Select Group_Id,Group_Name from U_USR_Groups where Usr_Id=@Usr_Id";
    private const string SQL_Edit_U_USR_Groups = "Update U_USR_Groups set Group_Name=@Group_Name where Group_Id=@Group_Id";
    private const string SQL_Delete_U_USR_Groups = "delete from U_USR_Map_Usr_To_Contact where Group_Id=@Group_Id Delete from U_USR_Groups where Group_Id=@Group_Id";

	private const string PARAM_Group_Id = "@Group_Id";
	private const string PARAM_Usr_Id = "@Usr_Id";
	private const string PARAM_Group_Name = "@Group_Name";
	private const string PARAM_Group_Desc = "@Group_Desc";
	private const string PARAM_Group_Source = "@Group_Source";
	private const string PARAM_Group_Status = "@Group_Status";
	private const string PARAM_Created_Date = "@Created_Date";
	private const string PARAM_Updated_Date = "@Updated_Date";
	private const string PARAM_Created_by = "@Created_by";
	private const string PARAM_Updated_by = "@Updated_by";
	public U_USR_GroupsDAL()
	{
		
	}
    public bool InsertU_USR_Groups(U_USR_Groups tobjU_USR_Groups)
    {
        if (tobjU_USR_Groups != null)
        {
            //Get the parameter list needed by the given object
            SqlParameter[] lParamArray = GetParameters(tobjU_USR_Groups);
            SetParameters(lParamArray, tobjU_USR_Groups);
            //Get the connection
            SqlConnection con = General.GetConnection();
            if (con == null)
                //Connection is not created 
                return false;
            //Execute the insertion
            int i = SqlHelper.ExecuteNonQuery(
                con,
                CommandType.Text,
                SQL_INSERT_U_USR_Groups,
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

    public GroupDetails[] Select_Groups(string User_Id)
    {
        SqlConnection connection = null;
        SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_Usr_Id, User_Id) };
        List<GroupDetails> olist = new List<GroupDetails>();
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
            SqlDataReader reader = SqlHelper.ExecuteReader(connection, CommandType.Text, SQL_Select_U_USR_Groups, aParms);

            while (reader.Read())
            {
                olist.Add(new GroupDetails(
                reader.GetString(0),
                reader.GetString(1)));
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

    public bool Edit_Groups(string Group_Id,string Group_Name)
    {
        SqlConnection connection = null;
        SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_Group_Id, Group_Id), new SqlParameter(PARAM_Group_Name, Group_Name) };
        List<GroupDetails> olist = new List<GroupDetails>();
        try
        {
            try
            {
                connection = General.GetConnection();
            }
            catch (System.Exception e)
            {
                    Console.Write(e);
                return false;
            }
            int i = SqlHelper.ExecuteNonQuery(connection, CommandType.Text, SQL_Edit_U_USR_Groups, aParms);

            return true;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Trace.WriteLine(ex.Message);
            return false;
        }
        finally
        {
            if (connection != null)
                connection.Dispose();
        }
    }


    public bool Delete_Group(string Id)
    {
        SqlConnection connection = null;
        SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_Group_Id, Id) };
        try
        {
            connection = General.GetConnection();
            if (connection == null)
                return false;
            // Call ExecuteNoneQuery static method of SqlHelper class that returns an Int
            // We pass in an open database connection object, command type, and command text
            int i = SqlHelper.ExecuteNonQuery(connection, CommandType.Text, SQL_Delete_U_USR_Groups, aParms);
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

    private SqlParameter[] GetParameters(U_USR_Groups tobjU_USR_Groups)
    {
        SqlParameter[] objParamArray = SqlHelperParameterCache.GetCachedParameterSet(General.SQL_CONN_STRING, SQL_INSERT_U_USR_Groups);
        if (objParamArray == null)
        {
            //Represents a parameter to a System.Data.SqlClient.SqlCommand, 
            //and optionally, its mapping to System.Data.DataSet columns. 
            objParamArray = new SqlParameter[]
			{
				new SqlParameter(PARAM_Group_Id, tobjU_USR_Groups.Group_Id),
				new SqlParameter(PARAM_Usr_Id, tobjU_USR_Groups.Usr_Id),
				new SqlParameter(PARAM_Group_Name, tobjU_USR_Groups.Group_Name),
				new SqlParameter(PARAM_Group_Desc, tobjU_USR_Groups.Group_Desc),
				new SqlParameter(PARAM_Group_Source, tobjU_USR_Groups.Group_Source),
				new SqlParameter(PARAM_Group_Status, tobjU_USR_Groups.Group_Status),
				new SqlParameter(PARAM_Created_Date, tobjU_USR_Groups.Created_Date),
				new SqlParameter(PARAM_Updated_Date, tobjU_USR_Groups.Updated_Date),
				new SqlParameter(PARAM_Created_by, tobjU_USR_Groups.Created_by),
				new SqlParameter(PARAM_Updated_by, tobjU_USR_Groups.Updated_by),
			};
            SqlHelperParameterCache.CacheParameterSet(General.SQL_CONN_STRING, SQL_INSERT_U_USR_Groups, objParamArray);
        }
        return objParamArray;
    }

    private void SetParameters(SqlParameter[] U_USR_GroupsParms, U_USR_Groups tobjU_USR_Groups)
    {
        U_USR_GroupsParms[0].Value = tobjU_USR_Groups.Group_Id;
        U_USR_GroupsParms[1].Value = tobjU_USR_Groups.Usr_Id;
        U_USR_GroupsParms[2].Value = tobjU_USR_Groups.Group_Name;
        U_USR_GroupsParms[3].Value = tobjU_USR_Groups.Group_Desc;
        U_USR_GroupsParms[4].Value = tobjU_USR_Groups.Group_Source;
        U_USR_GroupsParms[5].Value = tobjU_USR_Groups.Group_Status;
        U_USR_GroupsParms[6].Value = tobjU_USR_Groups.Created_Date;
        U_USR_GroupsParms[7].Value = tobjU_USR_Groups.Updated_Date;
        U_USR_GroupsParms[8].Value = tobjU_USR_Groups.Created_by;
        U_USR_GroupsParms[9].Value = tobjU_USR_Groups.Updated_by;
    }
}
}