using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BAGservice.ServiceInterface;
using BAG.Admin.Dataaccess;
using BAG.Admin.Dataobject;

namespace BAGservice.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AdminService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AdminService.svc or AdminService.svc.cs at the Solution Explorer and start debugging.
    public class AdminService : IAdminService
    {
        public A_ADM_Coupon_Ref[] GetCouponsDetails()
        {
            A_ADM_Coupon_RefDAL obj = new A_ADM_Coupon_RefDAL();
            var data = obj.GetCouponsDetailsDb();
            return data;
        }

        public U_EVNT_MASTER[] GetEventsDetailsDb()
        {
            U_EVNT_MASTERDAL obj = new U_EVNT_MASTERDAL();
            var data = obj.GetEventsDetailsDb();
            return data;
        }

        public A_ADM_ITEM_MASTER[] GetItemsDetails()
        {
            A_ADM_ITEM_MASTERDAL obj = new A_ADM_ITEM_MASTERDAL();
            var data = obj.GetItemsDetailsDb();
            return data;
        }

        public U_ADMIN_Login_Ref getLoginValidate(U_USR_Lgn Newlogin)
        {
            U_USR_LgnDAL obj = new U_USR_LgnDAL();
            return obj.GetLoginDetails(Newlogin.Email_ID, Newlogin.Pwd);
        }

        public Admin_Members[] GetMembersDetails()
        {
            U_USR_MASTERDAL obj1 = new U_USR_MASTERDAL();
            var data = obj1.GetMembersDetailsDb();
            return data;
        }

        public A_USR_MASTER_V2 GetSingleMemberDetails(string id)
        {
            U_USR_MASTERDAL obj = new U_USR_MASTERDAL();
            A_USR_MASTER_V2 data = obj.GetSingleMemberDetailsDb(id);
            return data;
        }

        public bool InsertSubAdmin(A_ModelGroupsList SubAdmin)
        {
            U_USR_MASTERDAL obj = new U_USR_MASTERDAL();
            U_USR_LgnDAL obj1 = new U_USR_LgnDAL();
            U_ADM_MEDIA_MASTERDAL ImgDAL = new U_ADM_MEDIA_MASTERDAL();
            U_ADM_MEDIA_MASTER imgData = new U_ADM_MEDIA_MASTER();

            DateTime now = System.DateTime.Now;

            imgData.Media_Id = Guid.NewGuid().ToString();
            imgData.Media_Type = "Image";
            imgData.Media_File_Location = SubAdmin.MasterData.Media_Id_Img;
            imgData.Media_Source = " ";
            imgData.Media_Oth_Dtl = " ";
            imgData.Created_by = SubAdmin.MasterData.Created_by;
            imgData.Updated_by = SubAdmin.MasterData.Updated_by;
            imgData.Created_Date = DateTime.Now;
            imgData.Updated_Date = DateTime.Now;
            ImgDAL.InsertU_ADM_MEDIA_MASTER(imgData);


            SubAdmin.MasterData.Usr_Id = System.Guid.NewGuid().ToString();
            SubAdmin.MasterData.Address_Id = "1";
            SubAdmin.MasterData.Media_Id_Img = imgData.Media_Id;
            SubAdmin.MasterData.Created_Date = DateTime.Now;
            SubAdmin.MasterData.Updated_Date = DateTime.Now;
            SubAdmin.MasterData.Alt_Email_Id = SubAdmin.LoginData.Email_ID;
            SubAdmin.MasterData.Gender = SubAdmin.MasterData.Gender;
            SubAdmin.MasterData.About_member = "";
            SubAdmin.MasterData.Rating = "1";

            SubAdmin.LoginData.Login_Id = System.Guid.NewGuid().ToString();
            SubAdmin.LoginData.Usr_Mst_Id = SubAdmin.MasterData.Usr_Id;
            SubAdmin.LoginData.Updated_Date = DateTime.Now;
            SubAdmin.LoginData.Last_Login_Date = DateTime.Now;
            SubAdmin.LoginData.Created_Date = DateTime.Now;
            SubAdmin.LoginData.Ip_Address = "";
            SubAdmin.LoginData.Login_status = 1;
            SubAdmin.LoginData.Created_by = SubAdmin.MasterData.Created_by;
            SubAdmin.LoginData.Updated_by = SubAdmin.MasterData.Updated_by;

            SubAdmin.MasterData.Date_Of_Birth = DateTime.Now;
            SubAdmin.MasterData.Wed_anniversary = DateTime.Now;

            if (obj.InsertU_USR_MASTER(SubAdmin.MasterData))
                if (obj1.InsertU_USR_Lgn(SubAdmin.LoginData))
                    return true;
            return false;
        }

        public bool InsertNewItem(U_ADM_ITEM_MASTER item)
        {
            A_ADM_ITEM_MASTERDAL obj = new A_ADM_ITEM_MASTERDAL();
            U_ADM_MEDIA_MASTERDAL objImg = new U_ADM_MEDIA_MASTERDAL();
            U_ADM_MEDIA_MASTER imgData = new U_ADM_MEDIA_MASTER();

            imgData.Media_Id = Guid.NewGuid().ToString();
            imgData.Media_Type = "Image";
            imgData.Media_File_Location = item.Media_Id_Img;
            imgData.Media_Source = "";
            imgData.Media_Oth_Dtl = "";
            imgData.Created_by = item.Created_by;
            imgData.Updated_by = item.Updated_by;
            imgData.Created_Date = DateTime.Now;
            imgData.Updated_Date = DateTime.Now;

            item.Item_Id = imgData.Media_Id;
            item.Item_Status = "1";
            item.Item_Source = "No Source";
            item.Media_Id_Video = " ";
            item.Created_Date = DateTime.Now;
            item.Updated_Date = DateTime.Now;
            if (objImg.InsertU_ADM_MEDIA_MASTER(imgData))
            {
                item.Media_Id_Img = imgData.Media_Id;
                if (obj.InsertU_ADM_ITEM_MASTER(item))
                {
                    return true;
                }
            }
            return false;
        }

        public A_ADM_ITEM_MASTER GetSingleItemDetails(string id)
        {
            A_ADM_ITEM_MASTERDAL obj = new A_ADM_ITEM_MASTERDAL();
            A_ADM_ITEM_MASTER data = obj.GetSingleItemDetailsDb(id);
            return data;
        }

        public bool GetBlockThisItem(string Id)
        {
            A_ADM_ITEM_MASTERDAL obj = new A_ADM_ITEM_MASTERDAL();
            return obj.GetBlockThisItemDb(Id);
        }

        public bool GetUnblockThisItem(string Id)
        {
            A_ADM_ITEM_MASTERDAL obj = new A_ADM_ITEM_MASTERDAL();
            return obj.GetUnblockThisItemDb(Id);
        }

        public Groups[] GetHisGroups(string Id)
        {
            U_USR_GroupsDAL obj = new U_USR_GroupsDAL();
            var data = obj.GetHisGroupsDetailsDb(Id);
            return data;
        }

        public Groups[] GetJoinedGroups(string Id)
        {
            U_USR_GroupsDAL obj = new U_USR_GroupsDAL();
            var data = obj.GetJoinedGroupsDetailsDb(Id);
            return data;
        }

        public bool GetBlockThisUser(string Id)
        {
            U_USR_MASTERDAL obj = new U_USR_MASTERDAL();
            return obj.GetBlockThisUserDb(Id);
        }

        public bool GetUnblockThisUser(string Id)
        {
            U_USR_MASTERDAL obj = new U_USR_MASTERDAL();
            return obj.GetUnblockThisUserDb(Id);
        }

        public Event GetSingleEventDetails(string Id)
        {
            U_EVNT_MASTERDAL obj = new U_EVNT_MASTERDAL();
            Event data = obj.GetSingleEventDetailsDb(Id);
            data.Event_TotalFund = "0000";
            data.Event_TotalContributors = "0000";
            return data;
        }

        public EventsWishList[] GetEventWishListDetails(string Id)
        {
            U_EVNT_MASTERDAL obj = new U_EVNT_MASTERDAL();
            EventsWishList[] data = obj.GetEventWishListDb(Id);
            return data;
        }

        public bool InsertNewCoupon(Coupons Coupon)
        {
            A_ADM_Coupon_RefDAL obj = new A_ADM_Coupon_RefDAL();
            U_ADM_MEDIA_MASTERDAL objImg = new U_ADM_MEDIA_MASTERDAL();
            U_ADM_MEDIA_MASTER imgData = new U_ADM_MEDIA_MASTER();
            DateTime now = System.DateTime.Now;

            imgData.Media_Id = Guid.NewGuid().ToString();
            imgData.Media_Type = "Image";
            imgData.Media_File_Location = Coupon.Coupon_PicUrl;
            imgData.Media_Source = "";
            imgData.Media_Oth_Dtl = "";
            imgData.Created_by = Coupon.Create_By;
            imgData.Updated_by = Coupon.Update_By;
            imgData.Created_Date = now;
            imgData.Updated_Date = now;

            Coupon.Coupon_id = Guid.NewGuid().ToString();
            Coupon.Create_Date = now;
            Coupon.Update_Date = now;

            if (objImg.InsertU_ADM_MEDIA_MASTER(imgData))
            {
                Coupon.Coupon_PicUrl = imgData.Media_Id;
                if (obj.InsertCouponDb(Coupon))
                {
                    return true;
                }
            }
            return false;
        }

        public Admin_Members[] GetSubAdminDetails()
        {
            U_USR_MASTERDAL obj1 = new U_USR_MASTERDAL();
            var data = obj1.GetSubAdminDetailsDb();
            return data;
        }

        public MemberContacts[] GetMemberContacts(string Id)
        {
            U_USR_MASTERDAL UsrDAL = new U_USR_MASTERDAL();
            MemberContacts[] data = UsrDAL.GetMemberContactsDb(Id);
            return (data);
        }

        public bool UpdateMember(A_USR_MASTER_V2 Memb)
        {
            U_USR_MASTERDAL UsrDAL = new U_USR_MASTERDAL();
            A_USR_MASTER_V2 OldData = GetSingleMemberDetails(Memb.Uid);
            U_USR_MASTER NewData = new U_USR_MASTER();

            //Memb.Updated_By = "22";
            //Memb.Dob = OldData.Dob;
            //Memb.WedAnvrsry = OldData.WedAnvrsry;

            NewData.Usr_Id = Memb.Uid;
            NewData.First_Name = string.IsNullOrEmpty(Memb.FirstName) ? OldData.FirstName : Memb.FirstName;
            NewData.Last_Name = string.IsNullOrEmpty(Memb.LastName) ? OldData.LastName : Memb.LastName;
            NewData.Alt_Email_Id = string.IsNullOrEmpty(Memb.EmailId) ? OldData.EmailId : Memb.EmailId;
            NewData.Gender = string.IsNullOrEmpty(Memb.Gender) ? OldData.Gender : Memb.Gender;
            NewData.Date_Of_Birth = Memb.Dob;
            NewData.About_member = "";
            NewData.Is_married = string.IsNullOrEmpty(Convert.ToString(Memb.IsMarried)) ? OldData.IsMarried : Memb.IsMarried;
            NewData.Wed_anniversary = Memb.WedAnvrsry;
            NewData.Rating = "5";
            NewData.Address_Id = "1";
            NewData.Usr_role_Id = "3";
            NewData.Media_Id_Img = "1";
            NewData.Updated_by = Memb.Updated_By;
            NewData.Created_by = Memb.Updated_By;
            //NewData.Created_Date = OldData.Create_Date;
            NewData.Updated_Date = DateTime.Now;
            NewData.Created_Date = DateTime.Now;
            return UsrDAL.Update_UserProfile(NewData);
        }

        public bool UpdateItem(A_ADM_ITEM_MASTER item)
        {
            A_ADM_ITEM_MASTERDAL ItemDAL = new A_ADM_ITEM_MASTERDAL();
            U_ADM_ITEM_MASTER OldData = new U_ADM_ITEM_MASTER();
            U_ADM_ITEM_MASTER NewData = new U_ADM_ITEM_MASTER();
            U_ADM_MEDIA_MASTERDAL ImgDAL = new U_ADM_MEDIA_MASTERDAL();
            U_ADM_MEDIA_MASTER imgData = new U_ADM_MEDIA_MASTER();

            OldData = ItemDAL.SelectItemDetailsDb(item.Item_ID);
            if (!(item.Item_PicUrl == "/img/default_product.png"))
            {
                imgData.Media_Id = Guid.NewGuid().ToString();
                imgData.Media_Type = "Image";
                imgData.Media_File_Location = item.Item_PicUrl;
                imgData.Media_Source = "";
                imgData.Media_Oth_Dtl = "";
                imgData.Created_by = item.Update_By;
                imgData.Updated_by = item.Update_By;
                imgData.Created_Date = DateTime.Now;
                imgData.Updated_Date = DateTime.Now;
                ImgDAL.InsertU_ADM_MEDIA_MASTER(imgData);
                NewData.Media_Id_Img = imgData.Media_Id;
            }
            else
            {
                NewData.Media_Id_Img = item.Item_PicUrl;
            }
            NewData.Item_Id = item.Item_ID;
            NewData.Item_Name = string.IsNullOrEmpty(item.Item_Name) ? OldData.Item_Name : item.Item_Name;
            NewData.Item_Desc = string.IsNullOrEmpty(item.Item_Desc) ? OldData.Item_Desc : item.Item_Desc;
            NewData.Item_Status = string.IsNullOrEmpty(item.Item_Status) ? OldData.Item_Status : item.Item_Status;
            NewData.Item_Tentative_Cost = string.IsNullOrEmpty(Convert.ToString(item.Item_Price)) ? OldData.Item_Tentative_Cost : item.Item_Price;
            NewData.Item_Source = string.IsNullOrEmpty(item.Item_Source) ? OldData.Item_Source : item.Item_Source;
            NewData.Media_Id_Video = OldData.Media_Id_Video;
            NewData.Created_by = OldData.Created_by;
            NewData.Created_Date = OldData.Created_Date;
            NewData.Updated_by = string.IsNullOrEmpty(item.Update_By) ? OldData.Updated_by : item.Update_By;
            NewData.Updated_Date = DateTime.Now;

            if (ItemDAL.UpdateItemMaster(NewData))
            {
                return true;
            }
            return false;
        }

        public Coupons GetSingleCouponDetails(string Id)
        {
            A_ADM_Coupon_RefDAL couDAL = new A_ADM_Coupon_RefDAL();
            Coupons data = couDAL.GetSingleCouponDetailDb(Id);
            return data;
        }

        public bool GetBlockThisCoupon(string Id)
        {
            A_ADM_Coupon_RefDAL obj = new A_ADM_Coupon_RefDAL();
            return obj.GetBlockThisCouponDb(Id);
        }

        public bool GetUnblockThisCoupon(string Id)
        {
            A_ADM_Coupon_RefDAL obj = new A_ADM_Coupon_RefDAL();
            return obj.GetUnblockThisCouponDb(Id);
        }

        public bool GetUpdateCoupon(Coupons cou)
        {
            A_ADM_Coupon_RefDAL couDAL = new A_ADM_Coupon_RefDAL();
            Coupons OldData = new Coupons();
            Coupons NewData = new Coupons();
            U_ADM_MEDIA_MASTERDAL ImgDAL = new U_ADM_MEDIA_MASTERDAL();
            U_ADM_MEDIA_MASTER imgData = new U_ADM_MEDIA_MASTER();

            OldData = couDAL.GetSingleCouponDetailDb(cou.Coupon_id);

            if (!(cou.Coupon_PicUrl == "/img/no-image.gif") && !(OldData.Coupon_PicUrl == "/img/no-image.gif"))
            {
                imgData.Media_Id = Guid.NewGuid().ToString();
                imgData.Media_Type = "Image";
                imgData.Media_File_Location = cou.Coupon_PicUrl;
                imgData.Media_Source = " ";
                imgData.Media_Oth_Dtl = " ";
                imgData.Created_by = cou.Create_By;
                imgData.Updated_by = cou.Update_By;
                imgData.Created_Date = DateTime.Now;
                imgData.Updated_Date = DateTime.Now;
                ImgDAL.InsertU_ADM_MEDIA_MASTER(imgData);
                NewData.Coupon_PicUrl = imgData.Media_Id;
            }
            NewData.Coupon_id = cou.Coupon_id;
            NewData.Coupon_Name = string.IsNullOrEmpty(cou.Coupon_Name) ? OldData.Coupon_Name : cou.Coupon_Name;
            NewData.Coupon_VenderName = string.IsNullOrEmpty(cou.Coupon_VenderName) ? OldData.Coupon_VenderName : cou.Coupon_VenderName;
            NewData.Coupon_Desc = string.IsNullOrEmpty(cou.Coupon_Desc) ? OldData.Coupon_Desc : cou.Coupon_Desc;
            NewData.Coupon_Status = string.IsNullOrEmpty(cou.Coupon_Status) ? OldData.Coupon_Status : cou.Coupon_Status;
            NewData.Coupon_StartDate = cou.Coupon_StartDate;
            NewData.Coupon_EndDate = cou.Coupon_EndDate;
            NewData.Create_By = OldData.Create_By;
            NewData.Update_By = cou.Update_By;
            NewData.Create_Date = OldData.Create_Date;
            NewData.Update_Date = DateTime.Now;

            if (couDAL.UpdateCouponMaster(NewData))
            {
                return true;
            }
            return false;
        }

        public SubAdmin GetSingleSubAdminDetails(string Id)
        {
            U_USR_MASTERDAL userDAL = new U_USR_MASTERDAL();
            return userDAL.GetSingleSubAdminDetailsDb(Id);
        }

        public bool GetUpdateSubAdmin(SubAdmin usr)
        {
            U_USR_MASTERDAL userDAL = new U_USR_MASTERDAL();
            U_USR_LgnDAL logDAL = new U_USR_LgnDAL();
            SubAdmin NewData = new SubAdmin();
            U_ADM_MEDIA_MASTERDAL ImgDAL = new U_ADM_MEDIA_MASTERDAL();
            U_ADM_MEDIA_MASTER imgData = new U_ADM_MEDIA_MASTER();
            U_USR_MASTER NewData1 = new U_USR_MASTER();

            var OldData = userDAL.GetSingleSubAdminDetailsDb(usr.Usr_Id);

            if (!(usr.Media_File_Location == "/img/default_ProfilePicture.jpg") && !(string.IsNullOrEmpty(usr.Media_File_Location)))
            {
                imgData.Media_Id = Guid.NewGuid().ToString();
                imgData.Media_Type = "Image";
                imgData.Media_File_Location = usr.Media_File_Location;
                imgData.Media_Source = " ";
                imgData.Media_Oth_Dtl = " ";
                imgData.Created_by = usr.Created_by;
                imgData.Updated_by = usr.Updated_by;
                imgData.Created_Date = DateTime.Now;
                imgData.Updated_Date = DateTime.Now;
                ImgDAL.InsertU_ADM_MEDIA_MASTER(imgData);
                NewData.Media_File_Location = imgData.Media_Id;
            }

            NewData.Usr_Id = usr.Usr_Id;
            NewData.First_Name = string.IsNullOrEmpty(usr.First_Name) ? OldData.First_Name : usr.First_Name;
            NewData.Last_Name = string.IsNullOrEmpty(usr.Last_Name) ? OldData.Last_Name : usr.Last_Name;
            NewData.Alt_Email_Id = string.IsNullOrEmpty(usr.Alt_Email_Id) ? OldData.Alt_Email_Id : usr.Alt_Email_Id;
            NewData.Gender = string.IsNullOrEmpty(usr.Gender) ? OldData.Gender : usr.Gender;
            NewData.Usr_role_Id = string.IsNullOrEmpty(usr.Usr_role_Id) ? OldData.Usr_role_Id : usr.Usr_role_Id;
            NewData.Mobile_Number = string.IsNullOrEmpty(usr.Mobile_Number) ? OldData.Mobile_Number : usr.Mobile_Number;
            NewData.Login_status = string.IsNullOrEmpty(Convert.ToString(usr.Login_status)) ? OldData.Login_status : usr.Login_status;
            NewData.Created_Date = OldData.Created_Date;
            NewData.Updated_Date = DateTime.Now;
            NewData.Created_by = OldData.Created_by;
            NewData.Updated_by = string.IsNullOrEmpty(usr.Updated_by) ? OldData.Updated_by : usr.Updated_by;
            NewData.Media_File_Location = string.IsNullOrEmpty(usr.Media_File_Location) ? userDAL.GetMemberMediaIdDb(usr.Usr_Id) : imgData.Media_Id;

            NewData1.Usr_Id = NewData.Usr_Id;
            NewData1.First_Name = NewData.First_Name;
            NewData1.Last_Name = NewData.Last_Name;
            NewData1.Gender = NewData.Gender;
            NewData1.Usr_role_Id = NewData.Usr_role_Id;
            NewData1.Media_Id_Img = NewData.Media_File_Location;
            NewData1.Updated_Date = NewData.Updated_Date;
            NewData1.Updated_by = NewData.Updated_by;
            NewData1.Date_Of_Birth = DateTime.Now;
            NewData1.Wed_anniversary = DateTime.Now;
            NewData1.Created_Date = DateTime.Now;

            bool status = logDAL.UpdateMobileStatusDb(NewData.Usr_Id, NewData.Mobile_Number, NewData.Login_status, NewData.Updated_Date, NewData.Updated_by);
            status = userDAL.Update_SubAdminProfileDb(NewData1);

            return true;

        }

        public int GetUpdateEvent(Event eve)
        {
            U_EVNT_MASTERDAL eveDAL = new U_EVNT_MASTERDAL();
            U_ADM_MEDIA_MASTERDAL ImgDAL = new U_ADM_MEDIA_MASTERDAL();
            U_ADM_MEDIA_MASTER imgData = new U_ADM_MEDIA_MASTER();
            U_EVNT_MASTER NewEveObj = new U_EVNT_MASTER();

            var OldEveObj = eveDAL.GetSingleEventDetailsDb(eve.Event_id);

            if (!(eve.Event_PicUrl == "/img/default_event.png") && !(string.IsNullOrEmpty(eve.Event_PicUrl)))
            {
                imgData.Media_Id = Guid.NewGuid().ToString();
                imgData.Media_Type = "Image";
                imgData.Media_File_Location = eve.Event_PicUrl;
                imgData.Media_Source = " ";
                imgData.Media_Oth_Dtl = " ";
                imgData.Created_by = eve.Event_Update_by;
                imgData.Updated_by = eve.Event_Update_by;
                imgData.Created_Date = DateTime.Now;
                imgData.Updated_Date = DateTime.Now;
                ImgDAL.InsertU_ADM_MEDIA_MASTER(imgData);
                NewEveObj.Media_Id_Img = imgData.Media_Id;
            }

            NewEveObj.Event_Id = string.IsNullOrEmpty(eve.Event_id) ? OldEveObj.Event_id : eve.Event_id;
            NewEveObj.Event_Name = string.IsNullOrEmpty(eve.Event_Name) ? OldEveObj.Event_Name : eve.Event_Name;
            NewEveObj.Even_Location = string.IsNullOrEmpty(eve.Event_Location) ? OldEveObj.Event_Location : eve.Event_Location;
            NewEveObj.Event_Desc = string.IsNullOrEmpty(eve.Event_Desc) ? OldEveObj.Event_Desc : eve.Event_Desc;
            NewEveObj.Event_Status = string.IsNullOrEmpty(eve.Event_Status) ? OldEveObj.Event_Status : eve.Event_Status;
            NewEveObj.Event_StartDate = eve.Event_StartDate;
            NewEveObj.Event_EndDate = eve.Event_EndDate;
            NewEveObj.Created_Date = DateTime.Now; //do nothing
            NewEveObj.Updated_Date = DateTime.Now;
            NewEveObj.Updated_by = eve.Event_Update_by;

            return eveDAL.Update_EventDetailsDb(NewEveObj);
        }
    }
}
