using System;

namespace BAG.Admin.Dataobject
{
public class U_ADM_Coupon_Ref
{
	/// <summary>
	/// Default Contructor
	/// <summary>
	public U_ADM_Coupon_Ref()
	{}


	public string Coupon_ID
	{ 
		get { return _Coupon_ID; }
		set { _Coupon_ID = value; }
	}
	private string _Coupon_ID;

	public string Coupon_Name
	{ 
		get { return _Coupon_Name; }
		set { _Coupon_Name = value; }
	}
	private string _Coupon_Name;

	public string Coupon_VendorName
	{ 
		get { return _Coupon_VendorName; }
		set { _Coupon_VendorName = value; }
	}
	private string _Coupon_VendorName;

	public string Coupon_Desc
	{ 
		get { return _Coupon_Desc; }
		set { _Coupon_Desc = value; }
	}
	private string _Coupon_Desc;

	public System.DateTime Coupon_StartDate
	{ 
		get { return _Coupon_StartDate; }
		set { _Coupon_StartDate = value; }
	}
	private System.DateTime _Coupon_StartDate;

	public System.DateTime Coupon_EndDate
	{ 
		get { return _Coupon_EndDate; }
		set { _Coupon_EndDate = value; }
	}
	private System.DateTime _Coupon_EndDate;

	public string Coupon_Status
	{ 
		get { return _Coupon_Status; }
		set { _Coupon_Status = value; }
	}
	private string _Coupon_Status;

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

	public U_ADM_Coupon_Ref(

		string Coupon_ID, 
		string Coupon_Name, 
		string Coupon_VendorName, 
		string Coupon_Desc, 
		System.DateTime Coupon_StartDate, 
		System.DateTime Coupon_EndDate, 
		string Coupon_Status, 
		string Media_Id_Img, 
		System.DateTime Created_Date, 
		System.DateTime Updated_Date, 
		string Created_by, 
		string Updated_by)
	{

	
		this._Coupon_ID = Coupon_ID; 
		this._Coupon_Name = Coupon_Name; 
		this._Coupon_VendorName = Coupon_VendorName; 
		this._Coupon_Desc = Coupon_Desc; 
		this._Coupon_StartDate = Coupon_StartDate; 
		this._Coupon_EndDate = Coupon_EndDate; 
		this._Coupon_Status = Coupon_Status; 
		this._Media_Id_Img = Media_Id_Img; 
		this._Created_Date = Created_Date; 
		this._Updated_Date = Updated_Date; 
		this._Created_by = Created_by; 
		this._Updated_by = Updated_by; 
	}
}
}