using System;

namespace BAG.Admin.Dataobject
{
public class U_ADM_ITEM_MASTER
{
	/// <summary>
	/// Default Contructor
	/// <summary>
	public U_ADM_ITEM_MASTER()
	{}


	public string Item_Id
	{ 
		get { return _Item_Id; }
		set { _Item_Id = value; }
	}
	private string _Item_Id;

	public string Item_Name
	{ 
		get { return _Item_Name; }
		set { _Item_Name = value; }
	}
	private string _Item_Name;

	public string Item_Desc
	{ 
		get { return _Item_Desc; }
		set { _Item_Desc = value; }
	}
	private string _Item_Desc;

	public string Item_Status
	{ 
		get { return _Item_Status; }
		set { _Item_Status = value; }
	}
	private string _Item_Status;

	public decimal Item_Tentative_Cost
	{ 
		get { return _Item_Tentative_Cost; }
		set { _Item_Tentative_Cost = value; }
	}
	private decimal _Item_Tentative_Cost;

	public string Item_Source
	{ 
		get { return _Item_Source; }
		set { _Item_Source = value; }
	}
	private string _Item_Source;

	public string Media_Id_Img
	{ 
		get { return _Media_Id_Img; }
		set { _Media_Id_Img = value; }
	}
	private string _Media_Id_Img;

	public string Media_Id_Video
	{ 
		get { return _Media_Id_Video; }
		set { _Media_Id_Video = value; }
	}
	private string _Media_Id_Video;

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

	public U_ADM_ITEM_MASTER(

		string Item_Id, 
		string Item_Name, 
		string Item_Desc, 
		string Item_Status, 
		decimal Item_Tentative_Cost, 
		string Item_Source, 
		string Media_Id_Img, 
		string Media_Id_Video, 
		System.DateTime Created_Date, 
		System.DateTime Updated_Date, 
		string Created_by, 
		string Updated_by)
	{

	
		this._Item_Id = Item_Id; 
		this._Item_Name = Item_Name; 
		this._Item_Desc = Item_Desc; 
		this._Item_Status = Item_Status; 
		this._Item_Tentative_Cost = Item_Tentative_Cost; 
		this._Item_Source = Item_Source; 
		this._Media_Id_Img = Media_Id_Img; 
		this._Media_Id_Video = Media_Id_Video; 
		this._Created_Date = Created_Date; 
		this._Updated_Date = Updated_Date; 
		this._Created_by = Created_by; 
		this._Updated_by = Updated_by; 
	}
}
}