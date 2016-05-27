using System;

namespace BAG.Admin.Dataobject
{
public class U_ADM_USR_ROLE_MASTER
{
	/// <summary>
	/// Default Contructor
	/// <summary>
	public U_ADM_USR_ROLE_MASTER()
	{}


	public string Usr_Role_Id
	{ 
		get { return _Usr_Role_Id; }
		set { _Usr_Role_Id = value; }
	}
	private string _Usr_Role_Id;

	public string Role_Name
	{ 
		get { return _Role_Name; }
		set { _Role_Name = value; }
	}
	private string _Role_Name;

	public string Role_type
	{ 
		get { return _Role_type; }
		set { _Role_type = value; }
	}
	private string _Role_type;

	public string Role_Description
	{ 
		get { return _Role_Description; }
		set { _Role_Description = value; }
	}
	private string _Role_Description;

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

	public U_ADM_USR_ROLE_MASTER(

		string Usr_Role_Id, 
		string Role_Name, 
		string Role_type, 
		string Role_Description, 
		System.DateTime Created_Date, 
		System.DateTime Updated_Date, 
		string Created_by, 
		string Updated_by)
	{

	
		this._Usr_Role_Id = Usr_Role_Id; 
		this._Role_Name = Role_Name; 
		this._Role_type = Role_type; 
		this._Role_Description = Role_Description; 
		this._Created_Date = Created_Date; 
		this._Updated_Date = Updated_Date; 
		this._Created_by = Created_by; 
		this._Updated_by = Updated_by; 
	}
}
}