
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
            //cityCode=PAR&adults=1&radius=5&radiusUnit=KM&paymentPolicy=NONE&includeClosed=false&bestRateOnly=true&view=FULL&sort=PRICE
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
            //List<AmadeusVuelo> vuelos = dy_vuelos.data;
            List<AmadeusVuelo> vuelos = new List<AmadeusVuelo>();
            foreach (dynamic dyn_vuelo in dy_vuelos.data)
            {
                //string jv = JsonConvert.SerializeObject(dv, Formatting.Indented);
                //var v = JsonConvert.DeserializeObject<AmadeusVuelo>(jv);
                dynamic iti = dyn_vuelo.itineraries;
                dynamic iti1 = iti[0];
                //AmadeusVuelo v = new AmadeusVuelo(iti1.segments[0]);
                //vuelos.Add(v);
                /*
                if (iti1.segments.Count == 1)
                {
                    dynamic itinerary = iti1.segments[0];
                    dynamic price = dyn_vuelo.
                    AmadeusVuelo vuelo = new AmadeusVuelo();
                    vuelos.Add(vuelo);
                }
                */
                AmadeusVuelo vuelo = new AmadeusVuelo(dyn_vuelo, adults);
                if (vuelo.Valid) vuelos.Add(vuelo);
            }
            if (response.IsSuccessful)
                return vuelos;
            return null; // COntrolar excepcion ??
        }

        public List<AmadeusVuelo> GetVuelosIdaVuelta(string origin, string destination, string departuredate, string returnDate, string adults)
        {
            this.token = GetToken();
            //cityCode=PAR&adults=1&radius=5&radiusUnit=KM&paymentPolicy=NONE&includeClosed=false&bestRateOnly=true&view=FULL&sort=PRICE
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
            //List<AmadeusVuelo> vuelos = dy_vuelos.data;
            List<AmadeusVuelo> vuelos = new List<AmadeusVuelo>();
            foreach (dynamic dv in dy_vuelos.data)
            {

                dynamic iti = dv.itineraries;
                dynamic iti1 = iti[0];
                if (iti1.size() == 1)
                {
                    AmadeusVuelo v = new AmadeusVuelo(iti, adults);
                    vuelos.Add(v);
                }

            }
            if (response.IsSuccessful)
                return vuelos;
            return null; // COntrolar excepcion ??
        }
    }
}
