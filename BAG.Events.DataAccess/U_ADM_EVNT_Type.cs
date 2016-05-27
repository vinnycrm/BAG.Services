using System;
using System.Data.SqlClient;
using System.Data;
using BAG.CommonConstants;
using Microsoft.ApplicationBlocks.Data;
using System.Collections.Generic;
using BAG.CustomObject;

namespace BAG.Event.DataAccess
{
    public class U_ADM_EVNT_TypeDAL
{
    private const string SQL_SELECT_EventTypes = "SELECT Event_Type_Id,Event_Type_Name FROM U_ADM_EVNT_Type";

    private const string PARAM_Event_Type_Id = "@Event_Type_Id";
	private const string PARAM_Event_Type_Name = "@Event_Type_Name";
	private const string PARAM_Event_Desc = "@Event_Desc";
	private const string PARAM_Media_Id_Img = "@Media_Id_Img";
	private const string PARAM_Created_Date = "@Created_Date";
	private const string PARAM_Updated_Date = "@Updated_Date";
	private const string PARAM_Created_by = "@Created_by";
	private const string PARAM_Updated_by = "@Updated_by";
	public U_ADM_EVNT_TypeDAL()
	{

	}

	public EventTypes[] Select_EVENT_Types()
	{
		SqlConnection connection = null;
        List<EventTypes> olist = new List<EventTypes>();
		try
		{
			try
			{
				connection =  General.GetConnection();
			}
			catch (System.Exception e)
			{
                    Console.Write(e);
				return null;
			}
			SqlDataReader reader = SqlHelper.ExecuteReader(connection, CommandType.Text, SQL_SELECT_EventTypes);
	
			while (reader.Read())
			{
				olist.Add(new EventTypes(
					reader.GetString(0),
					reader.GetString(1)));
			}
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
	
	//private SqlParameter[] GetParameters(U_ADM_EVNT_Type tobjU_ADM_EVNT_Type)
	//{
	//	SqlParameter[] objParamArray = SqlHelperParameterCache.GetCachedParameterSet(SQL_CONN_STRING, SQL_INSERT_U_ADM_EVNT_Type);
	//	if (objParamArray == null)
	//	{
	//		//Represents a parameter to a System.Data.SqlClient.SqlCommand, 
	//		//and optionally, its mapping to System.Data.DataSet columns. 
	//		objParamArray = new SqlParameter[]
	//		{
	//			new SqlParameter(PARAM_Event_Type_Id, tobjU_ADM_EVNT_Type.Event_Type_Id),
	//			new SqlParameter(PARAM_Event_Type_Name, tobjU_ADM_EVNT_Type.Event_Type_Name),
	//			new SqlParameter(PARAM_Event_Desc, tobjU_ADM_EVNT_Type.Event_Desc),
	//			new SqlParameter(PARAM_Media_Id_Img, tobjU_ADM_EVNT_Type.Media_Id_Img),
	//			new SqlParameter(PARAM_Created_Date, tobjU_ADM_EVNT_Type.Created_Date),
	//			new SqlParameter(PARAM_Updated_Date, tobjU_ADM_EVNT_Type.Updated_Date),
	//			new SqlParameter(PARAM_Created_by, tobjU_ADM_EVNT_Type.Created_by),
	//			new SqlParameter(PARAM_Updated_by, tobjU_ADM_EVNT_Type.Updated_by),
	//		};
	//		SqlHelperParameterCache.CacheParameterSet(SQL_CONN_STRING, SQL_INSERT_U_ADM_EVNT_Type, objParamArray);
	//	}
	//	return objParamArray;
	//}

	//private void SetParameters(SqlParameter[] U_ADM_EVNT_TypeParms,U_ADM_EVNT_Type tobjU_ADM_EVNT_Type)
	//{
	//	U_ADM_EVNT_TypeParms[0].Value = tobjU_ADM_EVNT_Type.Event_Type_Id;
	//	U_ADM_EVNT_TypeParms[0].Value = tobjU_ADM_EVNT_Type.Event_Type_Name;
	//	U_ADM_EVNT_TypeParms[0].Value = tobjU_ADM_EVNT_Type.Event_Desc;
	//	U_ADM_EVNT_TypeParms[0].Value = tobjU_ADM_EVNT_Type.Media_Id_Img;
	//	U_ADM_EVNT_TypeParms[0].Value = tobjU_ADM_EVNT_Type.Created_Date;
	//	U_ADM_EVNT_TypeParms[0].Value = tobjU_ADM_EVNT_Type.Updated_Date;
	//	U_ADM_EVNT_TypeParms[0].Value = tobjU_ADM_EVNT_Type.Created_by;
	//	U_ADM_EVNT_TypeParms[0].Value = tobjU_ADM_EVNT_Type.Updated_by;
	//}

}
}