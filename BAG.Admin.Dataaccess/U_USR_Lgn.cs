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
public class U_USR_LgnDAL
{
    private const string SQL_Check_Email_Id = "SELECT Login_Id FROM U_USR_Lgn WHERE Email_ID = @Email_ID";
    private const string SQL_Check_Login_Id = "SELECT m.Usr_Id FROM U_USR_MASTER m inner join U_USR_Lgn l on m.Usr_Id=l.Usr_Mst_Id WHERE l.Login_Id = @Login_Id";
    private const string SQL_Activate_Member = "UPDATE U_USR_Lgn SET Login_status='1' WHERE Login_Id = @Login_Id";
    private const string SQL_Select_Login_Details = "SELECT m.Usr_Id,m.First_Name FROM U_USR_Lgn l inner join U_USR_MASTER m on l.Usr_Mst_Id=m.Usr_Id WHERE l.Email_ID = @Email_ID AND l.Pwd=@Pwd";
	private const string SQL_INSERT_U_USR_Lgn = "INSERT INTO U_USR_Lgn VALUES(@Login_Id, @Usr_Mst_Id, @Email_ID, @Mobile_Number, @Pwd, @Last_Login_Date, @Ip_Address, @Login_status, @Created_Date, @Updated_Date, @Created_by, @Updated_by)";
    private const string SQL_Change_Password = "UPDATE U_USR_Lgn SET Pwd=@Pwd WHERE Usr_Mst_Id = @Usr_Mst_Id AND Pwd=@Login_Id";
    private const string SQL_Reset_Password = "UPDATE U_USR_Lgn SET Pwd=@Pwd WHERE Login_Id=@Login_Id";
    private const string SQL_Update_Mob_Status = "UPDATE U_USR_Lgn SET Mobile_Number=@Mobile_Number, Login_status@Login_status, Updated_Date=@Updated_Date, Updated_by=@Updated_by WHERE Login_Id=@Login_Id";

    private const string PARAM_Login_Id = "@Login_Id";
	private const string PARAM_Usr_Mst_Id = "@Usr_Mst_Id";
	private const string PARAM_Email_ID = "@Email_ID";
	private const string PARAM_Mobile_Number = "@Mobile_Number";
	private const string PARAM_Pwd = "@Pwd";
	private const string PARAM_Last_Login_Date = "@Last_Login_Date";
	private const string PARAM_Ip_Address = "@Ip_Address";
	private const string PARAM_Login_status = "@Login_status";
	private const string PARAM_Created_Date = "@Created_Date";
	private const string PARAM_Updated_Date = "@Updated_Date";
	private const string PARAM_Created_by = "@Created_by";
	private const string PARAM_Updated_by = "@Updated_by";
	
	public U_USR_LgnDAL()
	{
		
	}
	
