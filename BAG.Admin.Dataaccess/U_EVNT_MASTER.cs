using System;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Text;
using BAG.CommonConstants;
using BAG.Admin.Dataobject;
using Microsoft.ApplicationBlocks.Data;
using System.Collections.Generic;

namespace BAG.Admin.Dataaccess
{
public class U_EVNT_MASTERDAL
{
	private const string SQL_INSERT_U_EVNT_MASTER = "INSERT INTO U_EVNT_MASTER VALUES(@Event_Id, @Event_Creator_Id, @Event_Type_Id, @Event_Name, @Event_Desc, @Event_StartDate, @Event_EndDate, @Even_Location, @Event_Status, @Media_Id_Img, @COMMENTS, @Created_Date, @Updated_Date, @Created_by, @Updated_by)";
    private const string SQL_SELECT_HEADER_EVENTS = "Select Top 5 Event_Id,Event_Name,(select Media_file_location from u_adm_media_master where media_id=media_id_img) as Media_Id_Img from U_EVNT_MASTER where Event_Creator_Id=@Event_Creator_Id Select distinct Top 5 e.Event_Id,e.Event_Name,(select Media_file_location from u_adm_media_master where media_id=media_id_img) as Media_Id_Img from U_EVNT_MASTER e inner join U_EVNT_WList_Pub_Dtl p on p.Event_Id=e.Event_Id where Contact_Id=@Event_Creator_Id";
    private const string SQL_SELECT_Event_Details = "Select Event_Id,Event_Creator_Id,(select event_type_name from U_ADM_EVNT_Type a where a.Event_Type_Id=m.Event_Type_Id) as  Event_Type_Id,Event_Name,Event_Desc,Event_StartDate,Event_EndDate,Even_Location,Event_Status,Media_Id_Img,COMMENTS,Created_Date,Updated_Date,(select First_Name from U_USR_MASTER where Usr_Id=m.Created_by) as Created_by,Updated_by from U_EVNT_MASTER m where m.Event_Id=@Event_Id select item_id,item_name,item_tentative_cost,(select Media_file_location from u_adm_media_master where media_id=media_id_img) as media_id_img from U_ADM_ITEM_MASTER select distinct c.[Contact_Id],[Email_Id],[Mobile_Number],[Person_Name] from [U_USR_Contacts] c inner join [U_USR_Map_Contact] m  on m.Contact_Id=c.Contact_Id where m.Usr_Id=@Event_Creator_Id";
    private const string SQL_SELECT_MYEvents_List = "select event_id,event_name,(select count(*) from U_USR_MASTER) as Attendies,(select Media_file_location from u_adm_media_master where media_id=media_id_img) as media_id_img from U_EVNT_MASTER where Event_Creator_Id=@Event_Creator_Id";
    private const string SQL_SELECT_MYInvites_List = "select m.event_id,event_name,(select count(*) from U_USR_MASTER) as Attendies,(select Media_file_location from u_adm_media_master where media_id=media_id_img) as media_id_img from U_EVNT_MASTER m inner join U_EVNT_WList_Pub_Dtl p on m.Event_Id=p.Event_Id where p.Contact_Id=@Event_Creator_Id";
    private const string SQL_SELECT_MediaImageId = "select Media_Id from U_ADM_MEDIA_MASTER m inner join U_ADM_EVNT_Type t on t.Media_Id_Img=m.Media_Id where t.Event_Type_Id=@Event_Type_Id";
    private const string SQL_SELECT_Event_Details_V2 = "select Event_Id, Event_Name, Event_StartDate, Event_EndDate, Even_Location, Event_Status from U_EVNT_MASTER";
    private const string SQL_Event_Detail = "select eve.Event_Id, eve.Event_Name, eve.Even_Location, eve.Event_Desc, eve.Event_StartDate, eve.Event_EndDate, eve.Event_Status, usr.First_Name, usr.Last_Name, eve.COMMENTS, img.Media_File_Location, eve.Updated_by from U_EVNT_MASTER as eve INNER JOIN U_USR_MASTER usr on eve.Event_Creator_Id = usr.Usr_Id INNER JOIN U_ADM_MEDIA_MASTER img on eve.Media_Id_Img = img.Media_Id WHERE eve.Event_Id=@Event_Id";
    private const string SQL_Event_WishList = "select WList_Id, WList_Name from U_USR_WList where Event_Id = @Event_Id";
    private const string SQL_UPDATE_Event = "UPDATE U_EVNT_MASTER SET Event_Name=@Event_Name, Event_Desc=@Event_Desc, Event_StartDate=@Event_StartDate, Event_EndDate=@Event_EndDate, Even_Location=@Even_Location, Event_Status=@Event_Status, Media_Id_Img=@Media_Id_Img, Updated_Date=@Updated_Date, Updated_by=@Updated_by WHERE Event_Id =@Event_Id";
    private const string SQL_MediaId_Return = "SELECT Media_Id_Img FROM U_EVNT_MASTER WHERE EVENT_ID = @Event_Id";

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

