using System;

namespace BAG.Admin.Dataobject
{
public class U_ADM_EVNT_Ord_Dtl
{
	/// <summary>
	/// Default Contructor
	/// <summary>
	public U_ADM_EVNT_Ord_Dtl()
	{}


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

	public int Line_Id
	{ 
		get { return _Line_Id; }
		set { _Line_Id = value; }
	}
	private int _Line_Id;

	public string Ord_Id
	{ 
		get { return _Ord_Id; }
		set { _Ord_Id = value; }
	}
	private string _Ord_Id;

	public string LineItem_type
	{ 
		get { return _LineItem_type; }
		set { _LineItem_type = value; }
	}
	private string _LineItem_type;

	public decimal LineItem_Amount
	{ 
		get { return _LineItem_Amount; }
		set { _LineItem_Amount = value; }
	}
	private decimal _LineItem_Amount;

	public string LineItem_Currency
	{ 
		get { return _LineItem_Currency; }
		set { _LineItem_Currency = value; }
	}
	private string _LineItem_Currency;

	public System.DateTime Ord_Date
	{ 
		get { return _Ord_Date; }
		set { _Ord_Date = value; }
	}
	private System.DateTime _Ord_Date;

	public decimal Total_Ord_Amount
	{ 
		get { return _Total_Ord_Amount; }
		set { _Total_Ord_Amount = value; }
	}
	private decimal _Total_Ord_Amount;

	public System.DateTime Expected_FulFil_Date
	{ 
		get { return _Expected_FulFil_Date; }
		set { _Expected_FulFil_Date = value; }
	}
	private System.DateTime _Expected_FulFil_Date;

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

	public U_ADM_EVNT_Ord_Dtl(

		string Event_Id, 
		string WList_Id, 
		string Item_Id, 
		int Line_Id, 
		string Ord_Id, 
		string LineItem_type, 
		decimal LineItem_Amount, 
		string LineItem_Currency, 
		System.DateTime Ord_Date, 
		decimal Total_Ord_Amount, 
		System.DateTime Expected_FulFil_Date, 
		string COMMENTS, 
		System.DateTime Created_Date, 
		System.DateTime Updated_Date, 
		string Created_by, 
		string Updated_by)
	{

	
		this._Event_Id = Event_Id; 
		this._WList_Id = WList_Id; 
		this._Item_Id = Item_Id; 
		this._Line_Id = Line_Id; 
		this._Ord_Id = Ord_Id; 
		this._LineItem_type = LineItem_type; 
		this._LineItem_Amount = LineItem_Amount; 
		this._LineItem_Currency = LineItem_Currency; 
		this._Ord_Date = Ord_Date; 
		this._Total_Ord_Amount = Total_Ord_Amount; 
		this._Expected_FulFil_Date = Expected_FulFil_Date; 
		this._COMMENTS = COMMENTS; 
		this._Created_Date = Created_Date; 
		this._Updated_Date = Updated_Date; 
		this._Created_by = Created_by; 
		this._Updated_by = Updated_by; 
	}
}
}