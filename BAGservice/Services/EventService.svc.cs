using System;
using System.Linq;
using BAGservice.ServiceInterface;
using BAG.DataObject;
using BAG.Event.DataAccess;
using System.ServiceModel.Activation;
using System.Collections.Generic;
using BAG.CustomObject;

namespace BAGservice.Services
{
    [AspNetCompatibilityRequirements(RequirementsMode
        = AspNetCompatibilityRequirementsMode.Allowed)]
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EventService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EventService.svc or EventService.svc.cs at the Solution Explorer and start debugging.
    public class EventService : IEventService
    {
        public EventTypes[] GETEventTypes()
        {
             U_ADM_EVNT_TypeDAL oeventDAL = new U_ADM_EVNT_TypeDAL();
            return oeventDAL.Select_EVENT_Types();
        }

        public string SelectMediaImageId(string Id)
        {
            U_EVNT_MASTERDAL oDAL = new U_EVNT_MASTERDAL();
            return oDAL.Select_MediaImageId(Id);
        }

        public string CreateEvent(CreateEvent obj)
        {
            U_EVNT_MASTERDAL oeventDAL = new U_EVNT_MASTERDAL();
            U_EVNT_MASTER oevent = new U_EVNT_MASTER();
            oevent.Event_Creator_Id = obj.User_Id;
            oevent.COMMENTS = "";
            oevent.Created_by = obj.User_Id;
            oevent.Created_Date = DateTime.Now;
            oevent.Event_Desc = obj.Description;
            oevent.Event_EndDate = obj.End_Date;
            oevent.Event_Id = Guid.NewGuid().ToString();
            oevent.Event_StartDate = obj.Start_Date;
            oevent.Event_Name = obj.Event_Name;
            oevent.Event_Status = "1";
            oevent.Event_Type_Id = obj.Type_Id;
            oevent.Even_Location = obj.Event_Location;
            oevent.Media_Id_Img = SelectMediaImageId(obj.Type_Id);
            oevent.Updated_by = "";
            oevent.Updated_Date = DateTime.Now;
            var status= oeventDAL.InsertU_EVNT_MASTER(oevent);
            if (status == true)
                return "1";
            else
                return "0";
        }

        public Group_HeaderEvent GETHeaderEvent(string Id)
        {
            U_EVNT_MASTERDAL oeventDAL = new U_EVNT_MASTERDAL();
            return oeventDAL.Get_HeaderEvents(Id);
        }

        public EventDetails GETEventDetails(string EId, string UserId)
        {
            U_EVNT_MASTERDAL oeventDAL = new U_EVNT_MASTERDAL();
            return oeventDAL.Get_EventsDetails(EId, UserId);
        }

        public WishList[] GETEventsWishlist(string Id)
        {
            U_USR_WListDAL owlistDAL = new U_USR_WListDAL();
            return owlistDAL.SelectU_USR_WList(Id);
        }

        public WishList[] GETCNTWishlist(string event_Id,string user_id)
        {
            U_USR_WListDAL owlistDAL = new U_USR_WListDAL();
            return owlistDAL.SelectU_CNT_WList(event_Id,user_id);
        }

        public string CreateWishlist(WishList obj)
        {
            U_USR_WListDAL owishlistDAL = new U_USR_WListDAL();
            U_USR_WList owishlist = new U_USR_WList();
            owishlist.WList_Id = Guid.NewGuid().ToString();
            owishlist.WList_Name = obj.WList_Name;
            owishlist.WList_Status = "1";
            owishlist.Media_Id_Img = "1";
            owishlist.Event_Id = obj.Id;
            owishlist.Event_Creator_Id = "";
            owishlist.Comments = "";
            owishlist.Created_by = "";
            owishlist.Created_Date = DateTime.Now;
            owishlist.Updated_by = "";
            owishlist.Updated_Date = DateTime.Now;
            var status = owishlistDAL.InsertU_USR_WList(owishlist);
            if (status == true)
                return "1";
            else
                return "0";
        }

