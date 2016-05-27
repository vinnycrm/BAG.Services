using System;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Text;
using BAG.DataObject;
using BAG.CommonConstants;
using Microsoft.ApplicationBlocks.Data;

namespace BAG.Event.DataAccess
{
public class U_EVNT_WList_Pub_DAL
{
	private const string SQL_DELETE_U_EVNT_WList_Pub_Dtl = "DELETE FROM U_EVNT_WList_Pub_Dtl WHERE Id = @Id";
    private const string SQL_Update_Event_Inv = "Update U_EVNT_WList_Pub_Dtl SET Contact_Id=@Contact_Id ,WList_CodeForPub='' WHERE WList_CodeForPub = @WList_CodeForPub and Created_by!=@Contact_Id";
	private const string SQL_INSERT_U_EVNT_WList_Pub_Dtl = "INSERT INTO U_EVNT_WList_Pub_Dtl VALUES(@Id, @Event_Id, @WList_Id, @Pub_Date, @Pub_MediaType, @Pub_Status, @Contact_Id, @Email_Id, @Phone_No, @WList_CodeForPub, @Created_Date, @Updated_Date, @Created_by, @Updated_by)";
    private const string SQL_Select_U_EVNT_WList_Pub_Dtl = "Select Id  FROM U_EVNT_WList_Pub_Dtl WHERE Event_Id = @Event_Id and WList_Id=@WList_Id and Email_Id=@Email_Id";

	private const string PARAM_Id = "@Id";
	private const string PARAM_Event_Id = "@Event_Id";
	private const string PARAM_WList_Id = "@WList_Id";
	private const string PARAM_Pub_Date = "@Pub_Date";
	private const string PARAM_Pub_MediaType = "@Pub_MediaType";
	private const string PARAM_Pub_Status = "@Pub_Status";
	private const string PARAM_Contact_Id = "@Contact_Id";
	private const string PARAM_Email_Id = "@Email_Id";
	private const string PARAM_Phone_No = "@Phone_No";
	private const string PARAM_WList_CodeForPub = "@WList_CodeForPub";
	private const string PARAM_Created_Date = "@Created_Date";
	private const string PARAM_Updated_Date = "@Updated_Date";
	private const string PARAM_Created_by = "@Created_by";
	private const string PARAM_Updated_by = "@Updated_by";
	public U_EVNT_WList_Pub_DAL()
	{

	}

