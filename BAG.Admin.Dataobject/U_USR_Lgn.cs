using System;

namespace BAG.Admin.Dataobject
{
public class U_USR_Lgn
{
	/// <summary>
	/// Default Contructor
	/// <summary>
	public U_USR_Lgn()
	{}
        
    private string _Login_Id;
    private string _Usr_Mst_Id;
    private string _Email_ID;
    private string _Mobile_Number;
    private string _Pwd;
    private System.DateTime _Last_Login_Date;
    private string _Ip_Address;
    private int _Login_status;
    private System.DateTime _Created_Date;
    private System.DateTime _Updated_Date;
    private string _Created_by;
    private string _Updated_by;

    public string Login_Id
	{ 
		get { return _Login_Id; }
		set { _Login_Id = value; }
	}
    public string Usr_Mst_Id
	{ 
		get { return _Usr_Mst_Id; }
		set { _Usr_Mst_Id = value; }
	}
	public string Email_ID
	{ 
		get { return _Email_ID; }
		set { _Email_ID = value; }
	}
	public string Mobile_Number
	{ 
		get { return _Mobile_Number; }
		set { _Mobile_Number = value; }
	}
	public string Pwd
	{ 
		get { return _Pwd; }
		set { _Pwd = value; }
	}
	public System.DateTime Last_Login_Date
	{ 
		get { return _Last_Login_Date; }
		set { _Last_Login_Date = value; }
	}
	public string Ip_Address
	{ 
		get { return _Ip_Address; }
		set { _Ip_Address = value; }
	}
	public int Login_status
	{ 
		get { return _Login_status; }
		set { _Login_status = value; }
	}
	public System.DateTime Created_Date
	{ 
		get { return _Created_Date; }
		set { _Created_Date = value; }
	}
	public System.DateTime Updated_Date
	{ 
		get { return _Updated_Date; }
		set { _Updated_Date = value; }
	}
	public string Created_by
	{ 
		get { return _Created_by; }
		set { _Created_by = value; }
	}
	public string Updated_by
	{ 
		get { return _Updated_by; }
		set { _Updated_by = value; }
	}
	
	public U_USR_Lgn(

		string Login_Id, 
		string Usr_Mst_Id, 
		string Email_ID, 
		string Mobile_Number, 
		string Pwd, 
		System.DateTime Last_Login_Date, 
		string Ip_Address, 
		int Login_status, 
		System.DateTime Created_Date, 
		System.DateTime Updated_Date, 
		string Created_by, 
		string Updated_by)
	{

	
		this._Login_Id = Login_Id; 
		this._Usr_Mst_Id = Usr_Mst_Id; 
		this._Email_ID = Email_ID; 
		this._Mobile_Number = Mobile_Number; 
		this._Pwd = Pwd; 
		this._Last_Login_Date = Last_Login_Date; 
		this._Ip_Address = Ip_Address; 
		this._Login_status = Login_status; 
		this._Created_Date = Created_Date; 
		this._Updated_Date = Updated_Date; 
		this._Created_by = Created_by; 
		this._Updated_by = Updated_by; 
	}
}
}