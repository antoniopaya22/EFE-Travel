
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using REST.Collector.Client.Data;
using REST.Collector.Client.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace REST.Collector.Client
{
    public class AmadeusEndPoint
    {
        string hotelEndPoint = "https://test.api.amadeus.com/v2/shopping/hotel-offers";
        string vueloEndPoint = "https://test.api.amadeus.com/v2/shopping/flight-offers";
        string locationsEndPoint = "https://test.api.amadeus.com/v1/reference-data/locations";
        string airlineEndPoint = "https://test.api.amadeus.com/v1/reference-data/airlines";
        string recommendationsEndPoint = "https://test.api.amadeus.com/v1/shopping/flight-destinations";
        string tokenEndPoint = "https://test.api.amadeus.com/v1/security/oauth2/token";
        private string token { set; get; }
        Dictionary<string, string> airlines = new Dictionary<string, string>();

        List<AmadeusLocation> locationList;

        public AmadeusEndPoint()
        {
            this.token = GetToken();    
        }
        private string GetToken()
        {
             
            var client = new RestClient(this.tokenEndPoint);
            var postRequest = new RestRequest(Method.POST);
            postRequest.RequestFormat = DataFormat.Json;
      
            postRequest.AddParameter("grant_type", "client_credentials");
            postRequest.AddParameter("client_id", "XLbh90vHX4giWUaLtToDowKVTqklj6ad");
            postRequest.AddParameter("client_secret", "5VwyMXGDecgweu4V");

            postRequest.AddHeader("content-type", "application/x-www-form-urlencoded");
            var response = client.Execute(postRequest);
            dynamic token = JsonConvert.DeserializeObject<dynamic>(response.Content);
            return token.access_token;
        }
        public List<AmadeusVuelo> GetVuelosIda(string origin, string destination, string departuredate, string adults)
        {
            if(this.locationList == null)
            {
                LocationData locadata = new LocationData();
                this.locationList = locadata.locations;
            }
            airlines = new Dictionary<string, string>();
            this.token = GetToken();
            var client = new RestClient(this.vueloEndPoint);
            var getRequest = new RestRequest(Method.GET);
            getRequest.RequestFormat = DataFormat.Json;
            getRequest.AddParameter("originLocationCode", origin, ParameterType.QueryString);
            getRequest.AddParameter("destinationLocationCode", destination, ParameterType.QueryString);
            getRequest.AddParameter("departureDate", departuredate, ParameterType.QueryString);
            getRequest.AddParameter("adults", adults, ParameterType.QueryString);
            getRequest.AddHeader("Authorization", $"Bearer {this.token}");
            var response = client.Execute(getRequest);
            dynamic dy_vuelos = JsonConvert.DeserializeObject<dynamic>(response.Content);
            List<AmadeusVuelo> vuelos = new List<AmadeusVuelo>();
            dynamic iti = null;
            dynamic ida = null;
            if (dy_vuelos.errors != null)
                return vuelos;
            foreach (dynamic dyn_vuelo in dy_vuelos.data)
            {
                iti = dyn_vuelo.itineraries;
                ida = iti[0];
                if (ida.segments.Count == 1)
                {
                    ida.departureName = GetLocationCity(ida.segments[0].departure.iataCode.ToString());
                    ida.arrivalName = GetLocationCity(ida.segments[0].arrival.iataCode.ToString());
                    ida.carrierName = GetAirline(ida.segments[0].carrierCode.ToString());
                    AmadeusVuelo vuelo = new AmadeusVuelo(dyn_vuelo.price, dyn_vuelo.numberOfBookableSeats, ida, adults);
                    vuelos.Add(vuelo);
                }
            }
 
            return vuelos; 
        }

        public List<List<AmadeusVuelo>> GetVuelosIdaVuelta(string origin, string destination, string departuredate, string returnDate, string adults)
        {
            if (this.locationList == null)
            {
                LocationData locadata = new LocationData();
                this.locationList = locadata.locations;
            }
            airlines = new Dictionary<string, string>();
            this.token = GetToken();
            var client = new RestClient(this.vueloEndPoint);
            var getRequest = new RestRequest(Method.GET);
            getRequest.RequestFormat = DataFormat.Json;
            getRequest.AddParameter("originLocationCode", origin, ParameterType.QueryString);
            getRequest.AddParameter("destinationLocationCode", destination, ParameterType.QueryString);
            getRequest.AddParameter("departureDate", departuredate, ParameterType.QueryString);
            getRequest.AddParameter("returnDate", returnDate, ParameterType.QueryString);
            getRequest.AddParameter("adults", adults, ParameterType.QueryString);
            getRequest.AddHeader("Authorization", $"Bearer {this.token}");
            var response = client.Execute(getRequest);
            dynamic dy_vuelos = JsonConvert.DeserializeObject<dynamic>(response.Content);
            List<List<AmadeusVuelo>> vuelos = new List<List<AmadeusVuelo>>();
            List<AmadeusVuelo> ida_vuelta = new List<AmadeusVuelo>();
            dynamic iti = null;
            dynamic ida = null;
            dynamic vuelta = null;
            if (dy_vuelos.errors != null)
                return vuelos;
            foreach (dynamic dyn_vuelo in dy_vuelos.data)
            {
                iti = dyn_vuelo.itineraries;
                ida = iti[0];
                vuelta = iti[1];
                if (ida.segments.Count == 1 && vuelta.segments.Count == 1)
                {
                    ida.departureName = GetLocationCity(ida.segments[0].departure.iataCode.ToString());
                    vuelta.departureName = GetLocationCity(vuelta.segments[0].departure.iataCode.ToString());
                    ida.arrivalName = GetLocationCity(ida.segments[0].arrival.iataCode.ToString());
                    vuelta.arrivalName = GetLocationCity(vuelta.segments[0].arrival.iataCode.ToString());
                    AmadeusVuelo vuelo_ida = new AmadeusVuelo(dyn_vuelo.price, dyn_vuelo.numberOfBookableSeats, ida, adults);
                    AmadeusVuelo vuelo_vuelta = new AmadeusVuelo(dyn_vuelo.price, dyn_vuelo.numberOfBookableSeats, vuelta, adults);
                    ida_vuelta.Add(vuelo_ida);
                    ida_vuelta.Add(vuelo_vuelta);
                    vuelos.Add(ida_vuelta);
                    ida_vuelta = new List<AmadeusVuelo>();
                }
            }
            return vuelos;
        }

        public string GetLocationCity(string code)
        {
            if (this.locationList == null)
            {
                LocationData locadata = new LocationData();
                this.locationList = locadata.locations;
            }
            string name = this.locationList.Find(i => i.Code == code).City;
            return name;
        }

        public string GetAirline(string code)
        {
            if (this.locationList == null)
            {
                LocationData locadata = new LocationData();
                this.locationList = locadata.locations;
            }
            if (airlines.ContainsKey(code))
                return airlines[code];
            var client = new RestClient(this.airlineEndPoint);
            var getRequest = new RestRequest( Method.GET);
            getRequest.RequestFormat = DataFormat.Json;
            getRequest.AddParameter("airlineCodes", code, ParameterType.QueryString);
            getRequest.AddHeader("Authorization", $"Bearer {this.token}");
            var response = client.Execute(getRequest);
            dynamic airline = JsonConvert.DeserializeObject<dynamic>(response.Content);
            if (airline.errors != null)
            {
                if (!airlines.ContainsKey(code))
                    airlines.Add(code, code);
                return code;
            }
            string name = airline.data[0].businessName.ToString();
            if (!airlines.ContainsKey(code))
                airlines.Add(code, name);
            return name;
        }

        public List<AmadeusLocation> GetLocations()
        {
            if (this.locationList == null)
            {
                LocationData locadata = new LocationData();
                this.locationList = locadata.locations;
            }
            return this.locationList;
        }

        public List<AmadeusHotel> GetHotels(string cityCode, string adults)
        {
            if (this.locationList == null)
            {
                LocationData locadata = new LocationData();
                this.locationList = locadata.locations;
            }
            this.token = GetToken();
            var client = new RestClient(this.hotelEndPoint);
            var getRequest = new RestRequest(Method.GET);
            getRequest.RequestFormat = DataFormat.Json;
            getRequest.AddParameter("cityCode", cityCode, ParameterType.QueryString);
            getRequest.AddParameter("adults", adults, ParameterType.QueryString);
            getRequest.AddHeader("Authorization", $"Bearer {this.token}");
            var response = client.Execute(getRequest);
            dynamic dy_hotels = JsonConvert.DeserializeObject<dynamic>(response.Content);
            List<AmadeusHotel> hotels = new List<AmadeusHotel>();
            if (dy_hotels.errors != null)
                return hotels;
            foreach (dynamic dyn_hotel in dy_hotels.data)
            {
                AmadeusHotel hot = new AmadeusHotel(dyn_hotel);
                hotels.Add(hot);
            }
            return hotels;
        }

        public List<AmadeusRecommendation> GetRecommendations(string origin)
        {
            this.token = GetToken();
            var client = new RestClient(this.recommendationsEndPoint);
            var getRequest = new RestRequest(Method.GET);
            getRequest.RequestFormat = DataFormat.Json;
            getRequest.AddParameter("origin", origin, ParameterType.QueryString);
            getRequest.AddHeader("Authorization", $"Bearer {this.token}");
            var response = client.Execute(getRequest);
            dynamic dy_recoms = JsonConvert.DeserializeObject<dynamic>(response.Content);
            List<AmadeusRecommendation> recoms = new List<AmadeusRecommendation>();
            if (dy_recoms.errors != null)
                return recoms;
            foreach (dynamic dyn_recom in dy_recoms.data)
            {
                AmadeusRecommendation rec = new AmadeusRecommendation(dyn_recom);
                recoms.Add(rec);
            }
            return recoms;
        }
    }
}
