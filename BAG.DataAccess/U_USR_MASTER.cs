using System;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Text;
using BAG.DataObject;
using BAG.CommonConstants;
using Microsoft.ApplicationBlocks.Data;
using BAG.CustomObject;

namespace BAG.Account.DataAccess
{
public class U_USR_MASTERDAL
{
	private const string SQL_INSERT_U_USR_MASTER = "INSERT INTO U_USR_MASTER VALUES(@Usr_Id, @First_Name, @Last_Name, @Alt_Email_Id, @Gender, @Date_Of_Birth, @About_member, @Is_married, @Wed_anniversary, @Rating, @Address_Id, @Usr_Profile_Id, @Media_Id_Img, @Created_Date, @Updated_Date, @Created_by, @Updated_by)";
    private const string SQL_Select_U_USR_MASTER = "SELECT [Usr_Id],[First_Name],[Last_Name],[Email_Id],[Alt_Email_Id],l.Mobile_Number,[Gender],[Date_Of_Birth],[About_member],[Is_married],[Wed_anniversary],[Rating],[Address_Id],(select media_File_Location from U_ADM_MEDIA_MASTER where Media_Id=[Media_Id_Img]) as [Media_Id_Img],m.[Created_Date],m.[Updated_Date],m.[Created_by],m.[Updated_by],m.[Media_Id_Img] FROM [BAG].[dbo].[U_USR_MASTER] m inner join U_USR_Lgn l on m.Usr_Id=l.Usr_Mst_Id where m.Usr_Id=@Usr_Id";
    private const string SQL_Update_U_USR_MASTER = "Update U_USR_MASTER SET First_Name=@First_Name, Last_Name=@Last_Name, Alt_Email_Id=@Alt_Email_Id, Gender=@Gender, Date_Of_Birth=@Date_Of_Birth, About_member=@About_member, Is_married=@Is_married, Wed_anniversary=@Wed_anniversary, Address_Id=@Address_Id, Updated_Date=@Updated_Date, Updated_by=@Updated_by,Media_Id_Img=@Media_Id_Img where Usr_Id=@Usr_Id";

	private const string PARAM_Usr_Id = "@Usr_Id";
	private const string PARAM_First_Name = "@First_Name";
	private const string PARAM_Last_Name = "@Last_Name";
	private const string PARAM_Alt_Email_Id = "@Alt_Email_Id";
	private const string PARAM_Gender = "@Gender";
	private const string PARAM_Date_Of_Birth = "@Date_Of_Birth";
	private const string PARAM_About_member = "@About_member";
	private const string PARAM_Is_married = "@Is_married";
	private const string PARAM_Wed_anniversary = "@Wed_anniversary";
	private const string PARAM_Rating = "@Rating";
	private const string PARAM_Address_Id = "@Address_Id";
	private const string PARAM_Usr_Profile_Id = "@Usr_Profile_Id";
	private const string PARAM_Media_Id_Img = "@Media_Id_Img";
	private const string PARAM_Created_Date = "@Created_Date";
	private const string PARAM_Updated_Date = "@Updated_Date";
	private const string PARAM_Created_by = "@Created_by";
	private const string PARAM_Updated_by = "@Updated_by";
	public U_USR_MASTERDAL()
	{
	}

