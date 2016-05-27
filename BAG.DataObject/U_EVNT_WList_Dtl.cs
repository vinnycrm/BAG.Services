using System;

namespace BAG.DataObject
{
public class U_EVNT_WList_Dtl
{
	/// <summary>
	/// Default Contructor
	/// <summary>
	public U_EVNT_WList_Dtl()
	{}


	public string Id
	{ 
		get { return _Id; }
		set { _Id = value; }
	}
	private string _Id;

	public string Event_Id
	{ 
		get { return _Event_Id; }
		set { _Event_Id = value; }
	}
	private string _Event_Id;

	public string WList_Id
	{ 
		get { return _WList_Id; }
		set { _WList_Id = value; }
	}
	private string _WList_Id;

	public string Item_Id
	{ 
		get { return _Item_Id; }
		set { _Item_Id = value; }
	}
	private string _Item_Id;

	public decimal Item_Cost_Entered_ByUser
	{ 
		get { return _Item_Cost_Entered_ByUser; }
		set { _Item_Cost_Entered_ByUser = value; }
	}
	private decimal _Item_Cost_Entered_ByUser;

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

	public U_EVNT_WList_Dtl(

		string Id, 
		string Event_Id, 
		string WList_Id, 
		string Item_Id, 
		decimal Item_Cost_Entered_ByUser, 
		System.DateTime Created_Date, 
		System.DateTime Updated_Date, 
		string Created_by, 
		string Updated_by)
	{

	
		this._Id = Id; 
		this._Event_Id = Event_Id; 
		this._WList_Id = WList_Id; 
		this._Item_Id = Item_Id; 
		this._Item_Cost_Entered_ByUser = Item_Cost_Entered_ByUser; 
		this._Created_Date = Created_Date; 
		this._Updated_Date = Updated_Date; 
		this._Created_by = Created_by; 
		this._Updated_by = Updated_by; 
	}
}

}