using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Service.Provider.Controllers
{
    [ApiController]
    [Route("/api/provider/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static int ExceptionCount = 0;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/circuit")]
        public HttpResponseMessage Get()
        {
            if(ExceptionCount <= 4)
                throw new NotImplementedException();

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }
    }
}
