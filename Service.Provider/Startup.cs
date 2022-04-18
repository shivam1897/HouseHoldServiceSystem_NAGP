using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;
using Polly.Extensions.Http;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Service.Provider
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc();
            services.AddControllers();
            services.AddSingleton<IDataProvider, DataProvider>();
            services.AddSingleton<IServiceProviderInternal, ServiceProviderInternal>();
            services.AddSingleton<IHostedService, HostedServiceDiscovery>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGrpcService<ServiceProviderGrpc>();
                endpoints.MapGet("provider/randomTimeOut", (HttpContext request) =>
                {
                    return RandomTimeOut();
                }).WithDisplayName("RandomTimeOut");
            });
        }

        private static Task RandomTimeOut()
        {
            var random = new Random();
            var value = random.Next(0, 2);
            if (value == 0)
            {
                throw new Exception("Random Timeout");
            }
            return Task.FromResult(value);
        }

        static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(5, TimeSpan.FromSeconds(60));
        }
    }
}
