using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using BAG.DataInterface;
using System.Text;
using BAG.CustomObject;
using BAG.DataObject;

namespace BAGservice.ServiceInterface
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IContacts" in both code and config file together.
    [ServiceContract]
    public interface IContacts
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "ImportContacts"
            )]
        string ImportContacts(GoogleContacts[] userdetails);

        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GetUserContact/{Id}")]

        GoogleContacts[] GetContactDetails(string Id);


        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "CreateGroup"
            )]
        string CreateGroup(GroupDetails obj);

        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GetUserGroups/{Id}")]

        GroupDetails[] GetUserGroups(string Id);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "EditGroup"
            )]
        string EditGroup(GroupDetails obj);

        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "DeleteGroup/{Id}")]

        string DeleteGroup(string Id);

        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GetGroupContacts/{Id}")]
        GoogleContacts[] GetGroupContact(string Id);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "AddGroupContacts"
            )]
        string AddGroupContacts(ContactsSummary obj);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "DeleteContact"
            )]
        string DeleteContact(DeleteContact obj);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "RemoveGroupContact"
            )]
        string RemoveGroupContact(DeleteContact obj);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "EditContact"
            )]
        string EditContact(EditContact obj);

    }
}
