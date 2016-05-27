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
public class U_USR_MASTERDAL
{
	private const string SQL_INSERT_U_USR_MASTER = "INSERT INTO U_USR_MASTER VALUES(@Usr_Id, @First_Name, @Last_Name, @Alt_Email_Id, @Gender, @Date_Of_Birth, @About_member, @Is_married, @Wed_anniversary, @Rating, @Address_Id, @Usr_Profile_Id, @Media_Id_Img, @Created_Date, @Updated_Date, @Created_by, @Updated_by)";
    private const string SQL_Select_U_USR_MASTER = "SELECT [Usr_Id],[First_Name],[Last_Name],[Email_Id],[Alt_Email_Id],l.Mobile_Number,[Gender],[Date_Of_Birth],[About_member],[Is_married],[Wed_anniversary],[Rating],[Address_Id],(select media_File_Location from U_ADM_MEDIA_MASTER where Media_Id=[Media_Id_Img]) as [Media_Id_Img],m.[Created_Date],m.[Updated_Date],m.[Created_by],m.[Updated_by],m.[Media_Id_Img] FROM [BAG].[dbo].[U_USR_MASTER] m inner join U_USR_Lgn l on m.Usr_Id=l.Usr_Mst_Id where m.Usr_Id=@Usr_Id";
    private const string SQL_Update_U_USR_MASTER = "Update U_USR_MASTER SET First_Name=@First_Name, Last_Name=@Last_Name, Alt_Email_Id=@Alt_Email_Id, Gender=@Gender, Date_Of_Birth=@Date_Of_Birth, About_member=@About_member, Is_married=@Is_married, Wed_anniversary=@Wed_anniversary, Address_Id=@Address_Id, Updated_Date=@Updated_Date, Updated_by=@Updated_by,Media_Id_Img=@Media_Id_Img where Usr_Id=@Usr_Id";
    private const string SQL_SELECT_U_USR_MASTER_V2 = "select a.Usr_Id, a.First_Name, a.Last_Name, a.Alt_Email_Id, a.Gender, b.Login_status from U_USR_MASTER  as a INNER JOIN U_USR_Lgn as b ON a.Usr_Id = b.Usr_Mst_Id where Usr_role_Id = '3'"; // 3 - user role
    private const string SQL_SELECT_SubAdmin = "select a.Usr_Id, a.First_Name, a.Last_Name, a.Alt_Email_Id, a.Gender, b.Login_status from U_USR_MASTER  as a INNER JOIN U_USR_Lgn as b ON a.Usr_Id = b.Usr_Mst_Id where Usr_role_Id = '2'"; // 2 - SubAdmin role
    private const string SQL_MemberContacts = "select cont.Contact_Id, cont.Person_Name, cont.Email_Id, cont.Mobile_Number from U_USR_Map_Contact as usr inner join U_USR_Contacts as cont on usr.Contact_Id = cont.Contact_Id where Usr_Id = @Usr_Id";  // Contact_Status = 1 - contact Not Deleted
    private const string SQL_SELECT_U_USR_MASTER_V3 = "select a.*, c.Mobile_Number , b.*,  d.Media_File_Location from U_USR_MASTER AS a INNER JOIN U_USR_Address b	ON a.Address_Id = b.Address_Id INNER JOIN U_USR_Lgn c ON c.Usr_Mst_Id = a.Usr_Id INNER JOIN U_ADM_MEDIA_MASTER d ON d.Media_Id = a.Media_Id_Img WHERE a.Usr_Id=@Usr_Id";
    private const string SQL_BlockThisUser = "UPDATE U_USR_Lgn SET Login_status='0' WHERE Usr_Mst_Id = @Usr_Id";
    private const string SQL_UnblockThisUser = "UPDATE U_USR_Lgn SET Login_status='1' WHERE Usr_Mst_Id = @Usr_Id";
    private const string SQL_SELECT_SingleSubAdmin = "select u.Usr_Id, u.First_Name, u.Last_Name, u.Gender, u.Alt_Email_Id, l.Mobile_Number, l.Login_status, u.Usr_role_Id, m.Media_File_Location, u.Created_Date, u.Updated_Date, u.Created_by, u.Updated_by from U_USR_MASTER as u INNER JOIN U_USR_Lgn as l on u.Usr_Id = l.Usr_Mst_Id INNER JOIN U_ADM_MEDIA_MASTER m on u.Media_Id_Img = m.Media_Id where u.Usr_Id = @Usr_Id";
    private const string SQL_UPDATE_SubAdminProfile = "UPDATE U_USR_MASTER SET First_Name=@First_Name, Last_Name=@Last_Name, Gender=@Gender, usr_role_Id=@Usr_Profile_Id, Media_Id_Img=@Media_Id_Img, Updated_date=@Updated_Date, Updated_by=@Updated_by WHERE Usr_Id=@Usr_Id";

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

