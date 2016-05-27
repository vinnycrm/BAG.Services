using System.ServiceModel;
using System.ServiceModel.Web;
using BAG.DataInterface;
using BAG.DataObject;
using System.Collections.Generic;
using BAG.CustomObject;

namespace BAGservice.ServiceInterface
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEventService" in both code and config file together.
    [ServiceContract]
    public interface IEventService
    {
        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GETEventTypes")]

        EventTypes[] GETEventTypes();

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "CreateEvent"
            )]
        string CreateEvent(CreateEvent obj);


        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GETHeaderEvent/{Id}")]

        Group_HeaderEvent GETHeaderEvent(string Id);

        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GETEventDetails/{Id}/{UserId}")]

        EventDetails GETEventDetails(string Id, string UserId);

        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GETEventsWishlist/{Id}")]

        WishList[] GETEventsWishlist(string Id);

        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GETCNTWishlist/{event_Id}/{User_Id}")]

        WishList[] GETCNTWishlist(string event_Id,string User_Id);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "CreateWishlist"
            )]
        string CreateWishlist(WishList obj);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "UpdateWishlist"
            )]
        string UpdateWishlist(WishList obj);


        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "DeleteWishlist/{Id}")]

        string DeleteWishlist(string Id);

        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GetWishlistDetails/{Id}/{UserId}")]

        EventSummary GetWishlistDetails(string Id, string UserId);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "AddItemsToWishlist"
            )]
        string AddItemsToWishlist(ItemsList[] obj);

        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GETMYEventsList/{Id}")]

        EventsList[] GETMYEventsList(string Id);

        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GETMYInviteList/{Id}")]

        EventsList[] GETMYInviteList(string Id);


        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "InviteMembers"
            )]
        string InviteMembers(InviteContacts obj);

        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "UpdateEventInvites/{Code}/{UserId}")]

        string Update_Evnt_Inv(string Code, string UserId);
    }
}
