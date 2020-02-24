using RestSharp;
using SOAP.Collector.Server.Adapters;
using SOAP.Collector.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace SOAP.Collector.Server
{

    [WebService(Namespace = "http://efe-forms.miw.com")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class SoapCollector : WebService
    {
        public AuthorizationHeader authorization;
        private bool validateToken(string token)
        {
            var client = new RestClient("http://localhost:5000");
            var getRequest = new RestRequest("/verify-token", Method.GET);
            getRequest.AddHeader("Authorization", token);
            var response = client.Execute(getRequest);
            return response.IsSuccessful;
        }

        [WebMethod]
        public List<Recommendation> GetRecomendaciones(string origin)
        {
            IRecommendationsCollector recCollector = new AmadeusRecommendationAdapter();
            return recCollector.GetRecommendations(origin);
        }

        public class AuthorizationHeader : SoapHeader
        {
            public string token;
        }
    }
}
