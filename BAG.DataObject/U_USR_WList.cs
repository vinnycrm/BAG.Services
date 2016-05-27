using System;

namespace BAG.DataObject
{
public class U_USR_WList
{
	/// <summary>
	/// Default Contructor
	/// <summary>
	public U_USR_WList()
	{}


	public string WList_Id
	{ 
		get { return _WList_Id; }
		set { _WList_Id = value; }
	}
	private string _WList_Id;

	public string Event_Id
	{ 
		get { return _Event_Id; }
		set { _Event_Id = value; }
	}
	private string _Event_Id;

	public string Event_Creator_Id
	{ 
		get { return _Event_Creator_Id; }
		set { _Event_Creator_Id = value; }
	}
	private string _Event_Creator_Id;

	public string WList_Name
	{ 
		get { return _WList_Name; }
		set { _WList_Name = value; }
	}
	private string _WList_Name;

	public string WList_Status
	{ 
		get { return _WList_Status; }
		set { _WList_Status = value; }
	}
	private string _WList_Status;

	public string Media_Id_Img
	{ 
		get { return _Media_Id_Img; }
		set { _Media_Id_Img = value; }
	}
	private string _Media_Id_Img;

	public string Comments
	{ 
		get { return _Comments; }
		set { _Comments = value; }
	}
	private string _Comments;

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

	public U_USR_WList(

		string WList_Id, 
		string Event_Id, 
		string Event_Creator_Id, 
		string WList_Name, 
		string WList_Status, 
		string Media_Id_Img, 
		string Comments, 
		System.DateTime Created_Date, 
		System.DateTime Updated_Date, 
		string Created_by, 
		string Updated_by)
	{

	
		this._WList_Id = WList_Id; 
		this._Event_Id = Event_Id; 
		this._Event_Creator_Id = Event_Creator_Id; 
		this._WList_Name = WList_Name; 
		this._WList_Status = WList_Status; 
		this._Media_Id_Img = Media_Id_Img; 
		this._Comments = Comments; 
		this._Created_Date = Created_Date; 
		this._Updated_Date = Updated_Date; 
		this._Created_by = Created_by; 
		this._Updated_by = Updated_by; 
	}
}
}