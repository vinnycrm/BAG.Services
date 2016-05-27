using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAG.Admin.Dataobject
{
    public class MemberContacts
    {
        public string Contact_Id
        {
            get { return _Contact_Id; }
            set { _Contact_Id = value; }
        }
        private string _Contact_Id;

        public string Contact_Name
        {
            get { return _Contact_Name; }
            set { _Contact_Name = value; }
        }
        private string _Contact_Name;

        public string Contact_EmailId
        {
            get { return _Contact_EmailId; }
            set { _Contact_EmailId = value; }
        }
        private string _Contact_EmailId;

        public string Contact_Number
        {
            get { return _Contact_Number; }
            set { _Contact_Number = value; }
        }
        private string _Contact_Number;

        public MemberContacts() { }

        public MemberContacts(
            string Contact_Id,
            string Contact_Name,
            string Contact_EmailId,
            string Contact_Number
            )
        {
            _Contact_Id = Contact_Id;
            _Contact_Name = Contact_Name;
            _Contact_EmailId = Contact_EmailId;
            _Contact_Number = Contact_Number;
        }
    }
}
