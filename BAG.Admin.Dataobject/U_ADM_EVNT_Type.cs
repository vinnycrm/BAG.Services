using System;

namespace BAG.Admin.Dataobject
{
public class U_ADM_EVNT_Type
{
	/// <summary>
	/// Default Contructor
	/// <summary>
	public U_ADM_EVNT_Type()
	{}


	public string Event_Type_Id
	{ 
		get { return _Event_Type_Id; }
		set { _Event_Type_Id = value; }
	}
	private string _Event_Type_Id;

	public string Event_Type_Name
	{ 
		get { return _Event_Type_Name; }
		set { _Event_Type_Name = value; }
	}
	private string _Event_Type_Name;

	public string Event_Desc
	{ 
		get { return _Event_Desc; }
		set { _Event_Desc = value; }
	}
	private string _Event_Desc;

	public string Media_Id_Img
	{ 
		get { return _Media_Id_Img; }
		set { _Media_Id_Img = value; }
	}
	private string _Media_Id_Img;

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

	public U_ADM_EVNT_Type(

		string Event_Type_Id, 
		string Event_Type_Name, 
		string Event_Desc, 
		string Media_Id_Img, 
		System.DateTime Created_Date, 
		System.DateTime Updated_Date, 
		string Created_by, 
		string Updated_by)
	{

	
		this._Event_Type_Id = Event_Type_Id; 
		this._Event_Type_Name = Event_Type_Name; 
		this._Event_Desc = Event_Desc; 
		this._Media_Id_Img = Media_Id_Img; 
		this._Created_Date = Created_Date; 
		this._Updated_Date = Updated_Date; 
		this._Created_by = Created_by; 
		this._Updated_by = Updated_by; 
	}
}
}