using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace Service.Admin.Controllers
{
    [ApiController]
    [Route("api/admin/[controller]")]
    public class AdminServiceController : ControllerBase
    {
        private readonly ILogger<AdminServiceController> _logger;
        private readonly IConfiguration _config;
        private readonly IAdminOfficeServices _adminServices;
        private HttpClient _httpClient;

        public AdminServiceController(ILogger<AdminServiceController> logger, IConfiguration config, IAdminOfficeServices adminServices)
        {
            _logger = logger;
            _config = config;
            _adminServices = adminServices;
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
            _httpClient = new HttpClient();
            var requesURL = _config.GetValue<string>("SerivceProviderURL");
            return _httpClient.GetAsync(requesURL + "/provider/circuit").Result;
        }
    }
}
