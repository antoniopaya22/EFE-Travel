using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using REST.Collector.Server.Model;
using RestSharp;

namespace REST.Collector.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VuelosController : ControllerBase
    {
        private IConfiguration _configuration;

        public static IList<Vuelo> database = new List<Vuelo>(new[]
        {
            new Vuelo { 
                Origen = "Madrid",
                Destino = "Barcelona",
                FechaSalidaIda = new DateTime(),
                FechaLlegadaIda = new DateTime(),
                Personas = 2,
                Precio = 22.5,
                Aerolinea = "Ryanair",
                Enlace = ""
            },
            new Vuelo {
                Origen = "Madrid",
                Destino = "Asturias",
                FechaSalidaIda = new DateTime(),
                FechaLlegadaIda = new DateTime(),
                Personas = 2,
                Precio = 82.5,
                Aerolinea = "Vueling",
                Enlace = ""
            },
            new Vuelo {
                Origen = "Madrid",
                Destino = "Venecia",
                FechaSalidaIda = new DateTime(),
                FechaLlegadaIda = new DateTime(),
                Personas = 2,
                Precio = 132.0,
                Aerolinea = "AirEuropa",
                Enlace = ""
            }
        });

        public VuelosController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        private bool validateToken(string token)
        {
            var client = new RestClient(_configuration.GetValue<string>("ApplicationSettings:TokensEndPoint"));
            var getRequest = new RestRequest("/verify-token", Method.GET);
            getRequest.AddHeader("Authorization", token);
            var response = client.Execute(getRequest);
            if(response.IsSuccessful)
                return true;
            return false;
        }

        [HttpGet]
        public ActionResult Get([FromHeader] string authorization)
        {
            if (String.IsNullOrEmpty(authorization) || !validateToken(authorization))
                return Unauthorized("Token invalido");
            return Ok(database);
        }


    }
}