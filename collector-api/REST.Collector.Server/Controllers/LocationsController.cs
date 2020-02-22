using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using REST.Collector.Server.Adapters;
using RestSharp;

namespace REST.Collector.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private IConfiguration _configuration;
        private ILocationsCollector locationsCollector;


        public LocationsController(IConfiguration configuration)
        {
            this._configuration = configuration;
            this.locationsCollector = new AmadeusLocationsAdapter();
        }

        private bool validateToken(string token)
        {
            var client = new RestClient(_configuration.GetValue<string>("ApplicationSettings:TokensEndPoint"));
            var getRequest = new RestRequest("/verify-token", Method.GET);
            getRequest.AddHeader("Authorization", token);
            var response = client.Execute(getRequest);
            return response.IsSuccessful;
        }

        /*
        [HttpGet("{code}")]
        public ActionResult GetLocation([FromHeader] string authorization, [FromRoute] string code)
        {
            if (String.IsNullOrEmpty(authorization) || !validateToken(authorization))
                return Unauthorized("Token invalido");
            return Ok(locationsCollector.GetLocation(code));
        }
        */

        [HttpGet]
        public ActionResult GetLocations([FromHeader] string authorization, [FromQuery] string keyword)
        {
            if (String.IsNullOrEmpty(authorization) || !validateToken(authorization))
                return Unauthorized("Token invalido");
            return Ok(locationsCollector.GetLocations(keyword));
        }
    }
}