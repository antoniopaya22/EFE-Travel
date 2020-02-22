using REST.Collector.Client;
using REST.Collector.Client.Model;
using SOAP.Collector.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOAP.Collector.Server.Adapters
{ 
    class AmadeusRecommendationAdapter : IRecommendationsCollector
    {
        private AmadeusEndPoint amadeusEndPoint;
        public AmadeusRecommendationAdapter()
        {
            this.amadeusEndPoint = new AmadeusEndPoint();
        }

        public Recommendation amadeusRecToRec(AmadeusRecommendation amr)
        {
            return new Recommendation
            {
                Origin = amr.Origin,
                Destination = amr.Destination, 
                DepartureDate = amr.DepartureDate,
                ReturnDate = amr.ReturnDate,
                Price = amr.Price
            };
        }

        public List<Recommendation> GetRecommendations(string origin)
        {
            List<AmadeusRecommendation> amadeusRec = amadeusEndPoint.GetRecommendations(origin);
            List<Recommendation> recoms = new List<Recommendation>();
            amadeusRec.ForEach(amr => recoms.Add(amadeusRecToRec(amr)));
            return recoms;
        }
     
    }
}
