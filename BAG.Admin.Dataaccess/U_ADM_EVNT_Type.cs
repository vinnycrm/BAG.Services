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
public class U_ADM_EVNT_TypeDAL
{
    private const string SQL_SELECT_EventTypes = "SELECT Event_Type_Id,Event_Type_Name FROM U_ADM_EVNT_Type";
    private const string SQL_INSERT_U_ADM_EVNT_Type = "INSERT INTO U_ADM_EVNT_Type VALUES(@Event_Type_Id, @Event_Type_Name, @Event_Desc, @Media_Id_Img, @Created_Date, @Updated_Date, @Created_by, @Updated_by)";

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
    public bool InsertU_ADM_EVNT_Type(U_ADM_EVNT_Type tobjU_ADM_EVNT_Type)
    {
        if (tobjU_ADM_EVNT_Type != null)
        {
            //Get the parameter list needed by the given object
            SqlParameter[] lParamArray = GetParameters(tobjU_ADM_EVNT_Type);
            SetParameters(lParamArray, tobjU_ADM_EVNT_Type);
            //Get the connection
            SqlConnection con = General.GetConnection();
            if (con == null)
                //Connection is not created 
                return false;
            //Execute the insertion
            int i = SqlHelper.ExecuteNonQuery(
                con,
                CommandType.Text,
                SQL_INSERT_U_ADM_EVNT_Type,
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

    private SqlParameter[] GetParameters(U_ADM_EVNT_Type tobjU_ADM_EVNT_Type)
    {
        SqlParameter[] objParamArray = SqlHelperParameterCache.GetCachedParameterSet(General.SQL_CONN_STRING, SQL_INSERT_U_ADM_EVNT_Type);
        if (objParamArray == null)
        {
            //Represents a parameter to a System.Data.SqlClient.SqlCommand, 
            //and optionally, its mapping to System.Data.DataSet columns. 
            objParamArray = new SqlParameter[]
			{
				new SqlParameter(PARAM_Event_Type_Id, tobjU_ADM_EVNT_Type.Event_Type_Id),
				new SqlParameter(PARAM_Event_Type_Name, tobjU_ADM_EVNT_Type.Event_Type_Name),
				new SqlParameter(PARAM_Event_Desc, tobjU_ADM_EVNT_Type.Event_Desc),
				new SqlParameter(PARAM_Media_Id_Img, tobjU_ADM_EVNT_Type.Media_Id_Img),
				new SqlParameter(PARAM_Created_Date, tobjU_ADM_EVNT_Type.Created_Date),
				new SqlParameter(PARAM_Updated_Date, tobjU_ADM_EVNT_Type.Updated_Date),
				new SqlParameter(PARAM_Created_by, tobjU_ADM_EVNT_Type.Created_by),
				new SqlParameter(PARAM_Updated_by, tobjU_ADM_EVNT_Type.Updated_by),
			};
            SqlHelperParameterCache.CacheParameterSet(General.SQL_CONN_STRING, SQL_INSERT_U_ADM_EVNT_Type, objParamArray);
        }
        return objParamArray;
    }

    private void SetParameters(SqlParameter[] U_ADM_EVNT_TypeParms, U_ADM_EVNT_Type tobjU_ADM_EVNT_Type)
    {
        U_ADM_EVNT_TypeParms[0].Value = tobjU_ADM_EVNT_Type.Event_Type_Id;
        U_ADM_EVNT_TypeParms[1].Value = tobjU_ADM_EVNT_Type.Event_Type_Name;
        U_ADM_EVNT_TypeParms[2].Value = tobjU_ADM_EVNT_Type.Event_Desc;
        U_ADM_EVNT_TypeParms[3].Value = tobjU_ADM_EVNT_Type.Media_Id_Img;
        U_ADM_EVNT_TypeParms[4].Value = tobjU_ADM_EVNT_Type.Created_Date;
        U_ADM_EVNT_TypeParms[5].Value = tobjU_ADM_EVNT_Type.Updated_Date;
        U_ADM_EVNT_TypeParms[6].Value = tobjU_ADM_EVNT_Type.Created_by;
        U_ADM_EVNT_TypeParms[7].Value = tobjU_ADM_EVNT_Type.Updated_by;
    }

}
}