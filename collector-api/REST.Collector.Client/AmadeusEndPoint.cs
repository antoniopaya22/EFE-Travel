
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        string tokenEndPoint = "https://test.api.amadeus.com/v1/security/oauth2/token";
        private string token { set; get; }
        Dictionary<string, string> locations = new Dictionary<string, string>();

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
            foreach (dynamic dyn_vuelo in dy_vuelos.data)
            {
                iti = dyn_vuelo.itineraries;
                ida = iti[0];
                if (ida.segments.Count == 1)
                {
                    ida.departureName = GetLocation("A" + ida.segments[0].departure.iataCode.ToString());
                    ida.arrivalName = GetLocation("A" + ida.segments[0].arrival.iataCode.ToString());
                    AmadeusVuelo vuelo = new AmadeusVuelo(dyn_vuelo.price, dyn_vuelo.numberOfBookableSeats, ida, adults);
                    vuelos.Add(vuelo);
                }
            }
 
            return vuelos; 
        }

        public List<List<AmadeusVuelo>> GetVuelosIdaVuelta(string origin, string destination, string departuredate, string returnDate, string adults)
        {
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
            foreach (dynamic dyn_vuelo in dy_vuelos.data)
            {
                iti = dyn_vuelo.itineraries;
                ida = iti[0];
                vuelta = iti[1];
                if (ida.segments.Count == 1 && vuelta.segments.Count == 1)
                {
                    ida.departureName = GetLocation("A" + ida.segments[0].departure.iataCode.ToString());
                    vuelta.departureName = GetLocation("A" + vuelta.segments[0].departure.iataCode.ToString());
                    ida.arrivalName = GetLocation("A" + ida.segments[0].arrival.iataCode.ToString());
                    vuelta.arrivalName = GetLocation("A" + vuelta.segments[0].arrival.iataCode.ToString());
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

        public string GetLocation(string code)
        {
            //this.token = GetToken();
            if (locations.ContainsKey(code))
                return locations[code];
            var client = new RestClient(this.locationsEndPoint);
            var getRequest = new RestRequest("/{code}", Method.GET);
            getRequest.RequestFormat = DataFormat.Json;
            getRequest.AddParameter("code",code, ParameterType.UrlSegment);
            getRequest.AddHeader("Authorization", $"Bearer {this.token}");
            var response = client.Execute(getRequest);
            dynamic location = JsonConvert.DeserializeObject<dynamic>(response.Content);
            if(location.errors != null)
            {
                if (!locations.ContainsKey(code))
                    locations.Add(code, code);
                return code;
            }
            string name = location.data.name.ToString();
            if(!locations.ContainsKey(code))
                locations.Add(code, name);
            return name;
        }
    }
}
