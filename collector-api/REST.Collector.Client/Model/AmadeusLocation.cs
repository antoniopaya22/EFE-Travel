using System;
using System.Collections.Generic;
using System.Text;

namespace REST.Collector.Client.Model
{
    public class AmadeusLocation
    {
        public string Code { set; get; }
        public string City { set; get; }
        public string Img { set; get; }

        public AmadeusLocation(dynamic location)
        {
            this.Code = location.code;
            this.City = location.city;
            this.Img = location.img;
        }
    }
}
