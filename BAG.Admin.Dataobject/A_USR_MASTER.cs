using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAG.Admin.Dataobject
{
    public class A_USR_MASTER_V2
    {
        public string Uid
        {
            get { return _Uid; }
            set { _Uid = value; }
        }
        private string _Uid;

        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        private string _FirstName;

        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        private string _LastName;

        public string EmailId
        {
            get { return _EmailId; }
            set { _EmailId = value; }
        }
        private string _EmailId;

        public string Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }
        private string _Gender;

        public DateTime Dob
        {
            get { return _Dob; }
            set { _Dob = value; }
        }
        private DateTime _Dob;

        public string MobileNumber
        {
            get { return _MobileNumber; }
            set { _MobileNumber = value; }
        }
        private string _MobileNumber;

        public Int16 IsMarried
        {
            get { return _IsMarried; }
            set { _IsMarried = value; }
        }
        private Int16 _IsMarried;

        public DateTime WedAnvrsry
        {
            get { return _WedAnvrsry; }
            set { _WedAnvrsry = value; }
        }
        private DateTime _WedAnvrsry;

        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        private string _Address;

        public string PicUrl
        {
            get { return _PicUrl; }
            set { _PicUrl = value; }
        }
        private string _PicUrl;

        public string Ratings
        {
            get { return _Ratings; }
            set { _Ratings = value; }
        }
        private string _Ratings;

        public string Created_By
        {
            get { return _Created_By; }
            set { _Created_By = value; }
        }
        private string _Created_By;

        public string Updated_By
        {
            get { return _Updated_By; }
            set { _Updated_By = value; }
        }
        private string _Updated_By;

        public DateTime Create_Date
        {
            get { return _Create_Date; }
            set { _Create_Date = value; }
        }
        private DateTime _Create_Date;

        public DateTime Update_Date
        {
            get { return _Update_Date; }
            set { _Update_Date = value; }
        }
        private DateTime _Update_Date;

        public A_USR_MASTER_V2() { }
        public A_USR_MASTER_V2(
            string Uid,
            string FirstName,
            string LastName,
            string EmailId,
            string Gender,
            DateTime Dob,
            string MobileNumber,
            Int16 IsMarried,
            DateTime WedAnvrsry,
            string Address,
            string PicUrl,
            string Ratings,
            string Created_By,
            string Updated_By,
            DateTime Create_Date,
            DateTime Update_Date
            )
        {
            _Uid = Uid;
            _FirstName = FirstName;
            _LastName = LastName;
            _EmailId = EmailId;
            _Gender = Gender;
            _Dob = Dob;
            _MobileNumber = MobileNumber;
            _IsMarried = IsMarried;
            _WedAnvrsry = WedAnvrsry;
            _Address = Address;
            _PicUrl = PicUrl;
            _Ratings = Ratings;
            _Created_By = Created_By;
            _Updated_By = Updated_By;
            _Create_Date = Create_Date;
            _Update_Date = Update_Date;
        }
    }

    public class A_USR_MASTER_V3
    {
        public string Usr_Id
        {
            get { return _Usr_Id; }
            set { _Usr_Id = value; }
        }
        private string _Usr_Id;

        public string FistName
        {
            get { return _FistName; }
            set { _FistName = value; }
        }
        private string _FistName;

        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        private string _LastName;

        public string EmailId
        {
            get { return _EmailId; }
            set { _EmailId = value; }
        }
        private string _EmailId;

        public string MobileNumber
        {
            get { return _MobileNumber; }
            set { _MobileNumber = value; }
        }
        private string _MobileNumber;

        public string Pwd
        {
            get { return _Pwd; }
            set { _Pwd = value; }
        }
        private string _Pwd;

        public string Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }
        private string _Gender;

        public DateTime Dob
        {
            get { return _Dob; }
            set { _Dob = value; }
        }
        private DateTime _Dob;

        public string AboutMember
        {
            get { return _AboutMember; }
            set { _AboutMember = value; }
        }
        private string _AboutMember;

        public string AddressType
        {
            get { return _AddressType; }
            set { _AddressType = value; }
        }
        private string _AddressType;

        public string AddressLine1
        {
            get { return _AddressLine1; }
            set { _AddressLine1 = value; }
        }
        private string _AddressLine1;

        public string AddressLine2
        {
            get { return _AddressLine2; }
            set { _AddressLine2 = value; }
        }
        private string _AddressLine2;

        public string AddressLine3
        {
            get { return _AddressLine3; }
            set { _AddressLine3 = value; }
        }
        private string _AddressLine3;

        public string City
        {
            get { return _City; }
            set { _City = value; }
        }
        private string _City;

        public string PinCode
        {
            get { return _PinCode; }
            set { _PinCode = value; }
        }
        private string _PinCode;

        public string State
        {
            get { return _State; }
            set { _State = value; }
        }
        private string _State;

        public string Country
        {
            get { return _Country; }
            set { _Country = value; }
        }
        private string _Country;

        public string UserRole
        {
            get { return _UserRole; }
            set { _UserRole = value; }
        }
        private string _UserRole;

        public string Ip_Address
        {
            get { return _Ip_Address; }
            set { _Ip_Address = value; }
        }
        private string _Ip_Address;

        public string CreateBy
        {
            get { return _CreateBy; }
            set { _CreateBy = value; }
        }
        private string _CreateBy;

        public string UpdateBy
        {
            get { return _UpdateBy; }
            set { _UpdateBy = value; }
        }
        private string _UpdateBy;

        public DateTime CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = value; }
        }
        private DateTime _CreatedDate;

        public DateTime UpdateDate
        {
            get { return _UpdateDate; }
            set { _UpdateDate = value; }
        }
        private DateTime _UpdateDate;

        public A_USR_MASTER_V3() { }
        public A_USR_MASTER_V3(
            string Usr_Id,
            string FistName,
            string LastName,
            string EmailId,
            string MobileNumber,
            string Pwd,
            string Gender,
            DateTime Dob,
            string AboutMember,
            string AddressType,
            string AddressLine1,
            string AddressLine2,
            string AddressLine3,
            string City,
            string PinCode,
            string State,
            string Country,
            string UserRole,
            string Ip_Address,
            string CreateBy,
            string UpdateBy,
            DateTime CreatedDate,
            DateTime UpdateDate
            )
        {
            _Usr_Id = Usr_Id;
            _FistName = FistName;
            _LastName = LastName;
            _EmailId = EmailId;
            _MobileNumber = MobileNumber;
            _Pwd = Pwd;
            _Gender = Gender;
            _Dob = Dob;
            _AboutMember = AboutMember;
            _AddressLine1 = AddressLine1;
            _AddressLine2 = AddressLine2;
            _AddressLine3 = AddressLine3;
            _City = City;
            _PinCode = PinCode;
            _State = State;
            _Country = Country;
            _UserRole = UserRole;
            _Ip_Address = Ip_Address;
            _CreateBy = CreateBy;
            _UpdateBy = UpdateBy;
            _CreatedDate = CreatedDate;
            _UpdateDate = UpdateDate;
        }
    }
}
