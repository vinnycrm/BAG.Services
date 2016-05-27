using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAG.Admin.Dataobject
{
    public class Event
    {
        public string Event_id
        {
            get { return _Event_id; }
            set { _Event_id = value; }
        }
        private string _Event_id;

        public string Event_Name
        {
            get { return _Event_Name; }
            set { _Event_Name = value; }
        }
        private string _Event_Name;

        public string Event_Location
        {
            get { return _Event_Location; }
            set { _Event_Location = value; }
        }
        private string _Event_Location;

        public string Event_Desc
        {
            get { return _Event_Desc; }
            set { _Event_Desc = value; }
        }
        private string _Event_Desc;

        public string Event_Status
        {
            get { return _Event_Status; }
            set { _Event_Status = value; }
        }
        private string _Event_Status;

        public DateTime Event_StartDate
        {
            get { return _Event_StartDate; }
            set { _Event_StartDate = value; }
        }
        private DateTime _Event_StartDate;

        public DateTime Event_EndDate
        {
            get { return _Event_EndDate; }
            set { _Event_EndDate = value; }
        }
        private DateTime _Event_EndDate;

        public string Event_Organizer
        {
            get { return _Event_Organizer; }
            set { _Event_Organizer = value; }
        }
        private string _Event_Organizer;

        public string Event_TotalFund
        {
            get { return _Event_TotalFund; }
            set { _Event_TotalFund = value; }
        }
        private string _Event_TotalFund;

        public string Event_TotalContributors
        {
            get { return _Event_TotalContributors; }
            set { _Event_TotalContributors = value; }
        }
        private string _Event_TotalContributors;

        public string Event_TotalComments
        {
            get { return _Event_TotalComments; }
            set { _Event_TotalComments = value; }
        }
        private string _Event_TotalComments;

        public string Event_PicUrl
        {
            get { return _Event_PicUrl; }
            set { _Event_PicUrl = value; }
        }
        private string _Event_PicUrl;

        public string Event_Update_by
        {
            get { return _Event_Update_by; }
            set { _Event_Update_by = value; }
        }
        private string _Event_Update_by;

        public Event() { }

        public Event(
            string Event_id,
            string Event_Name,
            string Event_Location,
            string Event_Desc,
            string Event_Status,
            DateTime Event_StartDate,
            DateTime Event_EndDate,
            string Event_Organizer,
            string Event_TotalFund,
            string Event_TotalContributors,
            string Event_TotalComments,
            string Event_PicUrl,
            string Event_Update_by
            )
        {
            this._Event_id = Event_id;
            this._Event_Name = Event_Name;
            this._Event_Location = Event_Location;
            this._Event_Desc = Event_Desc;
            this._Event_Status = Event_Status;
            this._Event_StartDate = Event_StartDate;
            this._Event_EndDate = Event_EndDate;
            this._Event_Organizer = Event_Organizer;
            this._Event_TotalFund = Event_TotalFund;
            this._Event_TotalContributors = Event_TotalContributors;
            this._Event_TotalComments = Event_TotalComments;
            this._Event_PicUrl = Event_PicUrl;
            this._Event_Update_by = Event_Update_by;
        }
    }
}
