using System;

namespace BAG.Admin.Dataobject
{
public class U_EVNT_Cntrb_Adj
{
	/// <summary>
	/// Default Contructor
	/// <summary>
	public U_EVNT_Cntrb_Adj()
	{}


	public string Amount_Adj_Id
	{ 
		get { return _Amount_Adj_Id; }
		set { _Amount_Adj_Id = value; }
	}
	private string _Amount_Adj_Id;

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

	public string Source_WList_ID
	{ 
		get { return _Source_WList_ID; }
		set { _Source_WList_ID = value; }
	}
	private string _Source_WList_ID;

	public string Target_WList_ID
	{ 
		get { return _Target_WList_ID; }
		set { _Target_WList_ID = value; }
	}
	private string _Target_WList_ID;

	public System.DateTime DateTime_Of_Adj
	{ 
		get { return _DateTime_Of_Adj; }
		set { _DateTime_Of_Adj = value; }
	}
	private System.DateTime _DateTime_Of_Adj;

	public decimal Amount_Adjusted
	{ 
		get { return _Amount_Adjusted; }
		set { _Amount_Adjusted = value; }
	}
	private decimal _Amount_Adjusted;

	public string COMMENTS
	{ 
		get { return _COMMENTS; }
		set { _COMMENTS = value; }
	}
	private string _COMMENTS;

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

	public U_EVNT_Cntrb_Adj(

		string Amount_Adj_Id, 
		string Event_Id, 
		string Event_Creator_Id, 
		string Source_WList_ID, 
		string Target_WList_ID, 
		System.DateTime DateTime_Of_Adj, 
		decimal Amount_Adjusted, 
		string COMMENTS, 
		System.DateTime Created_Date, 
		System.DateTime Updated_Date, 
		string Created_by, 
		string Updated_by)
	{

	
		this._Amount_Adj_Id = Amount_Adj_Id; 
		this._Event_Id = Event_Id; 
		this._Event_Creator_Id = Event_Creator_Id; 
		this._Source_WList_ID = Source_WList_ID; 
		this._Target_WList_ID = Target_WList_ID; 
		this._DateTime_Of_Adj = DateTime_Of_Adj; 
		this._Amount_Adjusted = Amount_Adjusted; 
		this._COMMENTS = COMMENTS; 
		this._Created_Date = Created_Date; 
		this._Updated_Date = Updated_Date; 
		this._Created_by = Created_by; 
		this._Updated_by = Updated_by; 
	}
}
}