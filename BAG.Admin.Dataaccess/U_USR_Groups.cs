using System;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Text;
using BAG.Admin.Dataobject;
using BAG.CommonConstants;
using Microsoft.ApplicationBlocks.Data;
using System.Collections.Generic;

namespace BAG.Admin.Dataaccess
{
public class U_USR_GroupsDAL
{
	private const string SQL_INSERT_U_USR_Groups = "INSERT INTO U_USR_Groups VALUES(@Group_Id, @Usr_Id, @Group_Name, @Group_Desc, @Group_Source, @Group_Status, @Created_Date, @Updated_Date, @Created_by, @Updated_by)";
    private const string SQL_Select_U_USR_Groups = "Select Group_Id,Group_Name from U_USR_Groups where Usr_Id=@Usr_Id";
    private const string SQL_Edit_U_USR_Groups = "Update U_USR_Groups set Group_Name=@Group_Name where Group_Id=@Group_Id";
    private const string SQL_Delete_U_USR_Groups = "delete from U_USR_Map_Usr_To_Contact where Group_Id=@Group_Id Delete from U_USR_Groups where Group_Id=@Group_Id";
    private const string SQL_HisGroups = "select Group_Id, Group_Name from U_USR_Groups where Usr_Id = @Usr_Id";
    private const string SQL_JoinedGroups = "select g.Group_Id, gn.Group_Name from U_USR_Map_Usr_To_Contact as g INNER JOIN U_USR_Groups gn ON  gn.Group_Id = g.Group_Id where Contact_Id = @Usr_Id";

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

    public Groups[] GetHisGroupsDetailsDb(string id)
        {
            try
            {
                SqlConnection con = General.GetConnection();
                SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_Usr_Id, id) };
                List<Groups> groupsList = new List<Groups>();
                SqlDataReader reader = SqlHelper.ExecuteReader(con, CommandType.Text, SQL_HisGroups, aParms);
                while (reader.Read())
                {
                    groupsList.Add(new Groups(reader.GetString(0), reader.GetString(1)));
                }
                reader.Close();
                return groupsList.ToArray();
            }
            catch (Exception e)
            {
                Console.Write(e);
                return null;
            }
        }

    public Groups[] GetJoinedGroupsDetailsDb(string id)
    {
        try
        {
            SqlConnection con = General.GetConnection();
            SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_Usr_Id, id) };
            List<Groups> groupsList = new List<Groups>();
            SqlDataReader reader = SqlHelper.ExecuteReader(con, CommandType.Text, SQL_JoinedGroups, aParms);
            while (reader.Read())
            {
                groupsList.Add(new Groups(reader.GetString(0), reader.GetString(1)));
            }
            reader.Close();
            return groupsList.ToArray();
        }
        catch (Exception e)
        {
            Console.Write(e);
            return null;
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