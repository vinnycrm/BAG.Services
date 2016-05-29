using BAG.Admin.Dataobject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BAGservice.ServiceInterface
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAdminService" in both code and config file together.
    [ServiceContract]
    public interface IAdminService
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "getLoginValidate")]
        U_ADMIN_Login_Ref getLoginValidate(U_USR_Lgn user);

        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "MembersDetails")]
        Admin_Members[] GetMembersDetails();

        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "ItemsDetails")]
        A_ADM_ITEM_MASTER[] GetItemsDetails();

        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "CouponsDetails")]
        A_ADM_Coupon_Ref[] GetCouponsDetails();

        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "SingleMemberDetails/{Id}")]
        A_USR_MASTER_V2 GetSingleMemberDetails(string Id);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "CreateSubAdmin")]
        bool InsertSubAdmin(A_ModelGroupsList SubAdmin);

        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "EventsDetails")]
        U_EVNT_MASTER[] GetEventsDetails();

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "CreateNewItem")]
        bool InsertNewItem(U_ADM_ITEM_MASTER item);

        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "SingleItemDetails/{Id}")]
        A_ADM_ITEM_MASTER GetSingleItemDetails(string Id);

        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "BlockThisItem/{Id}")]
        bool GetBlockThisItem(string Id);

        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "UnblockThisItem/{Id}")]
        bool GetUnblockThisItem(string Id);

        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "HisGroups/{Id}")]
        Groups[] GetHisGroups(string Id);

        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "JoinedGroups/{Id}")]
        Groups[] GetJoinedGroups(string Id);

        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "BlockThisUser/{Id}")]
        bool GetBlockThisUser(string Id);

        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "UnblockThisUser/{Id}")]
        bool GetUnblockThisUser(string Id);

        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "SingleEventDetails/{Id}")]
        Event GetSingleEventDetails(string Id);

        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "EventWishListDetails/{Id}")]
        EventsWishList[] GetEventWishListDetails(string Id);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "CreateNewCoupon")]
        bool InsertNewCoupon(Coupons Coupon);

        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "SubDetails")]
        Admin_Members[] GetSubAdminDetails();

        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "MemberContacts/{Id}")]
        MemberContacts[] GetMemberContacts(string Id);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "UpdateMember")]
        bool UpdateMember(A_USR_MASTER_V2 Memb);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "UpdateItem")]
        bool UpdateItem(A_ADM_ITEM_MASTER item);

        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "SingleCouponDetails/{Id}")]
        Coupons GetSingleCouponDetails(string Id);

        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "BlockThisCoupon/{Id}")]
        bool GetBlockThisCoupon(string Id);

        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "UnblockThisCoupon/{Id}")]
        bool GetUnblockThisCoupon(string Id);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "UpdateCoupon")]
        bool GetUpdateCoupon(Coupons item);

        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "SingleSubAdminDetails/{Id}")]
        SubAdmin GetSingleSubAdminDetails(string Id);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "UpdateSubAdmin")]
        bool GetUpdateSubAdmin(SubAdmin usr);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "UpdateEvent")]
        Int32 GetUpdateEvent(Event eve);
    }
}
