using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAG.Admin.Dataobject
{
    public class DashboardEvents
    {
        public string Event_Id
        {
            get { return _Event_Id; }
            set { _Event_Id = value; }
        }
        private string _Event_Id;

        public string Event_Name
        {
            get { return _Event_Name; }
            set { _Event_Name = value; }
        }
        private string _Event_Name;

        public string Event_Organizer
        {
            get { return _Event_Organizer; }
            set { _Event_Organizer = value; }
        }
        private string _Event_Organizer;

        public DateTime Event_CreateDate
        {
            get { return _Event_CreateDate; }
            set { _Event_CreateDate = value; }
        }
        private DateTime _Event_CreateDate;

        public DashboardEvents() { }

        public DashboardEvents(
            string Event_Id,
            string Event_Name,
            string Event_Organizer,
            DateTime Event_CreateDate
            )
        {
            this._Event_Id = Event_Id;
            this._Event_Name = Event_Name;
            this._Event_Organizer = Event_Organizer;
            this.Event_CreateDate = Event_CreateDate;
        }
    }
}
