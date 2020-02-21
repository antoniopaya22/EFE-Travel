
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using REST.Collector.Client.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace REST.Collector.Client
{
    public class AmadeusEndPoint
    {
        string hotelEndPoint = "https://test.api.amadeus.com/v2/shopping/hotel-offers";
        string vueloEndPoint = "https://test.api.amadeus.com/v2/shopping/flight-offers";
        string tokenEndPoint = "https://test.api.amadeus.com/v1/security/oauth2/token";
        private string token { set; get; }

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
            foreach (dynamic dyn_vuelo in dy_vuelos.data)
            {
                dynamic iti = dyn_vuelo.itineraries;
                dynamic ida = iti[0];
                if (ida.size() == 1)
                {
                    AmadeusVuelo vuelo = new AmadeusVuelo(iti.price, iti.numberOfBookableSeats, ida, adults);
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
            foreach (dynamic dyn_vuelo in dy_vuelos.data)
            {

                dynamic iti = dyn_vuelo.itineraries;
                dynamic ida = iti[0];
                dynamic vuelta = iti[1];
                if (ida.size() == 1 && vuelta.size() == 1)
                {
                    List<AmadeusVuelo> ida_vuelta = new List<AmadeusVuelo>();
                    AmadeusVuelo vuelo_ida = new AmadeusVuelo(iti.price, iti.numberOfBookableSeats, ida, adults);
                    AmadeusVuelo vuelo_vuelta = new AmadeusVuelo(iti.price, iti.numberOfBookableSeats, vuelta, adults);
                    ida_vuelta.Add(vuelo_ida);
                    ida_vuelta.Add(vuelo_vuelta);
                    vuelos.Add(ida_vuelta);
                }
            }
            return vuelos;
        }
    }
}
