using REST.Collector.Client;
using REST.Collector.Server.Model;
using REST.Collector.Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace REST.Collector.Server.Adapters
{
    public class AmadeusLocationsAdapter : ILocationsCollector
    {
        private AmadeusEndPoint amadeusEndPoint;
        public AmadeusLocationsAdapter()
        {
            this.amadeusEndPoint = new AmadeusEndPoint();
        }

        public Location amadeusLocationToLocation(AmadeusLocation aml)
        {
            return new Location
            {
                Code = aml.Code,
                City = aml.City,
                Img = aml.Img
            };
        }

        public string GetLocation(string code)
        {
            return amadeusEndPoint.GetLocationCity(code);
        }

        public List<Location> GetLocations()
        {
            List<AmadeusLocation> amadeusLocations = amadeusEndPoint.GetLocations();
            List<Location> locations = new List<Location>();
            amadeusLocations.ForEach(aml => locations.Add(amadeusLocationToLocation(aml)));
            return locations;
        }
    }
}