        public string UpdateWishlist(WishList obj)
        {
            U_USR_WListDAL owishlistDAL = new U_USR_WListDAL();
            owishlistDAL.Update_WishlistName(obj.Id,obj.WList_Name);
            return "1";
        }

        public string DeleteWishlist(string Id)
        {
            U_USR_WListDAL oeventDAL = new U_USR_WListDAL();
            var status= oeventDAL.Delete_Wishlist(Id);
            if (status == true)
                return "1";
            else
                return "0";
        }

        public EventSummary GetWishlistDetails(string WId,string UserId)
        {
            U_EVNT_WList_DtlDAL oeventDAL = new U_EVNT_WList_DtlDAL();
            return oeventDAL.Select_EVNT_WList(WId,UserId);
        }

        public string AddItemsToWishlist(ItemsList[] obj)
        {
            U_EVNT_WList_DtlDAL oeventDAL = new U_EVNT_WList_DtlDAL();
            U_EVNT_WList_Dtl oevent = new U_EVNT_WList_Dtl();
            foreach (var items in obj)
            {
                if (string.IsNullOrEmpty(oeventDAL.IsItemExist(items.WList_Id, items.Item_Id)))
                {
                    oevent.Id = Guid.NewGuid().ToString();
                    oevent.Event_Id = items.Event_Id;
                    oevent.Item_Id = items.Item_Id;
                    oevent.WList_Id = items.WList_Id;
                    oevent.Item_Cost_Entered_ByUser = items.Item_Tentative_Cost;
                    oevent.Created_by = "";
                    oevent.Created_Date = DateTime.Now;
                    oevent.Updated_by = "";
                    oevent.Updated_Date = DateTime.Now;
                    oeventDAL.InsertU_EVNT_WList_Dtl(oevent);
                }
            }
            return "1";
        }

        public EventsList[] GETMYEventsList(string Id)
        {
            U_EVNT_MASTERDAL oeventDAL = new U_EVNT_MASTERDAL();
            return oeventDAL.Get_MYEvents(Id);
        }

        public EventsList[] GETMYInviteList(string Id)
        {
            U_EVNT_MASTERDAL oeventDAL = new U_EVNT_MASTERDAL();
            return oeventDAL.Get_MYInvites(Id);
        }

        public string InviteMembers(InviteContacts obj)
        {
            try
            {
                U_EVNT_WList_Pub_DAL oinvDAL = new U_EVNT_WList_Pub_DAL();
                U_EVNT_WList_Pub_Dtl oinv = new U_EVNT_WList_Pub_Dtl();
                foreach (var item in obj.InvitedMembers)
                {
                    if (string.IsNullOrEmpty(oinvDAL.Get_Evnt_Inv(obj.Event_Id, obj.wishlist_Id, item.EmailID)))
                    {
                        oinv.Id = Guid.NewGuid().ToString();
                        oinv.Contact_Id = null;
                        oinv.Pub_Date = DateTime.Now;
                        oinv.Pub_MediaType = "";
                        oinv.Pub_Status = "0";
                        oinv.Phone_No = item.ContactNo;
                        oinv.Email_Id = item.EmailID;
                        oinv.WList_CodeForPub = item.INV_Code;
                        oinv.WList_Id = obj.wishlist_Id;
                        oinv.Event_Id = obj.Event_Id;
                        oinv.Created_Date = DateTime.Now;
                        oinv.Created_by = item.UserId;
                        oinv.Updated_by = "";
                        oinv.Updated_Date = DateTime.Now;
                        oinvDAL.InsertU_EVNT_WList_Pub_Dtl(oinv);
                    }
                }
                return "1";
            }
            catch(Exception ex)
            {
                Console.Write(ex);
                return "";
            }
        }

        public string Update_Evnt_Inv(string Code,string UserId)
        {
            U_EVNT_WList_Pub_DAL owlistDAL = new U_EVNT_WList_Pub_DAL();
             owlistDAL.Update_Event_Inv(Code,UserId);
             return "1";
        }
        public string SELECT_EventImage(string Id)
        {
            U_EVNT_MASTERDAL owlistDAL = new U_EVNT_MASTERDAL();
            return owlistDAL.SELECT_EventImage(Id);
        }
    }
}
