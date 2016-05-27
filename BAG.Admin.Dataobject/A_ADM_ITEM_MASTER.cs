using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAG.Admin.Dataobject
{
    public class A_ADM_ITEM_MASTER
    {
        private string _Item_ID;
        private string _Item_PicUrl;
        private string _Item_Name;
        private decimal _Item_Price;
        private string _Item_Status;
        private string _Item_Desc;
        private string _Item_Source;
        private string _Create_By;
        private string _Update_By;

        public string Item_ID
        {
            get { return _Item_ID; }
            set { _Item_ID = value; }
        }
        public string Item_PicUrl
        {
            get { return _Item_PicUrl; }
            set { _Item_PicUrl = value; }
        }
        public string Item_Name
        {
            get { return _Item_Name; }
            set { _Item_Name = value; }
        }
        public decimal Item_Price
        {
            get { return _Item_Price; }
            set { _Item_Price = value; }
        }
        public string Item_Status
        {
            get { return _Item_Status; }
            set { _Item_Status = value; }
        }
        public string Item_Desc
        {
            get { return _Item_Desc; }
            set { _Item_Desc = value; }
        }
        public string Item_Source
        {
            get { return _Item_Source; }
            set { _Item_Source = value; }
        }
        public string Create_By
        {
            get { return _Create_By; }
            set { _Create_By = value; }
        }
        public string Update_By
        {
            get { return _Update_By; }
            set { _Update_By = value; }
        }

        public A_ADM_ITEM_MASTER() { }
        public A_ADM_ITEM_MASTER(
            string Item_ID,
            string Item_PicUrl,
            string Item_Name,
            decimal Item_Price,
            string Item_Status,
            string Item_Desc,
            string Item_Source,
            string Create_By,
            string Update_By)
        {
            this._Item_ID = Item_ID;
            this._Item_PicUrl = Item_PicUrl;
            this._Item_Name = Item_Name;
            this._Item_Price = Item_Price;
            this._Item_Status = Item_Status;
            this._Item_Desc = Item_Desc;
            this._Item_Source = Item_Source;
            this._Create_By = Create_By;
            this._Update_By = Update_By;
        }
    }
}
