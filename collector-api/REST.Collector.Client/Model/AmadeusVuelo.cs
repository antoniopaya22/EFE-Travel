using System;
using System.Collections.Generic;
using System.Text;

namespace REST.Collector.Client.Model
{
    public class AmadeusVuelo
    {
        public string DepartureCode { get; set; }
        public string ArrivalCode { get; set; }
        public string DepartureTerminal { get; set; }
        public string ArrivalTerminal { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public string Duration { get; set; }
        public double Price { get; set; }
        public int Persons { get; set; }
        public int BookableSeats { get; set; }
        public string AirlineCode { get; set; }
    }
}
