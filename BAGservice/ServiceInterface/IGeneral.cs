using System.ServiceModel;
using System.ServiceModel.Web;

namespace BAGservice.ServiceInterface
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGeneral" in both code and config file together.
    [ServiceContract]
    public interface IGeneral
    {

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "Subscribe"
            )]
        string Subscribe(string osubscribe);
        
    }
    
}
