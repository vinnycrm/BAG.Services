using System;

namespace BAG.Admin.Dataobject
{
public class U_ADM_EVNT_Ord_FulFil_Dtl
{
	/// <summary>
	/// Default Contructor
	/// <summary>
	public U_ADM_EVNT_Ord_FulFil_Dtl()
	{}


	public string Ord_Id
	{ 
		get { return _Ord_Id; }
		set { _Ord_Id = value; }
	}
	private string _Ord_Id;

	public int Line_Id
	{ 
		get { return _Line_Id; }
		set { _Line_Id = value; }
	}
	private int _Line_Id;

	public string Ext_Vendor_Ord_Id
	{ 
		get { return _Ext_Vendor_Ord_Id; }
		set { _Ext_Vendor_Ord_Id = value; }
	}
	private string _Ext_Vendor_Ord_Id;

	public System.DateTime Ext_Vendor_Ord_Date
	{ 
		get { return _Ext_Vendor_Ord_Date; }
		set { _Ext_Vendor_Ord_Date = value; }
	}
	private System.DateTime _Ext_Vendor_Ord_Date;

	public string Ext_Vendor_Ord_Dtl
	{ 
		get { return _Ext_Vendor_Ord_Dtl; }
		set { _Ext_Vendor_Ord_Dtl = value; }
	}
	private string _Ext_Vendor_Ord_Dtl;

	public System.DateTime FulFil_Date
	{ 
		get { return _FulFil_Date; }
		set { _FulFil_Date = value; }
	}
	private System.DateTime _FulFil_Date;

	public string FulFil_Status
	{ 
		get { return _FulFil_Status; }
		set { _FulFil_Status = value; }
	}
	private string _FulFil_Status;

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

	public U_ADM_EVNT_Ord_FulFil_Dtl(

		string Ord_Id, 
		int Line_Id, 
		string Ext_Vendor_Ord_Id, 
		System.DateTime Ext_Vendor_Ord_Date, 
		string Ext_Vendor_Ord_Dtl, 
		System.DateTime FulFil_Date, 
		string FulFil_Status, 
		string Comments, 
		System.DateTime Created_Date, 
		System.DateTime Updated_Date, 
		string Created_by, 
		string Updated_by)
	{

	
		this._Ord_Id = Ord_Id; 
		this._Line_Id = Line_Id; 
		this._Ext_Vendor_Ord_Id = Ext_Vendor_Ord_Id; 
		this._Ext_Vendor_Ord_Date = Ext_Vendor_Ord_Date; 
		this._Ext_Vendor_Ord_Dtl = Ext_Vendor_Ord_Dtl; 
		this._FulFil_Date = FulFil_Date; 
		this._FulFil_Status = FulFil_Status; 
		this._Comments = Comments; 
		this._Created_Date = Created_Date; 
		this._Updated_Date = Updated_Date; 
		this._Created_by = Created_by; 
		this._Updated_by = Updated_by; 
	}
}
}