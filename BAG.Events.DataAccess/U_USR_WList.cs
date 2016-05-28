using System;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Text;
using BAG.DataObject;
using BAG.CommonConstants;
using Microsoft.ApplicationBlocks.Data;
using System.Collections.Generic;

namespace BAG.Event.DataAccess
{
public class U_USR_WListDAL
{
    private const string SQL_SELECT_U_USR_WList = "SELECT [WList_Id],[WList_Name] FROM U_USR_WList WHERE Event_Id = @Event_Id";
    private const string SQL_SELECT_U_CNT_WList = "SELECT w.[WList_Id],[WList_Name] FROM U_USR_WList w inner join U_EVNT_WList_Pub_Dtl p on w.WList_Id=p.WList_Id where Contact_Id=@Event_Creator_Id and p.Event_Id=@Event_Id";
	private const string SQL_INSERT_U_USR_WList = "INSERT INTO U_USR_WList VALUES(@WList_Id, @Event_Id, @Event_Creator_Id, @WList_Name, @WList_Status, @Media_Id_Img, @Comments, @Created_Date, @Updated_Date, @Created_by, @Updated_by)";
    private const string SQL_DELETE_U_USR_WList = "delete from U_EVNT_WList_Dtl where WList_Id=@WList_Id DELETE U_USR_WList WHERE WList_Id = @WList_Id";
    private const string SQL_UPDATE_U_USR_WList = "UPDATE U_USR_WList SET WList_Name=@WList_Name WHERE WList_Id = @WList_Id";

	private const string PARAM_WList_Id = "@WList_Id";
	private const string PARAM_Event_Id = "@Event_Id";
	private const string PARAM_Event_Creator_Id = "@Event_Creator_Id";
	private const string PARAM_WList_Name = "@WList_Name";
	private const string PARAM_WList_Status = "@WList_Status";
	private const string PARAM_Media_Id_Img = "@Media_Id_Img";
	private const string PARAM_Comments = "@Comments";
	private const string PARAM_Created_Date = "@Created_Date";
	private const string PARAM_Updated_Date = "@Updated_Date";
	private const string PARAM_Created_by = "@Created_by";
	private const string PARAM_Updated_by = "@Updated_by";
	public U_USR_WListDAL()
	{

	}

	public bool InsertU_USR_WList(U_USR_WList tobjU_USR_WList)
	{
		if(tobjU_USR_WList != null)
		{
			//Get the parameter list needed by the given object
			SqlParameter[] lParamArray =  GetParameters(tobjU_USR_WList);
			SetParameters(lParamArray, tobjU_USR_WList);
			//Get the connection
			SqlConnection con = General.GetConnection();
			if (con == null)
				//Connection is not created 
				return false;
			//Execute the insertion
			int i = SqlHelper.ExecuteNonQuery(
				con, 
				CommandType.Text, 
				SQL_INSERT_U_USR_WList, 
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

	public WishList[] SelectU_USR_WList(string event_id)
	{
		// SqlConnection that will be used to execute the sql commands
		SqlConnection connection = null;
        SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_Event_Id, event_id) };
        List<WishList> olist = new List<WishList>();
		try
		{
			try
			{
				connection = General.GetConnection();
			}
			catch (System.Exception e)
			{
                Console.Write(e);
				//lobjError = ManGoErrors.ERROR_CONNECT_TO_DB;
				//log.Error(lobjError, e);
				return null;
			}
			// Call ExecuteDataReader static method of SqlHelper class that returns an DataReader
			// We pass in an open database connection object, command type, and command text
			SqlDataReader reader = SqlHelper.ExecuteReader(connection, CommandType.Text, SQL_SELECT_U_USR_WList, aParms);
			// read the contents of data reader and return the results:
			while (reader.Read())
			{
				olist.Add(new WishList(
					reader.GetString(0),
					reader.GetString(1)));
			}
			// close Reader
			reader.Close();
			return olist.ToArray();
		}
		catch(Exception ex)
		{
			//lobjError = ManGoErrors.ERROR_UNKNOWN;
			System.Diagnostics.Trace.WriteLine(ex.Message);
			return null;
		}
		finally
		{
			if(connection != null)
				connection.Dispose();
		}
	}

    public WishList[] SelectU_CNT_WList(string event_id,string UserId)
    {
        // SqlConnection that will be used to execute the sql commands
        SqlConnection connection = null;
        SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_Event_Id, event_id), new SqlParameter(PARAM_Event_Creator_Id, UserId) };
        List<WishList> olist = new List<WishList>();
        try
        {
            try
            {
                connection = General.GetConnection();
            }
            catch (System.Exception e)
            {
                Console.Write(e);
                //lobjError = ManGoErrors.ERROR_CONNECT_TO_DB;
                //log.Error(lobjError, e);
                return null;
            }
            // Call ExecuteDataReader static method of SqlHelper class that returns an DataReader
            // We pass in an open database connection object, command type, and command text
            SqlDataReader reader = SqlHelper.ExecuteReader(connection, CommandType.Text, SQL_SELECT_U_CNT_WList, aParms);
            // read the contents of data reader and return the results:
            while (reader.Read())
            {
                olist.Add(new WishList(
                    reader.GetString(0),
                    reader.GetString(1)));
            }
            // close Reader
            reader.Close();
            return olist.ToArray();
        }
        catch (Exception ex)
        {
            //lobjError = ManGoErrors.ERROR_UNKNOWN;
            System.Diagnostics.Trace.WriteLine(ex.Message);
            return null;
        }
        finally
        {
            if (connection != null)
                connection.Dispose();
        }
    }