    public bool GetBlockThisUserDb(string Id)
    {
        SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_Usr_Id, Id) };
        bool status;
        using (SqlConnection conn = General.GetConnection())
        {
            // conn.Open();
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SQL_BlockThisUser, aParms);
                    trans.Commit();
                    status = true;
                }
                catch (System.Exception e)
                {
                    Console.Write(e);
                    trans.Rollback();
                    throw;
                }
            }
        }
        return status;
    }

    public bool GetUnblockThisUserDb(string Id)
    {
        SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_Usr_Id, Id) };
        bool status;
        using (SqlConnection conn = General.GetConnection())
        {
            // conn.Open();
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SQL_UnblockThisUser, aParms);
                    trans.Commit();
                    status = true;
                }
                catch (System.Exception e)
                {
                    Console.Write(e);
                    trans.Rollback();
                    throw;
                }
            }
        }
        return status;
    }

    public A_USR_MASTER_V2 GetSingleMemberDetailsDb(string id)
    {
        SqlConnection con = null;
        SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_Usr_Id, id) };
        A_USR_MASTER_V2 member = new A_USR_MASTER_V2();
        try
        {
            con = General.GetConnection();
            SqlDataReader reader = SqlHelper.ExecuteReader(con, CommandType.Text, SQL_SELECT_U_USR_MASTER_V3, aParms);
            while (reader.Read())
            {
                member.Uid = reader.GetString(0);
                member.FirstName = reader.GetString(1);
                member.LastName = reader.GetString(2);
                member.EmailId = reader.GetString(3);
                member.Gender = reader.GetString(4);
                member.Dob = reader.GetDateTime(5);
                member.MobileNumber = reader.GetString(17);
                member.IsMarried = reader.GetInt16(7);
                member.WedAnvrsry = reader.GetDateTime(8);
                member.Address = reader.GetString(19) + ":" + reader.GetString(20) + "," + reader.GetString(21) + "," + reader.GetString(22) + "," + reader.GetString(23) + "-" + reader.GetString(26) + "," + reader.GetString(24) + "," + reader.GetString(25);
                member.PicUrl = reader.GetString(31);
                member.Ratings = reader.GetString(9);
                member.Created_By = reader.GetString(15);
                member.Updated_By = reader.GetString(16);
                member.Create_Date = reader.GetDateTime(13);
                member.Update_Date = reader.GetDateTime(14);
                }
            reader.Close();
            return member;
        }
        catch (Exception e)
        {
            Console.Write(e);
            return null;
        }
    }

    public Admin_Members[] GetMembersDetailsDb()
{
        SqlConnection con = null;
        List<Admin_Members> members = new List<Admin_Members>();
        try
        {
            con = General.GetConnection();
            SqlDataReader reader = SqlHelper.ExecuteReader(con, CommandType.Text, SQL_SELECT_U_USR_MASTER_V2);
            while (reader.Read())
            {
                members.Add(new Admin_Members(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5)));
            }
            reader.Close();
            return members.ToArray();
        } 
        catch(Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
        finally
        {
            if (con != null)
                con.Dispose();
        }
}

    public Admin_Members[] GetSubAdminDetailsDb()
    {
        SqlConnection con = null;
        List<Admin_Members> members = new List<Admin_Members>();
        try
        {
            con = General.GetConnection();
            SqlDataReader reader = SqlHelper.ExecuteReader(con, CommandType.Text, SQL_SELECT_SubAdmin);
            while (reader.Read())
            {
                members.Add(new Admin_Members(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5)));
            }
            reader.Close();
            return members.ToArray();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
        finally
        {
            if (con != null)
                con.Dispose();
        }
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
    
    public bool Update_UserProfile(U_USR_MASTER odetails)
    {
        SqlParameter[] aParms = GetParameters(odetails);
        SetParameters(aParms, odetails);
        using (SqlConnection conn = General.GetConnection())
        {
            bool status = false;
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SQL_Update_U_USR_MASTER, aParms);
                    trans.Commit();
                    status = true;
                }
                catch (System.Exception e)
                {
                        Console.Write(e);
                        trans.Rollback();
                    //log.Error(lobjError, e);
                    throw;
                }
            }
            return status;
        }
    }

    public MemberContacts[] GetMemberContactsDb(string id)
    {
            SqlConnection con = null;
            SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_Usr_Id, id) };
            List<MemberContacts> memContacts = new List<MemberContacts>();
            try
            {
                con = General.GetConnection();
                SqlDataReader reader = SqlHelper.ExecuteReader(con, CommandType.Text, SQL_MemberContacts, aParms);
                while (reader.Read())
                {
                    memContacts.Add(new MemberContacts(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));
                }
                reader.Close();
                return memContacts.ToArray();
            } 
            catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

    public SubAdmin GetSingleSubAdminDetailsDb(string id)
    {
        SqlConnection con = null;
        SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_Usr_Id, id) };
        SubAdmin member = new SubAdmin();
        try
        {
            con = General.GetConnection();
            SqlDataReader reader = SqlHelper.ExecuteReader(con, CommandType.Text, SQL_SELECT_SingleSubAdmin, aParms);
            while (reader.Read())
            {
                    member.Usr_Id = reader.GetString(0);
                    member.First_Name = reader.GetString(1);
                    member.Last_Name = reader.GetString(2);
                    member.Gender = reader.GetString(3);
                    member.Alt_Email_Id = reader.GetString(4);
                    member.Mobile_Number = reader.GetString(5);
                    member.Login_status = reader.GetInt32(6);
                    member.Usr_role_Id = reader.GetString(7);                    
                    member.Media_File_Location = reader.GetString(8);
                    member.Created_Date = reader.GetDateTime(9);
                    member.Updated_Date = reader.GetDateTime(10);
                    member.Created_by = reader.GetString(11);
                    member.Updated_by = reader.GetString(12);
            }
            reader.Close();
            return member;
        }
        catch (Exception e)
        {
            Console.Write(e);
            return null;
        }
    }

    public bool Update_SubAdminProfileDb(U_USR_MASTER subadmin)
    {
        SqlParameter[] aParms = GetParameters(subadmin);
        SetParameters(aParms, subadmin);
        using (SqlConnection conn = General.GetConnection())
        {
            bool status = false;
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SQL_UPDATE_SubAdminProfile, aParms);
                    trans.Commit();
                    status = true;
                }
                catch (System.Exception e)
                {
                        Console.Write(e);
                        trans.Rollback();
                    //log.Error(lobjError, e);
                    throw;
                }
            }
            return status;
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