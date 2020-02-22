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
    public class RecomendacionesController : ControllerBase
    {
        private IConfiguration _configuration;
        private IRecommendationsCollector recomsCollector;


        public RecomendacionesController(IConfiguration configuration)
        {
            this._configuration = configuration;
            this.recomsCollector = new AmadeusRecommendationAdapter();
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
        public ActionResult Get([FromHeader] string authorization, [FromQuery] string origen)
        {
            if (String.IsNullOrEmpty(authorization) || !validateToken(authorization))
                return Unauthorized("Token invalido");
            return Ok(recomsCollector.GetRecommendations(origen));
        }
    }
}