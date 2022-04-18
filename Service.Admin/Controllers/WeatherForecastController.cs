using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Service.Admin.Controllers
{
    [ApiController]
    [Route("api/admin/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IConfiguration _config;
        private readonly IAdminOfficeServices _adminServices;
        private readonly HttpClient _httpClient;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration config, IAdminOfficeServices adminServices, HttpClient httpClient)
        {
            _logger = logger;
            _config = config;
            _adminServices = adminServices;
            _httpClient = httpClient;
        }

        [HttpGet]
        public ServiceProviderResponse Get()
        {
            return default;
        }

        [HttpGet("{id}")]
        public ServiceProviderResponse Get(int id)
        {
            return _adminServices.GetAvailiableServiceProvider(id);
        }

        [HttpGet("/circuit")]
        public HttpResponseMessage CircuitBreakerTest()
        {
            var requesURL = _config.GetValue<string>("SerivceProviderURL");
            return _httpClient.GetAsync(requesURL + "/provider/circuit").Result;
        }
    }
}
