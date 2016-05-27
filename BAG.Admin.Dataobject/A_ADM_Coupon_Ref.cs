using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAG.Admin.Dataobject
{
    public class A_ADM_Coupon_Ref
    {
        private string _Coupon_Id;
        private string _Coupon_Name;
        private DateTime _Coupon_StartDate;
        private DateTime _Coupon_EndDate;
        private string _Coupon_Status;

        public string Coupon_Id
        {
            get { return _Coupon_Id; }
            set { _Coupon_Id = value; }
        }
        public string Coupon_Name
        {
            get { return _Coupon_Name; }
            set { _Coupon_Name = value; }
        }
        public DateTime Coupon_StartDate
        {
            get { return _Coupon_StartDate; }
            set { _Coupon_StartDate = value; }
        }
        public DateTime Coupon_EndDate
        {
            get { return _Coupon_EndDate; }
            set { _Coupon_EndDate = value; }
        }
        public string Coupon_Status
        {
            get { return _Coupon_Status; }
            set { _Coupon_Status = value; }
        }

        public A_ADM_Coupon_Ref() { }
        public A_ADM_Coupon_Ref(
            string Coupon_Id,
            string Coupon_Name,
            DateTime Coupon_StartDate,
            DateTime Coupon_EndDate,
            string Coupon_Status)
        {
            this._Coupon_Id = Coupon_Id;
            this._Coupon_Name = Coupon_Name;
            this.Coupon_StartDate = Coupon_StartDate;
            this.Coupon_EndDate = Coupon_EndDate;
            this.Coupon_Status = Coupon_Status;
        }
    }
}
