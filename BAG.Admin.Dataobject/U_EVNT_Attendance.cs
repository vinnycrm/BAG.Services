using System;

namespace BAG.Admin.Dataobject
{
public class U_EVNT_Attendance
{
	/// <summary>
	/// Default Contructor
	/// <summary>
	public U_EVNT_Attendance()
	{}


	public string Event_Id
	{ 
		get { return _Event_Id; }
		set { _Event_Id = value; }
	}
	private string _Event_Id;

	public string Cntrb_Id
	{ 
		get { return _Cntrb_Id; }
		set { _Cntrb_Id = value; }
	}
	private string _Cntrb_Id;

	public string Attending_The_Event
	{ 
		get { return _Attending_The_Event; }
		set { _Attending_The_Event = value; }
	}
	private string _Attending_The_Event;

	public string Wish_Msg_From_Invitee
	{ 
		get { return _Wish_Msg_From_Invitee; }
		set { _Wish_Msg_From_Invitee = value; }
	}
	private string _Wish_Msg_From_Invitee;

	public System.DateTime Created_Date
	{ 
		get { return _Created_Date; }
		set { _Created_Date = value; }
	}
	private System.DateTime _Created_Date;

	public System.DateTime Updated_Date
	{ 
		get { return _Updated_Date; }
		set { _Updated_Date = value; }
	}
	private System.DateTime _Updated_Date;

	public string Created_by
	{ 
		get { return _Created_by; }
		set { _Created_by = value; }
	}
	private string _Created_by;

	public string Updated_by
	{ 
		get { return _Updated_by; }
		set { _Updated_by = value; }
	}
	private string _Updated_by;

	public U_EVNT_Attendance(

		string Event_Id, 
		string Cntrb_Id, 
		string Attending_The_Event, 
		string Wish_Msg_From_Invitee, 
		System.DateTime Created_Date, 
		System.DateTime Updated_Date, 
		string Created_by, 
		string Updated_by)
	{

	
		this._Event_Id = Event_Id; 
		this._Cntrb_Id = Cntrb_Id; 
		this._Attending_The_Event = Attending_The_Event; 
		this._Wish_Msg_From_Invitee = Wish_Msg_From_Invitee; 
		this._Created_Date = Created_Date; 
		this._Updated_Date = Updated_Date; 
		this._Created_by = Created_by; 
		this._Updated_by = Updated_by; 
	}
}
}