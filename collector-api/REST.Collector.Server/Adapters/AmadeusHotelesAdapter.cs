using REST.Collector.Client;
using REST.Collector.Client.Model;
using REST.Collector.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Collector.Server.Adapters
{
    public class AmadeusHotelesAdapter :IHotelesCollector
    {
        private AmadeusEndPoint amadeusEndPoint;
        public AmadeusHotelesAdapter()
        {
            this.amadeusEndPoint = new AmadeusEndPoint();
        }

        public Hotel amadeusHotelToHotel(AmadeusHotel amh)
        {
            return new Hotel
            {
                HotelId = amh.HotelId,
                Name = amh.Name,
                CityCode = amh.CityCode,
                CityName = amh.CityName,
                Address = amh.Address,
                Description = amh.Description,
                Price = amh.Price
        };
        }

        public List<Hotel> GetHoteles(string cityCode, string adults)
        {
            List<AmadeusHotel> amadeusHoteles = amadeusEndPoint.GetHotels(cityCode, adults);
            List<Hotel> hoteles = new List<Hotel>();
            amadeusHoteles.ForEach(amh => hoteles.Add(amadeusHotelToHotel(amh)));
            return hoteles;
        }
    }
}
