using System;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Text;
using BAG.CommonConstants;
using BAG.DataObject;
using Microsoft.ApplicationBlocks.Data;
using System.Collections.Generic;
using BAG.CustomObject;

namespace BAG.Event.DataAccess
{
public class U_EVNT_MASTERDAL
{
	private const string SQL_INSERT_U_EVNT_MASTER = "INSERT INTO U_EVNT_MASTER VALUES(@Event_Id, @Event_Creator_Id, @Event_Type_Id, @Event_Name, @Event_Desc, @Event_StartDate, @Event_EndDate, @Even_Location, @Event_Status, @Media_Id_Img, @COMMENTS, @Created_Date, @Updated_Date, @Created_by, @Updated_by)";
    private const string SQL_SELECT_HEADER_EVENTS = "Select Top 5 Event_Id,Event_Name,(select Media_file_location from u_adm_media_master where media_id=media_id_img) as Media_Id_Img from U_EVNT_MASTER where Event_Creator_Id=@Event_Creator_Id Select distinct Top 5 e.Event_Id,e.Event_Name,(select Media_file_location from u_adm_media_master where media_id=media_id_img) as Media_Id_Img from U_EVNT_MASTER e inner join U_EVNT_WList_Pub_Dtl p on p.Event_Id=e.Event_Id where Contact_Id=@Event_Creator_Id";
    private const string SQL_SELECT_Event_Details = "Select Event_Id,Event_Creator_Id,(select event_type_name from U_ADM_EVNT_Type a where a.Event_Type_Id=m.Event_Type_Id) as  Event_Type_Id,Event_Name,Event_Desc,Event_StartDate,Event_EndDate,Even_Location,Event_Status,Media_Id_Img,COMMENTS,Created_Date,Updated_Date,(select First_Name from U_USR_MASTER where Usr_Id=m.Created_by) as Created_by,Updated_by from U_EVNT_MASTER m where m.Event_Id=@Event_Id select item_id,item_name,item_tentative_cost,(select Media_file_location from u_adm_media_master where media_id=media_id_img) as media_id_img from U_ADM_ITEM_MASTER select distinct c.[Contact_Id],[Email_Id],[Mobile_Number],[Person_Name] from [U_USR_Contacts] c inner join [U_USR_Map_Contact] m  on m.Contact_Id=c.Contact_Id where m.Usr_Id=@Event_Creator_Id";
    private const string SQL_SELECT_MYEvents_List = "select event_id,event_name,(select count(*) from U_USR_MASTER) as Attendies,(select Media_file_location from u_adm_media_master where media_id=media_id_img) as media_id_img from U_EVNT_MASTER where Event_Creator_Id=@Event_Creator_Id";
    private const string SQL_SELECT_MYInvites_List = "select m.event_id,event_name,(select count(*) from U_USR_MASTER) as Attendies,(select Media_file_location from u_adm_media_master where media_id=media_id_img) as media_id_img from U_EVNT_MASTER m inner join U_EVNT_WList_Pub_Dtl p on m.Event_Id=p.Event_Id where p.Contact_Id=@Event_Creator_Id";
    private const string SQL_SELECT_MediaImageId = "select Media_Id from U_ADM_MEDIA_MASTER m inner join U_ADM_EVNT_Type t on t.Media_Id_Img=m.Media_Id where t.Event_Type_Id=@Event_Type_Id";
    private const string SQL_SELECT_EventImage = "Select Media_File_Location from U_ADM_MEDIA_MASTER m inner join U_ADM_EVNT_Type t on t.Media_Id_Img=m.Media_Id where t.Event_Type_Id=@Event_Type_Id";

    private const string PARAM_Event_Id = "@Event_Id";
	private const string PARAM_Event_Creator_Id = "@Event_Creator_Id";
	private const string PARAM_Event_Type_Id = "@Event_Type_Id";
	private const string PARAM_Event_Name = "@Event_Name";
	private const string PARAM_Event_Desc = "@Event_Desc";
	private const string PARAM_Event_StartDate = "@Event_StartDate";
	private const string PARAM_Event_EndDate = "@Event_EndDate";
	private const string PARAM_Even_Location = "@Even_Location";
	private const string PARAM_Event_Status = "@Event_Status";
	private const string PARAM_Media_Id_Img = "@Media_Id_Img";
	private const string PARAM_COMMENTS = "@COMMENTS";
	private const string PARAM_Created_Date = "@Created_Date";
	private const string PARAM_Updated_Date = "@Updated_Date";
	private const string PARAM_Created_by = "@Created_by";
	private const string PARAM_Updated_by = "@Updated_by";
	public U_EVNT_MASTERDAL()
	{

	}

