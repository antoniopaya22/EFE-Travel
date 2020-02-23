using System;
using System.Collections.Generic;
using System.Text;

namespace REST.Collector.Client.Model
{
    public class AmadeusRecommendation
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string DepartureDate { get; set; }
        public string ReturnDate { get; set; }
        public double Price { get; set; }

        public AmadeusRecommendation(dynamic flight)
        {
            this.Price = Convert.ToDouble(flight.price.total);
            this.Origin = flight.origin;
            this.Destination = flight.destination;
            this.DepartureDate = flight.departureDate;
            this.ReturnDate = flight.returnDate;
        }
    }
}
