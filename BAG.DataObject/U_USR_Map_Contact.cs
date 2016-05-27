using System;

namespace BAG.DataObject
{
public class U_USR_Map_Contact
{
	/// <summary>
	/// Default Contructor
	/// <summary>
	public U_USR_Map_Contact()
	{}


	public string Id
	{ 
		get { return _Id; }
		set { _Id = value; }
	}
	private string _Id;

	public string Usr_Id
	{ 
		get { return _Usr_Id; }
		set { _Usr_Id = value; }
	}
	private string _Usr_Id;

	public string Contact_Id
	{ 
		get { return _Contact_Id; }
		set { _Contact_Id = value; }
	}
	private string _Contact_Id;

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

	public U_USR_Map_Contact(

		string Id, 
		string Usr_Id, 
		string Contact_Id, 
		string Comments, 
		System.DateTime Created_Date, 
		System.DateTime Updated_Date, 
		string Created_by, 
		string Updated_by)
	{

	
		this._Id = Id; 
		this._Usr_Id = Usr_Id; 
		this._Contact_Id = Contact_Id; 
		this._Comments = Comments; 
		this._Created_Date = Created_Date; 
		this._Updated_Date = Updated_Date; 
		this._Created_by = Created_by; 
		this._Updated_by = Updated_by; 
	}
}
}