	public bool InsertU_EVNT_MASTER(U_EVNT_MASTER tobjU_EVNT_MASTER)
	{
		if(tobjU_EVNT_MASTER != null)
		{
			//Get the parameter list needed by the given object
			SqlParameter[] lParamArray =  GetParameters(tobjU_EVNT_MASTER);
			SetParameters(lParamArray, tobjU_EVNT_MASTER);
			//Get the connection
			SqlConnection con = General.GetConnection();
			if (con == null)
				//Connection is not created 
				return false;
			//Execute the insertion
			int i = SqlHelper.ExecuteNonQuery(
				con, 
				CommandType.Text, 
				SQL_INSERT_U_EVNT_MASTER, 
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

        public Group_HeaderEvent Get_HeaderEvents(string UserId)
        {
            SqlConnection connection = null;
            SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_Event_Creator_Id, UserId) };
            List<HeaderEvents> olist = new List<HeaderEvents>();
            List<HeaderEvents> olist2 = new List<HeaderEvents>();
            Group_HeaderEvent oevent = new Group_HeaderEvent();
            
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
                SqlDataReader reader = SqlHelper.ExecuteReader(connection, CommandType.Text, SQL_SELECT_HEADER_EVENTS, aParms);

                while (reader.Read())
                {
                    olist.Add(new HeaderEvents(
                        reader.GetString(0),
                        reader.GetString(1),
                        reader.GetString(2)));
                }
                if(reader.NextResult())
                {
                    while (reader.Read())
                    {
                        olist2.Add(new HeaderEvents(
                            reader.GetString(0),
                            reader.GetString(1),
                            reader.GetString(2)));
                    }
                }
                reader.Close();
                oevent.MyEvent = olist.ToArray();
                oevent.EventInvites = olist2.ToArray();
                return oevent;
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

        public EventDetails Get_EventsDetails(string EventId, string UserId)
        {
            SqlConnection connection = null;
            SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_Event_Id, EventId), new SqlParameter(PARAM_Event_Creator_Id, UserId) };
            U_EVNT_MASTER omst = new U_EVNT_MASTER();
            List<ItemsList> olist = new List<ItemsList>();
            EventDetails oevent = new EventDetails();
            List<Invites> olist1 = new List<Invites>();

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
                SqlDataReader reader = SqlHelper.ExecuteReader(connection, CommandType.Text, SQL_SELECT_Event_Details, aParms);

                while (reader.Read())
                {
                    omst= new U_EVNT_MASTER(
                    reader.GetString(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetString(4),
                    reader.GetDateTime(5),
                    reader.GetDateTime(6),
                    reader.GetString(7),
                    reader.GetString(8),
                    reader.GetString(9),
                    reader.GetString(10),
                    reader.GetDateTime(11),
                    reader.GetDateTime(12),
                    reader.GetString(13),
                    reader.GetString(14));
                }
                if(reader.NextResult())
                {
                    while (reader.Read())
                    {
                        olist.Add(new ItemsList(
                        reader.GetString(0),
                        reader.GetString(1),
                        reader.GetDecimal(2),
                        reader.GetString(3)));
                    }
                }
                if (reader.NextResult())
                {
                    while (reader.Read())
                    {
                        olist1.Add(new Invites(
                        reader.GetString(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3)));
                    }
                }
                reader.Close();
                oevent.ItemList = olist.ToArray();
                oevent.EventMaster = omst;
                oevent.InvitedMembers = olist1.ToArray();
                return oevent;
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

        public EventsList[] Get_MYEvents(string UserId)
        {
            SqlConnection connection = null;
            SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_Event_Creator_Id, UserId) };
            List<EventsList> olist = new List<EventsList>();
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
                SqlDataReader reader = SqlHelper.ExecuteReader(connection, CommandType.Text, SQL_SELECT_MYEvents_List, aParms);

                while (reader.Read())
                {
                    olist.Add(new EventsList(
                        reader.GetString(0),
                        reader.GetString(1),
                        reader.GetInt32(2).ToString(),
                        reader.GetString(3)));
                }
                reader.Close();
                return olist.ToArray();
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

        public EventsList[] Get_MYInvites(string UserId)
        {
            SqlConnection connection = null;
            SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_Event_Creator_Id, UserId) };
            List<EventsList> olist = new List<EventsList>();
            try
            {
                try
                {
                    connection = General.GetConnection();
                }
                catch (Exception e)
                {
                    Console.Write(e);
                    return null;
                }
                SqlDataReader reader = SqlHelper.ExecuteReader(connection, CommandType.Text, SQL_SELECT_MYInvites_List, aParms);

                while (reader.Read())
                {
                    olist.Add(new EventsList(
                        reader.GetString(0),
                        reader.GetString(1),
                        reader.GetInt32(2).ToString(),
                        reader.GetString(3)));
                }
                reader.Close();
                return olist.ToArray();
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

        public string Select_MediaImageId(string Id)
        {
            SqlConnection connection = null;
            SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_Event_Type_Id, Id) };
            List<EventsList> olist = new List<EventsList>();
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
                SqlDataReader reader = SqlHelper.ExecuteReader(connection, CommandType.Text, SQL_SELECT_MediaImageId, aParms);

