using System;

namespace BAG.Admin.Dataobject
{
public class U_EVNT_Recom_Source
{
	/// <summary>
	/// Default Contructor
	/// <summary>
	public U_EVNT_Recom_Source()
	{}


	public string Event_Type_Id
	{ 
		get { return _Event_Type_Id; }
		set { _Event_Type_Id = value; }
	}
	private string _Event_Type_Id;

	public string Item_Id
	{ 
		get { return _Item_Id; }
		set { _Item_Id = value; }
	}
	private string _Item_Id;

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

	public U_EVNT_Recom_Source(

		string Event_Type_Id, 
		string Item_Id, 
		System.DateTime Created_Date, 
		System.DateTime Updated_Date, 
		string Created_by, 
		string Updated_by)
	{

	
		this._Event_Type_Id = Event_Type_Id; 
		this._Item_Id = Item_Id; 
		this._Created_Date = Created_Date; 
		this._Updated_Date = Updated_Date; 
		this._Created_by = Created_by; 
		this._Updated_by = Updated_by; 
	}
}
}