using REST.Collector.Client.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace REST.Collector.Client
{
    public class AmadeusEndPoint
    {
        public List<AmadeusVuelo> GetVuelos()
        {
            return new List<AmadeusVuelo>
            {
                new AmadeusVuelo
                {
                    DepartureCode = "SYD",
                    ArrivalCode = "BKK",
                    DepartureTerminal = "1",
                    ArrivalTerminal = "",
                    DepartureTime = "2020-08-01T10:00:00",
                    ArrivalTime = "2020-08-01T16:20:00",
                    Duration = "PT9H20M",
                    Price = 1590.78,
                    Persons = 2,
                    BookableSeats = 9,
                    AirlineCode = "TG"
                }
            };
        }
    }
}
