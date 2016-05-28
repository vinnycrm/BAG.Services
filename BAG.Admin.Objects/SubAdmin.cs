using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAG.Admin.Dataobject
{
    public class SubAdmin
    {
        public string Usr_Id
        {
            get { return _Usr_Id; }
            set { _Usr_Id = value; }
        }
        private string _Usr_Id;

        public string First_Name
        {
            get { return _First_Name; }
            set { _First_Name = value; }
        }
        private string _First_Name;

        public string Last_Name
        {
            get { return _Last_Name; }
            set { _Last_Name = value; }
        }
        private string _Last_Name;

        public string Alt_Email_Id
        {
            get { return _Alt_Email_Id; }
            set { _Alt_Email_Id = value; }
        }
        private string _Alt_Email_Id;

        public string Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }
        private string _Gender;

        public int Usr_role_Id
        {
            get { return _Usr_role_Id; }
            set { _Usr_role_Id = value; }
        }
        private int _Usr_role_Id;

        public string Mobile_Number
        {
            get { return _Mobile_Number; }
            set { _Mobile_Number = value; }
        }
        private string _Mobile_Number;

        public int Login_status
        {
            get { return _Login_status; }
            set { _Login_status = value; }
        }
        private int _Login_status;

        public string Media_File_Location
        {
            get { return _Media_File_Location; }
            set { _Media_File_Location = value; }
        }
        private string _Media_File_Location;

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

        public SubAdmin() { }

        public SubAdmin(
            string Usr_Id,
            string First_Name,
            string Last_Name,
            string Alt_Email_Id,
            string Gender,
            int Usr_role_Id,
            string Mobile_Number,
            int Login_status,
            string Media_File_Location,
            DateTime Created_Date,
            DateTime Updated_Date,
            string Created_by,
            string Updated_by
            )
        {
            _Usr_Id = Usr_Id;
            _First_Name = First_Name;
            _Last_Name = Last_Name;
            _Alt_Email_Id = Alt_Email_Id;
            _Gender = Gender;
            _Usr_role_Id = Usr_role_Id;
            _Mobile_Number = Mobile_Number;
            _Login_status = Login_status;
            _Media_File_Location = Media_File_Location;
            _Created_Date = Created_Date;
            _Updated_Date = Updated_Date;
            _Created_by = Created_by;
            _Updated_by = Updated_by;
        }
    }
}
