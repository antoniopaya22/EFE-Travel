using SOAP.Collector.Server.Adapters;
using SOAP.Collector.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SOAP.Collector.Server
{

    [WebService(Namespace = "http://efe-forms.miw.com")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class SoapCollector : WebService
    {

        [WebMethod]
        public List<Vuelo> GetVuelos(string origin, string destination, string departureDate,
                string returnDate, string adults)
        {
            IVuelosCollector vuelosCollector = new AmadeusVuelosAdapter();
            if (returnDate != null && returnDate != "")
                return vuelosCollector.GetVuelosIdaVuelta(origin, destination, departureDate, returnDate, adults);
            else
                return vuelosCollector.GetVuelosIda(origin, destination, departureDate, adults);
        }
    }
}
