using System;
using System.Collections.Generic;
using System.Text;

namespace REST.Collector.Client.Model
{
    public class AmadeusLocation
    {
        public string CityName { set; get; }
        public string CityCode { set; get; }
        public string CountryName { set; get; }
        public string CountryCode { set; get; }

        public AmadeusLocation(dynamic address)
        {
            this.CityName = address.cityName;
            this.CityCode = address.cityCode;
            this.CountryName = address.countryName;
            this.CountryCode = address.countryCode;
        }
    }
}
