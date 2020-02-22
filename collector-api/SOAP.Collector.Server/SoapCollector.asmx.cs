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
        public List<Recommendation> GetRecomendaciones(string origin)
        {
            IRecommendationsCollector recCollector = new AmadeusRecommendationAdapter();
            return recCollector.GetRecommendations(origin);
        }
    }
}
