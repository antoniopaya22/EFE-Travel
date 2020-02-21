using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Collector.Server.Model
{
    public class Location
    {
        public string CityName { set; get; }
        public string CityCode { set; get; }
        public string CountryName { set; get; }
        public string CountryCode { set; get; }
    }
}
