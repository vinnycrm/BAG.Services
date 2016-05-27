using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAG.Admin.Dataobject
{
    public class Coupons
    {
        public string Coupon_id
        {
            get { return _Coupon_id; }
            set { _Coupon_id = value; }
        }
        private string _Coupon_id;

        public string Coupon_Name
        {
            get { return _Coupon_Name; }
            set { _Coupon_Name = value; }
        }
        private string _Coupon_Name;

        public string Coupon_VenderName
        {
            get { return _Coupon_VenderName; }
            set { _Coupon_VenderName = value; }
        }
        private string _Coupon_VenderName;

        public string Coupon_Desc
        {
            get { return _Coupon_Desc; }
            set { _Coupon_Desc = value; }
        }
        private string _Coupon_Desc;

        public DateTime Coupon_StartDate
        {
            get { return _Coupon_StartDate; }
            set { _Coupon_StartDate = value; }
        }
        private DateTime _Coupon_StartDate;

        public DateTime Coupon_EndDate
        {
            get { return _Coupon_EndDate; }
            set { _Coupon_EndDate = value; }
        }
        private DateTime _Coupon_EndDate;

        public string Coupon_Status
        {
            get { return _Coupon_Status; }
            set { _Coupon_Status = value; }
        }
        private string _Coupon_Status;

        public string Coupon_PicUrl
        {
            get { return _Coupon_PicUrl; }
            set { _Coupon_PicUrl = value; }
        }
        private string _Coupon_PicUrl;

        public string Create_By
        {
            get { return _Create_By; }
            set { _Create_By = value; }
        }
        private string _Create_By;

        public string Update_By
        {
            get { return _Update_By; }
            set { _Update_By = value; }
        }
        private string _Update_By;

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

        public Coupons() { }
        public Coupons(
            string Coupon_id,
            string Coupon_Name,
            string Coupon_VenderName,
            string Coupon_Desc,
            DateTime Coupon_StartDate,
            DateTime Coupon_EndDate,
            string Coupon_Status,
            string Coupon_PicUrl,
            string Create_By,
            string Update_By,
            DateTime Create_Date,
            DateTime Update_Date
            )
        {
            this._Coupon_id = Coupon_id;
            this._Coupon_Name = Coupon_Name;
            this._Coupon_VenderName = Coupon_VenderName;
            this._Coupon_Desc = Coupon_Desc;
            this._Coupon_StartDate = Coupon_StartDate;
            this._Coupon_EndDate = Coupon_EndDate;
            this._Coupon_Status = Coupon_Status;
            this._Coupon_PicUrl = Coupon_PicUrl;
            this._Create_By = Create_By;
            this._Update_By = Update_By;
            this._Create_Date = Create_Date;
            this._Update_Date = Update_Date;
        }
    }
}
