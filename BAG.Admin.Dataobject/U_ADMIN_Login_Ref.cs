using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAG.Admin.Dataobject
{
    public class U_ADMIN_Login_Ref
    {
        private string _UserId;
        private string _UserName;

        public string UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        public U_ADMIN_Login_Ref() { }
        public U_ADMIN_Login_Ref(string uid, string uname)
        {
            _UserId = uid;
            _UserName = uname;
        }

    }

    public class Admin_Members
    {
        private string _UserId;
        private string _FirstName;
        private string _LastName;
        private string _Email;
        private string _Gender;
        private int _LoginStatus;

        public string UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        public string Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }
        public int LoginStatus
        {
            get { return _LoginStatus; }
            set { _LoginStatus = value; }
        }
        
        public Admin_Members() { }
        public Admin_Members(string UserId, string FirstName, string LastName, string Email, string Gender, int LoginStatus)
        {
            _UserId = UserId;
            _FirstName = FirstName;
            _LastName = LastName;
            _Gender = Gender;
            _Email = Email;
            _LoginStatus = LoginStatus;
        }

    }
}
