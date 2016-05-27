using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using BAGservice.ServiceInterface;

namespace BAGservice.Services
{
    [AspNetCompatibilityRequirements(RequirementsMode
        = AspNetCompatibilityRequirementsMode.Allowed)]
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "General" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select General.svc or General.svc.cs at the Solution Explorer and start debugging.
    public class General : IGeneral
    {
        public string Subscribe(string osubscribe)
        {
            try
            {
                return "1";
            }
            catch
            {
                return "";
            }
        }
    }
}