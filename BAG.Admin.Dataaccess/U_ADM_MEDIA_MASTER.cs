using System;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Text;
using BAG.Admin.Dataobject;
using Microsoft.ApplicationBlocks.Data;
using BAG.CommonConstants;

namespace BAG.Admin.Dataaccess
{
public class U_ADM_MEDIA_MASTERDAL
{
	private const string SQL_INSERT_U_ADM_MEDIA_MASTER = "INSERT INTO U_ADM_MEDIA_MASTER VALUES(@Media_Id, @Media_Type, @Media_File_Location, @Media_Source, @Media_Oth_Dtl, @Created_Date, @Updated_Date, @Created_by, @Updated_by)";

	private const string PARAM_Media_Id = "@Media_Id";
	private const string PARAM_Media_Type = "@Media_Type";
	private const string PARAM_Media_File_Location = "@Media_File_Location";
	private const string PARAM_Media_Source = "@Media_Source";
	private const string PARAM_Media_Oth_Dtl = "@Media_Oth_Dtl";
	private const string PARAM_Created_Date = "@Created_Date";
	private const string PARAM_Updated_Date = "@Updated_Date";
	private const string PARAM_Created_by = "@Created_by";
	private const string PARAM_Updated_by = "@Updated_by";
	public U_ADM_MEDIA_MASTERDAL()
	{
	}

	public bool InsertU_ADM_MEDIA_MASTER(U_ADM_MEDIA_MASTER tobjU_ADM_MEDIA_MASTER)
	{
		if(tobjU_ADM_MEDIA_MASTER != null)
		{
			//Get the parameter list needed by the given object
			SqlParameter[] lParamArray =  GetParameters(tobjU_ADM_MEDIA_MASTER);
			SetParameters(lParamArray, tobjU_ADM_MEDIA_MASTER);
			//Get the connection
			SqlConnection con = General.GetConnection();
			if (con == null)
				//Connection is not created 
				return false;
			//Execute the insertion
			int i = SqlHelper.ExecuteNonQuery(
				con, 
				CommandType.Text, 
				SQL_INSERT_U_ADM_MEDIA_MASTER, 
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
	
	private SqlParameter[] GetParameters(U_ADM_MEDIA_MASTER tobjU_ADM_MEDIA_MASTER)
	{
		SqlParameter[] objParamArray = SqlHelperParameterCache.GetCachedParameterSet(General.SQL_CONN_STRING, SQL_INSERT_U_ADM_MEDIA_MASTER);
		if (objParamArray == null)
		{
			//Represents a parameter to a System.Data.SqlClient.SqlCommand, 
			//and optionally, its mapping to System.Data.DataSet columns. 
			objParamArray = new SqlParameter[]
			{
				new SqlParameter(PARAM_Media_Id, tobjU_ADM_MEDIA_MASTER.Media_Id),
				new SqlParameter(PARAM_Media_Type, tobjU_ADM_MEDIA_MASTER.Media_Type),
				new SqlParameter(PARAM_Media_File_Location, tobjU_ADM_MEDIA_MASTER.Media_File_Location),
				new SqlParameter(PARAM_Media_Source, tobjU_ADM_MEDIA_MASTER.Media_Source),
				new SqlParameter(PARAM_Media_Oth_Dtl, tobjU_ADM_MEDIA_MASTER.Media_Oth_Dtl),
				new SqlParameter(PARAM_Created_Date, tobjU_ADM_MEDIA_MASTER.Created_Date),
				new SqlParameter(PARAM_Updated_Date, tobjU_ADM_MEDIA_MASTER.Updated_Date),
				new SqlParameter(PARAM_Created_by, tobjU_ADM_MEDIA_MASTER.Created_by),
				new SqlParameter(PARAM_Updated_by, tobjU_ADM_MEDIA_MASTER.Updated_by),
			};
			SqlHelperParameterCache.CacheParameterSet(General.SQL_CONN_STRING, SQL_INSERT_U_ADM_MEDIA_MASTER, objParamArray);
		}
		return objParamArray;
	}

	private void SetParameters(SqlParameter[] U_ADM_MEDIA_MASTERParms,U_ADM_MEDIA_MASTER tobjU_ADM_MEDIA_MASTER)
	{
		U_ADM_MEDIA_MASTERParms[0].Value = tobjU_ADM_MEDIA_MASTER.Media_Id;
		U_ADM_MEDIA_MASTERParms[1].Value = tobjU_ADM_MEDIA_MASTER.Media_Type;
		U_ADM_MEDIA_MASTERParms[2].Value = tobjU_ADM_MEDIA_MASTER.Media_File_Location;
		U_ADM_MEDIA_MASTERParms[3].Value = tobjU_ADM_MEDIA_MASTER.Media_Source;
		U_ADM_MEDIA_MASTERParms[4].Value = tobjU_ADM_MEDIA_MASTER.Media_Oth_Dtl;
		U_ADM_MEDIA_MASTERParms[5].Value = tobjU_ADM_MEDIA_MASTER.Created_Date;
		U_ADM_MEDIA_MASTERParms[6].Value = tobjU_ADM_MEDIA_MASTER.Updated_Date;
		U_ADM_MEDIA_MASTERParms[7].Value = tobjU_ADM_MEDIA_MASTER.Created_by;
		U_ADM_MEDIA_MASTERParms[8].Value = tobjU_ADM_MEDIA_MASTER.Updated_by;
	}

}
}