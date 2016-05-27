using System;

namespace BAG.Admin.Dataobject
{
public class U_ADM_MEDIA_MASTER
{
	/// <summary>
	/// Default Contructor
	/// <summary>
	public U_ADM_MEDIA_MASTER()
	{}


	public string Media_Id
	{ 
		get { return _Media_Id; }
		set { _Media_Id = value; }
	}
	private string _Media_Id;

	public string Media_Type
	{ 
		get { return _Media_Type; }
		set { _Media_Type = value; }
	}
	private string _Media_Type;

	public string Media_File_Location
	{ 
		get { return _Media_File_Location; }
		set { _Media_File_Location = value; }
	}
	private string _Media_File_Location;

	public string Media_Source
	{ 
		get { return _Media_Source; }
		set { _Media_Source = value; }
	}
	private string _Media_Source;

	public string Media_Oth_Dtl
	{ 
		get { return _Media_Oth_Dtl; }
		set { _Media_Oth_Dtl = value; }
	}
	private string _Media_Oth_Dtl;

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

	public U_ADM_MEDIA_MASTER(

		string Media_Id, 
		string Media_Type, 
		string Media_File_Location, 
		string Media_Source, 
		string Media_Oth_Dtl, 
		System.DateTime Created_Date, 
		System.DateTime Updated_Date, 
		string Created_by, 
		string Updated_by)
	{

	
		this._Media_Id = Media_Id; 
		this._Media_Type = Media_Type; 
		this._Media_File_Location = Media_File_Location; 
		this._Media_Source = Media_Source; 
		this._Media_Oth_Dtl = Media_Oth_Dtl; 
		this._Created_Date = Created_Date; 
		this._Updated_Date = Updated_Date; 
		this._Created_by = Created_by; 
		this._Updated_by = Updated_by; 
	}
}
}