	public bool InsertU_EVNT_WList_Pub_Dtl(U_EVNT_WList_Pub_Dtl tobjU_EVNT_WList_Pub_Dtl)
	{
		if(tobjU_EVNT_WList_Pub_Dtl != null)
		{
			//Get the parameter list needed by the given object
			SqlParameter[] lParamArray =  GetParameters(tobjU_EVNT_WList_Pub_Dtl);
			SetParameters(lParamArray, tobjU_EVNT_WList_Pub_Dtl);
			//Get the connection
            SqlConnection con = General.GetConnection();
			if (con == null)
				//Connection is not created 
				return false;
			//Execute the insertion
			int i = SqlHelper.ExecuteNonQuery(
				con, 
				CommandType.Text, 
				SQL_INSERT_U_EVNT_WList_Pub_Dtl, 
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

    public void Update_Event_Inv(string Code, string UserId)
    {
        SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_WList_CodeForPub, Code), new SqlParameter(PARAM_Contact_Id, UserId) };
        using (SqlConnection conn = General.GetConnection())
        {
            // conn.Open();
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SQL_Update_Event_Inv, aParms);
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

    public string Get_Evnt_Inv(string EventId,string WList_Id,string Email_Id)
    {
        SqlConnection connection = null;
        SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_WList_Id, WList_Id),
        new SqlParameter(PARAM_Event_Id, EventId),new SqlParameter(PARAM_Email_Id, Email_Id)};
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
            SqlDataReader reader = SqlHelper.ExecuteReader(connection, CommandType.Text, SQL_Select_U_EVNT_WList_Pub_Dtl, aParms);

            while (reader.Read())
            {
                return reader.GetString(0);
            }
            reader.Close();
            return "" ;
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
	
	private SqlParameter[] GetParameters(U_EVNT_WList_Pub_Dtl tobjU_EVNT_WList_Pub_Dtl)
	{
		SqlParameter[] objParamArray = SqlHelperParameterCache.GetCachedParameterSet(General.SQL_CONN_STRING, SQL_INSERT_U_EVNT_WList_Pub_Dtl);
		if (objParamArray == null)
		{
			//Represents a parameter to a System.Data.SqlClient.SqlCommand, 
			//and optionally, its mapping to System.Data.DataSet columns. 
			objParamArray = new SqlParameter[]
			{
				new SqlParameter(PARAM_Id, tobjU_EVNT_WList_Pub_Dtl.Id),
				new SqlParameter(PARAM_Event_Id, tobjU_EVNT_WList_Pub_Dtl.Event_Id),
				new SqlParameter(PARAM_WList_Id, tobjU_EVNT_WList_Pub_Dtl.WList_Id),
				new SqlParameter(PARAM_Pub_Date, tobjU_EVNT_WList_Pub_Dtl.Pub_Date),
				new SqlParameter(PARAM_Pub_MediaType, tobjU_EVNT_WList_Pub_Dtl.Pub_MediaType),
				new SqlParameter(PARAM_Pub_Status, tobjU_EVNT_WList_Pub_Dtl.Pub_Status),
				new SqlParameter(PARAM_Contact_Id, tobjU_EVNT_WList_Pub_Dtl.Contact_Id),
				new SqlParameter(PARAM_Email_Id, tobjU_EVNT_WList_Pub_Dtl.Email_Id),
				new SqlParameter(PARAM_Phone_No, tobjU_EVNT_WList_Pub_Dtl.Phone_No),
				new SqlParameter(PARAM_WList_CodeForPub, tobjU_EVNT_WList_Pub_Dtl.WList_CodeForPub),
				new SqlParameter(PARAM_Created_Date, tobjU_EVNT_WList_Pub_Dtl.Created_Date),
				new SqlParameter(PARAM_Updated_Date, tobjU_EVNT_WList_Pub_Dtl.Updated_Date),
				new SqlParameter(PARAM_Created_by, tobjU_EVNT_WList_Pub_Dtl.Created_by),
				new SqlParameter(PARAM_Updated_by, tobjU_EVNT_WList_Pub_Dtl.Updated_by),
			};
            SqlHelperParameterCache.CacheParameterSet(General.SQL_CONN_STRING, SQL_INSERT_U_EVNT_WList_Pub_Dtl, objParamArray);
		}
		return objParamArray;
	}

	private void SetParameters(SqlParameter[] U_EVNT_WList_Pub_DtlParms,U_EVNT_WList_Pub_Dtl tobjU_EVNT_WList_Pub_Dtl)
	{
		U_EVNT_WList_Pub_DtlParms[0].Value = tobjU_EVNT_WList_Pub_Dtl.Id;
		U_EVNT_WList_Pub_DtlParms[1].Value = tobjU_EVNT_WList_Pub_Dtl.Event_Id;
		U_EVNT_WList_Pub_DtlParms[2].Value = tobjU_EVNT_WList_Pub_Dtl.WList_Id;
		U_EVNT_WList_Pub_DtlParms[3].Value = tobjU_EVNT_WList_Pub_Dtl.Pub_Date;
		U_EVNT_WList_Pub_DtlParms[4].Value = tobjU_EVNT_WList_Pub_Dtl.Pub_MediaType;
		U_EVNT_WList_Pub_DtlParms[5].Value = tobjU_EVNT_WList_Pub_Dtl.Pub_Status;
		U_EVNT_WList_Pub_DtlParms[6].Value = tobjU_EVNT_WList_Pub_Dtl.Contact_Id;
		U_EVNT_WList_Pub_DtlParms[7].Value = tobjU_EVNT_WList_Pub_Dtl.Email_Id;
		U_EVNT_WList_Pub_DtlParms[8].Value = tobjU_EVNT_WList_Pub_Dtl.Phone_No;
		U_EVNT_WList_Pub_DtlParms[9].Value = tobjU_EVNT_WList_Pub_Dtl.WList_CodeForPub;
		U_EVNT_WList_Pub_DtlParms[10].Value = tobjU_EVNT_WList_Pub_Dtl.Created_Date;
		U_EVNT_WList_Pub_DtlParms[11].Value = tobjU_EVNT_WList_Pub_Dtl.Updated_Date;
		U_EVNT_WList_Pub_DtlParms[12].Value = tobjU_EVNT_WList_Pub_Dtl.Created_by;
		U_EVNT_WList_Pub_DtlParms[13].Value = tobjU_EVNT_WList_Pub_Dtl.Updated_by;
	}
}
}