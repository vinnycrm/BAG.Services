using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAG.Admin.Dataobject
{
    public class DashboardMember
    {
        public DashboardMember() { }

        public string Member_Id
        {
            get { return _Member_Id; }
            set { _Member_Id = value; }
        }
        private string _Member_Id;

        public string Member_Name
        {
            get { return _Member_Name; }
            set { _Member_Name = value; }
        }
        private string _Member_Name;

        public string Member_EmailId
        {
            get { return _Member_EmailId; }
            set { _Member_EmailId = value; }
        }
        private string _Member_EmailId;

        public DateTime Member_CreatedDate
        {
            get { return _Member_CreatedDate; }
            set { _Member_CreatedDate = value; }
        }
        private DateTime _Member_CreatedDate;

        public DashboardMember(
            string Member_Id,
            string Member_Name,
            string Member_EmailId,
            DateTime Member_CreatedDate
            )
        {
            this._Member_Id = Member_Id;
            this._Member_Name = Member_Name;
            this._Member_EmailId = Member_EmailId;
            this._Member_CreatedDate = Member_CreatedDate;
        }
    }
}