    public void Update_WishlistName(string wishlist_Id, string Name)
    {
        SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_WList_Id, wishlist_Id), new SqlParameter(PARAM_WList_Name, Name) };
        using (SqlConnection conn = General.GetConnection())
        {
            // conn.Open();
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SQL_UPDATE_U_USR_WList, aParms);
                    trans.Commit();
                }
                catch (System.Exception e)
                {
                    trans.Rollback();
                    System.Diagnostics.Trace.WriteLine(e.Message);
                    throw;
                }
            }
        }
    }

    public bool Delete_Wishlist(string Id)
    {
        SqlConnection connection = null;
        SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_WList_Id, Id) };
        try
        {
            connection = General.GetConnection();
            if (connection == null)
                return false;
            // Call ExecuteNoneQuery static method of SqlHelper class that returns an Int
            // We pass in an open database connection object, command type, and command text
            int i = SqlHelper.ExecuteNonQuery(connection, CommandType.Text, SQL_DELETE_U_USR_WList, aParms);
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
	
	private SqlParameter[] GetParameters(U_USR_WList tobjU_USR_WList)
	{
		SqlParameter[] objParamArray = SqlHelperParameterCache.GetCachedParameterSet(General.SQL_CONN_STRING, SQL_INSERT_U_USR_WList);
		if (objParamArray == null)
		{
			//Represents a parameter to a System.Data.SqlClient.SqlCommand, 
			//and optionally, its mapping to System.Data.DataSet columns. 
			objParamArray = new SqlParameter[]
			{
				new SqlParameter(PARAM_WList_Id, tobjU_USR_WList.WList_Id),
				new SqlParameter(PARAM_Event_Id, tobjU_USR_WList.Event_Id),
				new SqlParameter(PARAM_Event_Creator_Id, tobjU_USR_WList.Event_Creator_Id),
				new SqlParameter(PARAM_WList_Name, tobjU_USR_WList.WList_Name),
				new SqlParameter(PARAM_WList_Status, tobjU_USR_WList.WList_Status),
				new SqlParameter(PARAM_Media_Id_Img, tobjU_USR_WList.Media_Id_Img),
				new SqlParameter(PARAM_Comments, tobjU_USR_WList.Comments),
				new SqlParameter(PARAM_Created_Date, tobjU_USR_WList.Created_Date),
				new SqlParameter(PARAM_Updated_Date, tobjU_USR_WList.Updated_Date),
				new SqlParameter(PARAM_Created_by, tobjU_USR_WList.Created_by),
				new SqlParameter(PARAM_Updated_by, tobjU_USR_WList.Updated_by),
			};
			SqlHelperParameterCache.CacheParameterSet(General.SQL_CONN_STRING, SQL_INSERT_U_USR_WList, objParamArray);
		}
		return objParamArray;
	}

	private void SetParameters(SqlParameter[] U_USR_WListParms,U_USR_WList tobjU_USR_WList)
	{
		U_USR_WListParms[0].Value = tobjU_USR_WList.WList_Id;
		U_USR_WListParms[1].Value = tobjU_USR_WList.Event_Id;
		U_USR_WListParms[2].Value = tobjU_USR_WList.Event_Creator_Id;
		U_USR_WListParms[3].Value = tobjU_USR_WList.WList_Name;
		U_USR_WListParms[4].Value = tobjU_USR_WList.WList_Status;
		U_USR_WListParms[5].Value = tobjU_USR_WList.Media_Id_Img;
		U_USR_WListParms[6].Value = tobjU_USR_WList.Comments;
		U_USR_WListParms[7].Value = tobjU_USR_WList.Created_Date;
		U_USR_WListParms[8].Value = tobjU_USR_WList.Updated_Date;
		U_USR_WListParms[9].Value = tobjU_USR_WList.Created_by;
		U_USR_WListParms[10].Value = tobjU_USR_WList.Updated_by;
	}
}
}