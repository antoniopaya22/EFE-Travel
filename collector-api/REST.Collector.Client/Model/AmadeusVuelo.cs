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

        public AmadeusVuelo(dynamic price, dynamic numberOfBookableSeats, dynamic flight, string adults)
        {
            dynamic itinerary = flight.segments[0];
            this.Price = (double)price.total;
            this.DepartureCode = flight.departureName;
            this.ArrivalCode = flight.arrivalName;
            this.DepartureTerminal = itinerary.departure.terminal;
            this.ArrivalTerminal = itinerary.arrival.terminal;
            this.DepartureTime = itinerary.departure.at;
            this.ArrivalTime = itinerary.arrival.at;
            this.Persons = Convert.ToInt32(adults);
            this.BookableSeats = (int)numberOfBookableSeats;
            this.AirlineCode = flight.carrierName;
        }
    }
}
