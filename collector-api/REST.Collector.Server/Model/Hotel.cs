using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Collector.Server.Model
{
    public class Hotel
    {
        public string HotelId { set; get; }
        public string Name { set; get; }
        public string CityCode { set; get; }
        public string CityName { set; get; }
        public string Address { set; get; }
        public string Description { set; get; }
        public double Price { set; get; }
    }
}
