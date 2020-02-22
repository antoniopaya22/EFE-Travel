using System;
using System.Collections.Generic;
using System.Text;

namespace REST.Collector.Client.Model
{
    public class AmadeusHotel
    {
        public string HotelId { set; get; }
        public string Name { set; get; }
        public string CityCode { set; get; }
        public string CityName { set; get; }
        public string Address { set; get; }
        public string Description { set; get; }
        public double Price { set; get; }

        public AmadeusHotel(dynamic hotel)
        {
            this.HotelId = hotel.hotel.hotelId;
            this.Name = hotel.hotel.name;
            this.CityCode = hotel.hotel.cityCode;
            this.CityName = hotel.hotel.address.cityName;
            this.Address = hotel.hotel.address.lines[0];
            this.Description = hotel.hotel.description.text;
            this.Price = Convert.ToDouble(hotel.offers[0].price.total);
        }
    }
}
