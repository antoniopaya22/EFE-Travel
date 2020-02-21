using REST.Collector.Client;
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

        public string GetLocation(string code)
        {
            return amadeusEndPoint.GetLocation(code);
        }
    }
}
