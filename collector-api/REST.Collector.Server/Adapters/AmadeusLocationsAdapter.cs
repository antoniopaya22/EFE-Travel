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
                CityName = aml.CityName,
                CityCode = aml.CityCode,
                CountryName = aml.CountryName,
                CountryCode = aml.CountryCode
            };
        }

        public List<Location> GetLocations(string keyword)
        {
            List<AmadeusLocation> amadeusLocations = amadeusEndPoint.GetLocations(keyword);
            List<Location> locations = new List<Location>();
            amadeusLocations.ForEach(aml => locations.Add(amadeusLocationToLocation(aml)));
            return locations;
        }
    }
}