	public U_EVNT_MASTERDAL(){ }

    public U_EVNT_MASTER[] GetEventsDetailsDb()
        {
            SqlConnection con = null;
            List<U_EVNT_MASTER> Events = new List<U_EVNT_MASTER>();
            DateTime tempDate = System.DateTime.Now;
            try
            {
                con = General.GetConnection();
                SqlDataReader reader = SqlHelper.ExecuteReader(con, CommandType.Text, SQL_SELECT_Event_Details_V2);
                while (reader.Read())
                {
                    Events.Add(new U_EVNT_MASTER(reader.GetString(0), null, null, reader.GetString(1), null, reader.GetDateTime(2), reader.GetDateTime(3), reader.GetString(4), reader.GetString(5), null, null, tempDate, tempDate, null, null));
                }
                reader.Close();
                return Events.ToArray();
            }
            catch(Exception e)
            {
                Console.Write(e);
                return null;
            }
            finally
            {
                if(con != null)
                    con.Dispose();
            }
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

    public Event GetSingleEventDetailsDb(string id)
        {
            SqlConnection con = null;
            SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_Event_Id, id) };
            Event aEvent = new Event();
            try
            {
                con = General.GetConnection();
                SqlDataReader reader = SqlHelper.ExecuteReader(con, CommandType.Text, SQL_Event_Detail, aParms);
                while (reader.Read())
                {
                    aEvent.Event_id = reader.GetString(0);
                    aEvent.Event_Name = reader.GetString(1);
                    aEvent.Event_Location = reader.GetString(2);
                    aEvent.Event_Desc = reader.GetString(3);
                    aEvent.Event_StartDate = reader.GetDateTime(4);
                    aEvent.Event_EndDate = reader.GetDateTime(5);
                    aEvent.Event_Status = reader.GetString(6);
                    aEvent.Event_Organizer = reader.GetString(7) + " " + reader.GetString(8);
                    aEvent.Event_TotalComments = reader.GetString(9);
                    aEvent.Event_PicUrl = reader.GetString(10);
                    aEvent.Event_Update_by = reader.GetString(11);
                }
                reader.Close();
                return aEvent;
            }
            catch (Exception e)
            {
                Console.Write(e);
                return null;
            }
        }

    public EventsWishList[] GetEventWishListDb(string id)
        {
            SqlConnection con = null;
            SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_Event_Id, id) };
            List<EventsWishList> aEventWishList = new List<EventsWishList>();
            try
            {
                con = General.GetConnection();
                SqlDataReader reader = SqlHelper.ExecuteReader(con, CommandType.Text, SQL_Event_WishList, aParms);
                while (reader.Read())
                {
                    aEventWishList.Add(new EventsWishList(reader.GetString(0), reader.GetString(1)));
                }
                reader.Close();
                return aEventWishList.ToArray();
            }
            catch (Exception e)
            {
                Console.Write(e);
                return null;
            }
            finally
            {
                if (con != null)
                {
                    con.Dispose();
                }
            }
        }

    public int Update_EventDetailsDb(U_EVNT_MASTER eve)
        {
            SqlParameter[] aParms = GetParameters(eve);
            SetParameters(aParms, eve);
            using (SqlConnection conn = General.GetConnection())
            {
                int status = 0;
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, SQL_UPDATE_Event, aParms);
                        trans.Commit();
                        status = 1;
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
    
    public string GetEventMediaIdDb(string id)
        {
            SqlConnection con = null;
            SqlParameter[] aParms = new SqlParameter[] { new SqlParameter(PARAM_Event_Id, id) };
            string MediaId = string.Empty;
            try
            {
                con = General.GetConnection();
                SqlDataReader reader = SqlHelper.ExecuteReader(con, CommandType.Text, SQL_MediaId_Return, aParms);
                while (reader.Read())
                {
                    MediaId = reader.GetString(0);
                }
                reader.Close();
                return MediaId;
            }
            catch (Exception e)
            {
                Console.Write(e);
                return null;
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