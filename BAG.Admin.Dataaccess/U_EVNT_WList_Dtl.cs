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
public class U_EVNT_WList_DtlDAL
{
	private const string SQL_DELETE_U_EVNT_WList_Dtl = "DELETE FROM U_EVNT_WList_Dtl WHERE Id = @Id";
    private const string SQL_SELECT_U_EVNT_WList_Dtl = "select w.item_id,item_name,Item_Cost_Entered_ByUser,(select Media_file_location from u_adm_media_master where media_id=media_id_img) as media_id_img from U_ADM_ITEM_MASTER m inner join U_EVNT_WList_Dtl w  on m.Item_Id=w.Item_Id WHERE w.WList_Id =@WList_Id select distinct i.id,i.Email_Id,i.Phone_No,Pub_Status from U_EVNT_WList_Pub_Dtl i where WList_Id=@WList_Id";
    private const string SQL_SELECT_ISItemExist = "select [Id] from [U_EVNT_WList_Dtl] where [WList_Id]=@WList_Id and [Item_Id]=@Item_Id";
	private const string SQL_INSERT_U_EVNT_WList_Dtl = "INSERT INTO U_EVNT_WList_Dtl VALUES(@Id, @Event_Id, @WList_Id, @Item_Id, @Item_Cost_Entered_ByUser, @Created_Date, @Updated_Date, @Created_by, @Updated_by)";

	private const string PARAM_Id = "@Id";
	private const string PARAM_Event_Id = "@Event_Id";
	private const string PARAM_WList_Id = "@WList_Id";
	private const string PARAM_Item_Id = "@Item_Id";
	private const string PARAM_Item_Cost_Entered_ByUser = "@Item_Cost_Entered_ByUser";
	private const string PARAM_Created_Date = "@Created_Date";
	private const string PARAM_Updated_Date = "@Updated_Date";
	private const string PARAM_Created_by = "@Created_by";
	private const string PARAM_Updated_by = "@Updated_by";
	public U_EVNT_WList_DtlDAL()
	{
	}
	public bool InsertU_EVNT_WList_Dtl(U_EVNT_WList_Dtl tobjU_EVNT_WList_Dtl)
	{
		if(tobjU_EVNT_WList_Dtl != null)
		{
			//Get the parameter list needed by the given object
			SqlParameter[] lParamArray =  GetParameters(tobjU_EVNT_WList_Dtl);
			SetParameters(lParamArray, tobjU_EVNT_WList_Dtl);
			//Get the connection
			SqlConnection con = General.GetConnection();
			if (con == null)
				//Connection is not created 
				return false;
			//Execute the insertion
			int i = SqlHelper.ExecuteNonQuery(
				con, 
				CommandType.Text, 
				SQL_INSERT_U_EVNT_WList_Dtl, 
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


    public string IsItemExist(string wishlist_Id,string item_Id)
    {
        // SqlConnection that will be used to execute the sql commands
        SqlConnection connection = null;
        SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_WList_Id, wishlist_Id), new SqlParameter(PARAM_Item_Id, item_Id) };
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
            SqlDataReader reader = SqlHelper.ExecuteReader(connection, CommandType.Text, SQL_SELECT_ISItemExist, aParms);
            // read the contents of data reader and return the results:
            while (reader.Read())
            {
                return reader.GetString(0);
            };
            reader.Close();
            return string.Empty;
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

    /// <summary>

	public bool tcDeleteU_EVNT_WList_Dtl(string tstrId)
	{
		SqlConnection connection = null;
		SqlParameter[] aParms = new SqlParameter[]{new SqlParameter(PARAM_Id, tstrId)};
		try
		{
			connection = General.GetConnection();
			if (connection == null)
				return false;
			// Call ExecuteNoneQuery static method of SqlHelper class that returns an Int
			// We pass in an open database connection object, command type, and command text
			int i = SqlHelper.ExecuteNonQuery(connection, CommandType.Text, SQL_DELETE_U_EVNT_WList_Dtl, aParms);
			return true;
		}
		catch(Exception ex)
		{
			//lobjError = ManGoErrors.ERROR_UNKNOWN;
			System.Diagnostics.Trace.WriteLine(ex.Message);
			return false;
		}
		finally
		{
			if(connection != null)
				connection.Dispose();
		}
	}
	
	private SqlParameter[] GetParameters(U_EVNT_WList_Dtl tobjU_EVNT_WList_Dtl)
	{
		SqlParameter[] objParamArray = SqlHelperParameterCache.GetCachedParameterSet(General.SQL_CONN_STRING, SQL_INSERT_U_EVNT_WList_Dtl);
		if (objParamArray == null)
		{
			//Represents a parameter to a System.Data.SqlClient.SqlCommand, 
			//and optionally, its mapping to System.Data.DataSet columns. 
			objParamArray = new SqlParameter[]
			{
				new SqlParameter(PARAM_Id, tobjU_EVNT_WList_Dtl.Id),
				new SqlParameter(PARAM_Event_Id, tobjU_EVNT_WList_Dtl.Event_Id),
				new SqlParameter(PARAM_WList_Id, tobjU_EVNT_WList_Dtl.WList_Id),
				new SqlParameter(PARAM_Item_Id, tobjU_EVNT_WList_Dtl.Item_Id),
				new SqlParameter(PARAM_Item_Cost_Entered_ByUser, tobjU_EVNT_WList_Dtl.Item_Cost_Entered_ByUser),
				new SqlParameter(PARAM_Created_Date, tobjU_EVNT_WList_Dtl.Created_Date),
				new SqlParameter(PARAM_Updated_Date, tobjU_EVNT_WList_Dtl.Updated_Date),
				new SqlParameter(PARAM_Created_by, tobjU_EVNT_WList_Dtl.Created_by),
				new SqlParameter(PARAM_Updated_by, tobjU_EVNT_WList_Dtl.Updated_by),
			};
			SqlHelperParameterCache.CacheParameterSet(General.SQL_CONN_STRING, SQL_INSERT_U_EVNT_WList_Dtl, objParamArray);
		}
		return objParamArray;
	}

	private void SetParameters(SqlParameter[] U_EVNT_WList_DtlParms,U_EVNT_WList_Dtl tobjU_EVNT_WList_Dtl)
	{
		U_EVNT_WList_DtlParms[0].Value = tobjU_EVNT_WList_Dtl.Id;
		U_EVNT_WList_DtlParms[1].Value = tobjU_EVNT_WList_Dtl.Event_Id;
		U_EVNT_WList_DtlParms[2].Value = tobjU_EVNT_WList_Dtl.WList_Id;
		U_EVNT_WList_DtlParms[3].Value = tobjU_EVNT_WList_Dtl.Item_Id;
		U_EVNT_WList_DtlParms[4].Value = tobjU_EVNT_WList_Dtl.Item_Cost_Entered_ByUser;
		U_EVNT_WList_DtlParms[5].Value = tobjU_EVNT_WList_Dtl.Created_Date;
		U_EVNT_WList_DtlParms[6].Value = tobjU_EVNT_WList_Dtl.Updated_Date;
		U_EVNT_WList_DtlParms[7].Value = tobjU_EVNT_WList_Dtl.Created_by;
		U_EVNT_WList_DtlParms[8].Value = tobjU_EVNT_WList_Dtl.Updated_by;
	}

}
}