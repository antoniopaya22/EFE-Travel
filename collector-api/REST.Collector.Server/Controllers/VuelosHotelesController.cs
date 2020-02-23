using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using REST.Collector.Server.Adapters;
using REST.Collector.Server.Model;
using RestSharp;

namespace REST.Collector.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VuelosHotelesController : ControllerBase
    {

        private IConfiguration _configuration;
        private IVuelosCollector vuelosCollector;
        private IHotelesCollector hotelesCollector;


        public VuelosHotelesController(IConfiguration configuration)
        {
            this._configuration = configuration;
            this.vuelosCollector = new AmadeusVuelosAdapter();
            this.hotelesCollector = new AmadeusHotelesAdapter();
        }

        private bool validateToken(string token)
        {
            var client = new RestClient(_configuration.GetValue<string>("ApplicationSettings:TokensEndPoint"));
            var getRequest = new RestRequest("/verify-token", Method.GET);
            getRequest.AddHeader("Authorization", token);
            var response = client.Execute(getRequest);
            return response.IsSuccessful;
        }

        [HttpGet]
        public ActionResult Get([FromHeader] string authorization, [FromQuery] string origen, [FromQuery] string destino,
            [FromQuery] string fechaSalida, [FromQuery] string fechaLlegada, [FromQuery] string personas)
        {
            if (String.IsNullOrEmpty(authorization) || !validateToken(authorization))
                return Unauthorized("Token invalido");
            List<Hotel> hoteles = hotelesCollector.GetHoteles(destino, personas);
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            string str_hoteles = JsonConvert.SerializeObject(hoteles, serializerSettings);
            string str_vuelos = "";
            if (fechaLlegada != null && fechaLlegada != "")
                str_vuelos = JsonConvert.SerializeObject(vuelosCollector.GetVuelosIdaVuelta(origen, destino, fechaSalida, fechaLlegada, personas), serializerSettings);
            else
                str_vuelos = JsonConvert.SerializeObject(vuelosCollector.GetVuelosIda(origen, destino, fechaSalida, personas), serializerSettings);
            string hoteles_vuelos = "{\"hoteles\":"+ str_hoteles + ", \"vuelos\":"+str_vuelos+"}";
            return Ok(hoteles_vuelos);
        }
    }
}