	public bool InsertU_USR_MASTER(U_USR_MASTER tobjU_USR_MASTER)
	{
		if(tobjU_USR_MASTER != null)
		{
			//Get the parameter list needed by the given object
			SqlParameter[] lParamArray =  GetParameters(tobjU_USR_MASTER);
			SetParameters(lParamArray, tobjU_USR_MASTER);
			//Get the connection
			SqlConnection con = General.GetConnection();
			if (con == null)
				//Connection is not created 
				return false;
			//Execute the insertion
			int i = SqlHelper.ExecuteNonQuery(
				con, 
				CommandType.Text, 
				SQL_INSERT_U_USR_MASTER, 
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

    public Profile Select_UserProfile(string User_Id)
	{
		// SqlConnection that will be used to execute the sql commands
		SqlConnection connection = null;
		SqlParameter[] aParms = new SqlParameter[]{new SqlParameter(PARAM_Usr_Id, User_Id)};
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
			SqlDataReader reader = SqlHelper.ExecuteReader(connection, CommandType.Text, SQL_Select_U_USR_MASTER, aParms);
			// read the contents of data reader and return the results:
			while (reader.Read())
			{
				return new Profile(
					reader.GetString(0),
					reader.GetString(1),
					reader.GetString(2),
					reader.GetString(3),
					reader.GetString(4),
                    reader.GetString(5),
                    reader.GetString(6),
					reader.GetDateTime(7),
					reader.GetString(8),
					reader.GetInt16(9),
					reader.GetDateTime(10),
					reader.GetString(11),
					reader.GetInt64(12).ToString(),
					reader.GetString(13),
					reader.GetDateTime(14),
					reader.GetDateTime(15),
					reader.GetString(16),
					reader.GetString(17),
                    reader.GetString(18));
			}
			// close Reader
			reader.Close();
			return null;
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

    public void Update_UserProfile(U_USR_MASTER odetails)
    {
        SqlParameter[] aParms = GetParameters(odetails);
        SetParameters(aParms, odetails);
        using (SqlConnection conn = General.GetConnection())
        {
            // conn.Open();
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SQL_Update_U_USR_MASTER, aParms);
                    trans.Commit();
                }
                catch (System.Exception e)
                {
                    Console.Write(e);
                    trans.Rollback();
                    //log.Error(lobjError, e);
                    throw;
                }
            }
        }
    }

	private SqlParameter[] GetParameters(U_USR_MASTER tobjU_USR_MASTER)
	{
		SqlParameter[] objParamArray = SqlHelperParameterCache.GetCachedParameterSet(General.SQL_CONN_STRING, SQL_INSERT_U_USR_MASTER);
		if (objParamArray == null)
		{
			//Represents a parameter to a System.Data.SqlClient.SqlCommand, 
			//and optionally, its mapping to System.Data.DataSet columns. 
			objParamArray = new SqlParameter[]
			{
				new SqlParameter(PARAM_Usr_Id, tobjU_USR_MASTER.Usr_Id),
				new SqlParameter(PARAM_First_Name, tobjU_USR_MASTER.First_Name),
				new SqlParameter(PARAM_Last_Name, tobjU_USR_MASTER.Last_Name),
				new SqlParameter(PARAM_Alt_Email_Id, tobjU_USR_MASTER.Alt_Email_Id),
				new SqlParameter(PARAM_Gender, tobjU_USR_MASTER.Gender),
				new SqlParameter(PARAM_Date_Of_Birth, tobjU_USR_MASTER.Date_Of_Birth),
				new SqlParameter(PARAM_About_member, tobjU_USR_MASTER.About_member),
				new SqlParameter(PARAM_Is_married, tobjU_USR_MASTER.Is_married),
				new SqlParameter(PARAM_Wed_anniversary, tobjU_USR_MASTER.Wed_anniversary),
				new SqlParameter(PARAM_Rating, tobjU_USR_MASTER.Rating),
				new SqlParameter(PARAM_Address_Id, tobjU_USR_MASTER.Address_Id),
				new SqlParameter(PARAM_Usr_Profile_Id, tobjU_USR_MASTER.Usr_role_Id),
				new SqlParameter(PARAM_Media_Id_Img, tobjU_USR_MASTER.Media_Id_Img),
				new SqlParameter(PARAM_Created_Date, tobjU_USR_MASTER.Created_Date),
				new SqlParameter(PARAM_Updated_Date, tobjU_USR_MASTER.Updated_Date),
				new SqlParameter(PARAM_Created_by, tobjU_USR_MASTER.Created_by),
				new SqlParameter(PARAM_Updated_by, tobjU_USR_MASTER.Updated_by),
			};
			SqlHelperParameterCache.CacheParameterSet(General.SQL_CONN_STRING, SQL_INSERT_U_USR_MASTER, objParamArray);
		}
		return objParamArray;
	}

	private void SetParameters(SqlParameter[] U_USR_MASTERParms,U_USR_MASTER tobjU_USR_MASTER)
	{
		U_USR_MASTERParms[0].Value = tobjU_USR_MASTER.Usr_Id;
		U_USR_MASTERParms[1].Value = tobjU_USR_MASTER.First_Name;
		U_USR_MASTERParms[2].Value = tobjU_USR_MASTER.Last_Name;
		U_USR_MASTERParms[3].Value = tobjU_USR_MASTER.Alt_Email_Id;
		U_USR_MASTERParms[4].Value = tobjU_USR_MASTER.Gender;
		U_USR_MASTERParms[5].Value = tobjU_USR_MASTER.Date_Of_Birth;
		U_USR_MASTERParms[6].Value = tobjU_USR_MASTER.About_member;
		U_USR_MASTERParms[7].Value = tobjU_USR_MASTER.Is_married;
		U_USR_MASTERParms[8].Value = tobjU_USR_MASTER.Wed_anniversary;
		U_USR_MASTERParms[9].Value = tobjU_USR_MASTER.Rating;
		U_USR_MASTERParms[10].Value = tobjU_USR_MASTER.Address_Id;
		U_USR_MASTERParms[11].Value = tobjU_USR_MASTER.Usr_role_Id;
		U_USR_MASTERParms[12].Value = tobjU_USR_MASTER.Media_Id_Img;
		U_USR_MASTERParms[13].Value = tobjU_USR_MASTER.Created_Date;
		U_USR_MASTERParms[14].Value = tobjU_USR_MASTER.Updated_Date;
		U_USR_MASTERParms[15].Value = tobjU_USR_MASTER.Created_by;
		U_USR_MASTERParms[16].Value = tobjU_USR_MASTER.Updated_by;
	}
}
}