using System;

namespace BAG.Admin.Dataobject
{
public class U_ADM_PMT_GtWay_Trans
{
	/// <summary>
	/// Default Contructor
	/// <summary>
	public U_ADM_PMT_GtWay_Trans()
	{}


	public string Transaction_Id
	{ 
		get { return _Transaction_Id; }
		set { _Transaction_Id = value; }
	}
	private string _Transaction_Id;

	public string Sender_User_Id
	{ 
		get { return _Sender_User_Id; }
		set { _Sender_User_Id = value; }
	}
	private string _Sender_User_Id;

	public string Receiver_User_Id
	{ 
		get { return _Receiver_User_Id; }
		set { _Receiver_User_Id = value; }
	}
	private string _Receiver_User_Id;

	public string Ord_Id
	{ 
		get { return _Ord_Id; }
		set { _Ord_Id = value; }
	}
	private string _Ord_Id;

	public decimal Amount_Transacted
	{ 
		get { return _Amount_Transacted; }
		set { _Amount_Transacted = value; }
	}
	private decimal _Amount_Transacted;

	public string Transaction_Mode
	{ 
		get { return _Transaction_Mode; }
		set { _Transaction_Mode = value; }
	}
	private string _Transaction_Mode;

	public string ReferenceNoFromGtWay
	{ 
		get { return _ReferenceNoFromGtWay; }
		set { _ReferenceNoFromGtWay = value; }
	}
	private string _ReferenceNoFromGtWay;

	public string Other_Dtl
	{ 
		get { return _Other_Dtl; }
		set { _Other_Dtl = value; }
	}
	private string _Other_Dtl;

	public System.DateTime Transaction_Date
	{ 
		get { return _Transaction_Date; }
		set { _Transaction_Date = value; }
	}
	private System.DateTime _Transaction_Date;

	public string Transaction_Status
	{ 
		get { return _Transaction_Status; }
		set { _Transaction_Status = value; }
	}
	private string _Transaction_Status;

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

	public U_ADM_PMT_GtWay_Trans(

		string Transaction_Id, 
		string Sender_User_Id, 
		string Receiver_User_Id, 
		string Ord_Id, 
		decimal Amount_Transacted, 
		string Transaction_Mode, 
		string ReferenceNoFromGtWay, 
		string Other_Dtl, 
		System.DateTime Transaction_Date, 
		string Transaction_Status, 
		System.DateTime Created_Date, 
		System.DateTime Updated_Date, 
		string Created_by, 
		string Updated_by)
	{

	
		this._Transaction_Id = Transaction_Id; 
		this._Sender_User_Id = Sender_User_Id; 
		this._Receiver_User_Id = Receiver_User_Id; 
		this._Ord_Id = Ord_Id; 
		this._Amount_Transacted = Amount_Transacted; 
		this._Transaction_Mode = Transaction_Mode; 
		this._ReferenceNoFromGtWay = ReferenceNoFromGtWay; 
		this._Other_Dtl = Other_Dtl; 
		this._Transaction_Date = Transaction_Date; 
		this._Transaction_Status = Transaction_Status; 
		this._Created_Date = Created_Date; 
		this._Updated_Date = Updated_Date; 
		this._Created_by = Created_by; 
		this._Updated_by = Updated_by; 
	}
}
}