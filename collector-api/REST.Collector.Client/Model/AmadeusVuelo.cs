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
        public bool Valid { get; set; }

        public AmadeusVuelo(dynamic flight, string adults)
        {
            dynamic iti = flight.itineraries;
            dynamic iti1 = iti[0];
            if (iti1.segments.Count == 1)
            {
                dynamic itinerary = iti1.segments[0];
                this.Price = (double)flight.price.total;

                
                this.DepartureCode = itinerary.departure.iataCode;
                this.ArrivalCode = itinerary.arrival.iataCode;
                this.DepartureTerminal = itinerary.departure.terminal;
                this.ArrivalTerminal = itinerary.arrival.terminal;
                this.DepartureTime = itinerary.departure.at;
                this.ArrivalTime = itinerary.arrival.at;
                this.Persons = Convert.ToInt32(adults);
                this.BookableSeats = (int)flight.numberOfBookableSeats;
                this.AirlineCode = itinerary.carrierCode;
                this.Valid = true;
            }
            
            
        }
    }
}
