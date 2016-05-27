using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using BAG.DataInterface;
using System.Text;
using BAG.CustomObject;

namespace BAGservice.ServiceInterface
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAccountService" in both code and config file together.
    [ServiceContract]
    public interface IAccountService
    {
        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "Login/{EmailId}/{password}")]

        Login GetMemberDetails(string EmailId, string password);


        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "Register"
            )]
        string AddMembers(Registration userdetails);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "RegisterThirdParty"
            )]
        Login AddMembers_ThirdParty(SocialRegistration userdetails);

        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "Activation/{Id}")]

        string ActivateMember(string Id);

        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GetUserProfile/{UserId}")]

        Profile GetUserProfile(string UserId);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "UpdateProfile"
            )]
        string UpdateProfile(Profile userdetails);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "ChangePassword"
            )]
        string ChangePassword(ProfileSecurity userdetails);

        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GETUserId/{EmailId}")]

        string CheckUserId(string EmailId);

        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "ResetPassword/{LoginId}/{Pwd}")]

        string Reset_Password(string LoginId,string Pwd);
    }
}
