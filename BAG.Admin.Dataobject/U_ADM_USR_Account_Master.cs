using System;

namespace BAG.Admin.Dataobject
{
public class U_ADM_USR_Account_Master
{
	/// <summary>
	/// Default Contructor
	/// <summary>
	public U_ADM_USR_Account_Master()
	{}


	public string Usr_Id
	{ 
		get { return _Usr_Id; }
		set { _Usr_Id = value; }
	}
	private string _Usr_Id;

	public string Bank_Acct_Number
	{ 
		get { return _Bank_Acct_Number; }
		set { _Bank_Acct_Number = value; }
	}
	private string _Bank_Acct_Number;

	public string Ifsc_Code
	{ 
		get { return _Ifsc_Code; }
		set { _Ifsc_Code = value; }
	}
	private string _Ifsc_Code;

	public string Acct_Owner_Name
	{ 
		get { return _Acct_Owner_Name; }
		set { _Acct_Owner_Name = value; }
	}
	private string _Acct_Owner_Name;

	public string Acct_Status
	{ 
		get { return _Acct_Status; }
		set { _Acct_Status = value; }
	}
	private string _Acct_Status;

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

	public U_ADM_USR_Account_Master(

		string Usr_Id, 
		string Bank_Acct_Number, 
		string Ifsc_Code, 
		string Acct_Owner_Name, 
		string Acct_Status, 
		string Media_Id_Img, 
		System.DateTime Created_Date, 
		System.DateTime Updated_Date, 
		string Created_by, 
		string Updated_by)
	{

	
		this._Usr_Id = Usr_Id; 
		this._Bank_Acct_Number = Bank_Acct_Number; 
		this._Ifsc_Code = Ifsc_Code; 
		this._Acct_Owner_Name = Acct_Owner_Name; 
		this._Acct_Status = Acct_Status; 
		this._Media_Id_Img = Media_Id_Img; 
		this._Created_Date = Created_Date; 
		this._Updated_Date = Updated_Date; 
		this._Created_by = Created_by; 
		this._Updated_by = Updated_by; 
	}
}
}