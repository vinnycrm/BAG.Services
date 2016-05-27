using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAG.Admin.Dataobject
{
    public class EventsWishList
    {
        public string WishList_Id
        {
            get { return _WishList_Id; }
            set { _WishList_Id = value; }
        }
        private string _WishList_Id;

        public string WishList_Name
        {
            get { return _WishList_Name; }
            set { _WishList_Name = value; }
        }
        private string _WishList_Name;

        public EventsWishList() { }

        public EventsWishList(
            string WishList_Id,
            string WishList_Name
            )
        {
            this._WishList_Id = WishList_Id;
            this._WishList_Name = WishList_Name;
        }
    }
}