                while (reader.Read())
                {
                    return reader.GetString(0);
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

        public string SELECT_EventImage(string Id)
        {
            SqlConnection connection = null;
            SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_Event_Type_Id, Id) };
            List<EventsList> olist = new List<EventsList>();
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
                SqlDataReader reader = SqlHelper.ExecuteReader(connection, CommandType.Text, SQL_SELECT_EventImage, aParms);

                while (reader.Read())
                {
                    return reader.GetString(0);
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

        private SqlParameter[] GetParameters(U_EVNT_MASTER tobjU_EVNT_MASTER)
	{
		SqlParameter[] objParamArray = SqlHelperParameterCache.GetCachedParameterSet(General.SQL_CONN_STRING, SQL_INSERT_U_EVNT_MASTER);
		if (objParamArray == null)
		{
			//Represents a parameter to a System.Data.SqlClient.SqlCommand, 
			//and optionally, its mapping to System.Data.DataSet columns. 
			objParamArray = new SqlParameter[]
			{
				new SqlParameter(PARAM_Event_Id, tobjU_EVNT_MASTER.Event_Id),
				new SqlParameter(PARAM_Event_Creator_Id, tobjU_EVNT_MASTER.Event_Creator_Id),
				new SqlParameter(PARAM_Event_Type_Id, tobjU_EVNT_MASTER.Event_Type_Id),
				new SqlParameter(PARAM_Event_Name, tobjU_EVNT_MASTER.Event_Name),
				new SqlParameter(PARAM_Event_Desc, tobjU_EVNT_MASTER.Event_Desc),
				new SqlParameter(PARAM_Event_StartDate, tobjU_EVNT_MASTER.Event_StartDate),
				new SqlParameter(PARAM_Event_EndDate, tobjU_EVNT_MASTER.Event_EndDate),
				new SqlParameter(PARAM_Even_Location, tobjU_EVNT_MASTER.Even_Location),
				new SqlParameter(PARAM_Event_Status, tobjU_EVNT_MASTER.Event_Status),
				new SqlParameter(PARAM_Media_Id_Img, tobjU_EVNT_MASTER.Media_Id_Img),
				new SqlParameter(PARAM_COMMENTS, tobjU_EVNT_MASTER.COMMENTS),
				new SqlParameter(PARAM_Created_Date, tobjU_EVNT_MASTER.Created_Date),
				new SqlParameter(PARAM_Updated_Date, tobjU_EVNT_MASTER.Updated_Date),
				new SqlParameter(PARAM_Created_by, tobjU_EVNT_MASTER.Created_by),
				new SqlParameter(PARAM_Updated_by, tobjU_EVNT_MASTER.Updated_by),
			};
			SqlHelperParameterCache.CacheParameterSet(General.SQL_CONN_STRING, SQL_INSERT_U_EVNT_MASTER, objParamArray);
		}
		return objParamArray;
	}

	private void SetParameters(SqlParameter[] U_EVNT_MASTERParms,U_EVNT_MASTER tobjU_EVNT_MASTER)
	{
		U_EVNT_MASTERParms[0].Value = tobjU_EVNT_MASTER.Event_Id;
		U_EVNT_MASTERParms[1].Value = tobjU_EVNT_MASTER.Event_Creator_Id;
		U_EVNT_MASTERParms[2].Value = tobjU_EVNT_MASTER.Event_Type_Id;
		U_EVNT_MASTERParms[3].Value = tobjU_EVNT_MASTER.Event_Name;
		U_EVNT_MASTERParms[4].Value = tobjU_EVNT_MASTER.Event_Desc;
		U_EVNT_MASTERParms[5].Value = tobjU_EVNT_MASTER.Event_StartDate;
		U_EVNT_MASTERParms[6].Value = tobjU_EVNT_MASTER.Event_EndDate;
		U_EVNT_MASTERParms[7].Value = tobjU_EVNT_MASTER.Even_Location;
		U_EVNT_MASTERParms[8].Value = tobjU_EVNT_MASTER.Event_Status;
		U_EVNT_MASTERParms[9].Value = tobjU_EVNT_MASTER.Media_Id_Img;
		U_EVNT_MASTERParms[10].Value = tobjU_EVNT_MASTER.COMMENTS;
		U_EVNT_MASTERParms[11].Value = tobjU_EVNT_MASTER.Created_Date;
		U_EVNT_MASTERParms[12].Value = tobjU_EVNT_MASTER.Updated_Date;
		U_EVNT_MASTERParms[13].Value = tobjU_EVNT_MASTER.Created_by;
		U_EVNT_MASTERParms[14].Value = tobjU_EVNT_MASTER.Updated_by;
	}
}
}