	public bool InsertU_USR_Lgn(U_USR_Lgn tobjU_USR_Lgn)
	{
		if(tobjU_USR_Lgn != null)
		{
			//Get the parameter list needed by the given object
			SqlParameter[] lParamArray =  GetParameters(tobjU_USR_Lgn);
			SetParameters(lParamArray, tobjU_USR_Lgn);
			//Get the connection
            SqlConnection con = General.GetConnection();
			if (con == null)
				//Connection is not created 
				return false;
			//Execute the insertion
			int i = SqlHelper.ExecuteNonQuery(
				con, 
				CommandType.Text, 
				SQL_INSERT_U_USR_Lgn, 
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
	
	public string CheckEmail_Exist(string Email_Id)
	{
		SqlConnection connection = null;
        SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_Email_ID, Email_Id) };
		try
		{
			try
			{
                connection = General.GetConnection();
			}
			catch (System.Exception e)
			{
                    Console.Write(e);
				return string.Empty;
			}
            SqlDataReader reader = SqlHelper.ExecuteReader(connection, CommandType.Text, SQL_Check_Email_Id, aParms);
		
			while (reader.Read())
			{
                return reader.GetString(0);
			}
			reader.Close();
			return string.Empty;
		}
		catch(Exception ex)
		{
			System.Diagnostics.Trace.WriteLine(ex.Message);
            return string.Empty;
		}
		finally
		{
			if(connection != null)
				connection.Dispose();
		}
	}

    public string CheckLoginId_Exist(string Login_Id)
    {
        SqlConnection connection = null;
        SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_Login_Id, Login_Id) };
        try
        {
            try
            {
                connection = General.GetConnection();
            }
            catch (System.Exception e)
            {
                    Console.Write(e);
                    return string.Empty;
            }
            SqlDataReader reader = SqlHelper.ExecuteReader(connection, CommandType.Text, SQL_Check_Login_Id, aParms);

            while (reader.Read())
            {
                return reader.GetString(0);
            }
            reader.Close();
            return string.Empty;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Trace.WriteLine(ex.Message);
            return string.Empty;
        }
        finally
        {
            if (connection != null)
                connection.Dispose();
        }
    }

    public U_ADMIN_Login_Ref GetLoginDetails(string Email_Id, string Password)
        {
            SqlConnection connection = null;
            U_ADMIN_Login_Ref loginDetails = new U_ADMIN_Login_Ref();
            SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_Email_ID, Email_Id), new SqlParameter(PARAM_Pwd, Password) };
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
                SqlDataReader reader = SqlHelper.ExecuteReader(connection, CommandType.Text, SQL_Select_Login_Details, aParms);

                while (reader.Read())
                {
                    return new U_ADMIN_Login_Ref(
                            reader.GetString(0),
                            reader.GetString(1));
                }
                reader.Close();
                return null;
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

    public void ActivateMember(string Login_Id)
    {
        SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_Login_Id, Login_Id) };
        using (SqlConnection conn = General.GetConnection())
        {
            // conn.Open();
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SQL_Activate_Member, aParms);
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

    public int ChangePassword(string User_Id,string Pwd,string old_Pwd)
    {
        SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_Usr_Mst_Id, User_Id), new SqlParameter(PARAM_Pwd, Pwd),
        new SqlParameter(PARAM_Login_Id,old_Pwd)};
        using (SqlConnection conn = General.GetConnection())
        {
            // conn.Open();
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                   int i= SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SQL_Change_Password, aParms);
                    trans.Commit();
                    return i;
                }
                catch (System.Exception e)
                {
                        Console.Write(e);
                        trans.Rollback();
                    return 0;
                }
            }
        }
    }

    public int ResetPassword(string User_Id, string Pwd)
    {
        SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_Login_Id, User_Id), new SqlParameter(PARAM_Pwd, Pwd)};
        using (SqlConnection conn = General.GetConnection())
        {
            // conn.Open();
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    int i = SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SQL_Reset_Password, aParms);
                    trans.Commit();
                    return i;
                }
                catch (System.Exception e)
                {
                        Console.Write(e);
                        trans.Rollback();
                    return 0;
                }
            }
        }
    }

    public bool UpdateMobileStatusDb(string id,string Mob, int status, DateTime UpDate, string UpBy)
        {
            SqlParameter[] aParms = new SqlParameter[] {
                new SqlParameter(PARAM_Usr_Mst_Id, id),
                new SqlParameter(PARAM_Mobile_Number, Mob),
                new SqlParameter(PARAM_Login_status,status),
                new SqlParameter(PARAM_Updated_Date,UpDate),
                new SqlParameter(PARAM_Updated_by,UpBy)};

            using (SqlConnection conn = General.GetConnection())
            {
                // conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        int i = SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SQL_Update_Mob_Status, aParms);
                        trans.Commit();
                        return true;
                    }
                    catch (System.Exception e)
                    {
                        Console.Write(e);
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }
	
	private SqlParameter[] GetParameters(U_USR_Lgn tobjU_USR_Lgn)
	{
        SqlParameter[] objParamArray = SqlHelperParameterCache.GetCachedParameterSet(General.SQL_CONN_STRING, SQL_INSERT_U_USR_Lgn);
		if (objParamArray == null)
		{
			//Represents a parameter to a System.Data.SqlClient.SqlCommand, 
			//and optionally, its mapping to System.Data.DataSet columns. 
			objParamArray = new SqlParameter[]
			{
				new SqlParameter(PARAM_Login_Id, tobjU_USR_Lgn.Login_Id),
				new SqlParameter(PARAM_Usr_Mst_Id, tobjU_USR_Lgn.Usr_Mst_Id),
				new SqlParameter(PARAM_Email_ID, tobjU_USR_Lgn.Email_ID),
				new SqlParameter(PARAM_Mobile_Number, tobjU_USR_Lgn.Mobile_Number),
				new SqlParameter(PARAM_Pwd, tobjU_USR_Lgn.Pwd),
				new SqlParameter(PARAM_Last_Login_Date, tobjU_USR_Lgn.Last_Login_Date),
				new SqlParameter(PARAM_Ip_Address, tobjU_USR_Lgn.Ip_Address),
				new SqlParameter(PARAM_Login_status, tobjU_USR_Lgn.Login_status),
				new SqlParameter(PARAM_Created_Date, tobjU_USR_Lgn.Created_Date),
				new SqlParameter(PARAM_Updated_Date, tobjU_USR_Lgn.Updated_Date),
				new SqlParameter(PARAM_Created_by, tobjU_USR_Lgn.Created_by),
				new SqlParameter(PARAM_Updated_by, tobjU_USR_Lgn.Updated_by),
			};
            SqlHelperParameterCache.CacheParameterSet(General.SQL_CONN_STRING, SQL_INSERT_U_USR_Lgn, objParamArray);
		}
		return objParamArray;
	}
	
	private void SetParameters(SqlParameter[] U_USR_LgnParms,U_USR_Lgn tobjU_USR_Lgn)
	{
		U_USR_LgnParms[0].Value = tobjU_USR_Lgn.Login_Id;
		U_USR_LgnParms[1].Value = tobjU_USR_Lgn.Usr_Mst_Id;
		U_USR_LgnParms[2].Value = tobjU_USR_Lgn.Email_ID;
		U_USR_LgnParms[3].Value = tobjU_USR_Lgn.Mobile_Number;
		U_USR_LgnParms[4].Value = tobjU_USR_Lgn.Pwd;
		U_USR_LgnParms[5].Value = tobjU_USR_Lgn.Last_Login_Date;
		U_USR_LgnParms[6].Value = tobjU_USR_Lgn.Ip_Address;
		U_USR_LgnParms[7].Value = tobjU_USR_Lgn.Login_status;
		U_USR_LgnParms[8].Value = tobjU_USR_Lgn.Created_Date;
		U_USR_LgnParms[9].Value = tobjU_USR_Lgn.Updated_Date;
		U_USR_LgnParms[10].Value = tobjU_USR_Lgn.Created_by;
		U_USR_LgnParms[11].Value = tobjU_USR_Lgn.Updated_by;
	}
}
}