using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using REST.Collector.Server.Adapters;
using REST.Collector.Server.Model;
using RestSharp;

namespace REST.Collector.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VuelosController : ControllerBase
    {
        private IConfiguration _configuration;
        private IVuelosCollector vuelosCollector;


        public VuelosController(IConfiguration configuration)
        {
            this._configuration = configuration;
            this.vuelosCollector = new AmadeusVuelosAdapter();
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
        public ActionResult Get([FromHeader] string authorization, [FromQuery] string origin, [FromQuery] string destination, 
            [FromQuery] string departureDate, [FromQuery] string returnDate, [FromQuery] string adults)
        {
            //if (String.IsNullOrEmpty(authorization) || !validateToken(authorization))
              //  return Unauthorized("Token invalido");
            if(returnDate != null && returnDate != "")
                return Ok(vuelosCollector.GetVuelosIdaVuelta(origin, destination, departureDate, returnDate, adults));
            else
                return Ok(vuelosCollector.GetVuelosIda(origin, destination, departureDate, adults));
        }

    


    }
}