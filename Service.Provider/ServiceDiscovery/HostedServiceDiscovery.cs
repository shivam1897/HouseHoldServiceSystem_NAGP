using Consul;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Provider
{
    /// <summary>
    /// Class to register service to Consul
    /// </summary>
    public class HostedServiceDiscovery : IHostedService
    {
        private readonly IConfiguration _config;
        private readonly ConsulClient _consulClient;
        private string _registrationId;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="config"></param>
        public HostedServiceDiscovery(IConfiguration config)
        {
            _config = config;
            _consulClient = new ConsulClient(x =>
            {
                x.Address = _config.GetValue<Uri>("ServiceConfiguration:ServiceDicoveryAddress");
            });
            SetRegistrationId();
        }

        /// <summary>
        /// Register while starting service
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task StartAsync(CancellationToken cancellationToken)
        {
            var serviceName = _config.GetValue<string>("ServiceConfiguration:ServiceName");
            var serviceAddress = _config.GetValue<Uri>("ServiceConfiguration:ServiceAddress");
            var agentServiceRegister = new AgentServiceRegistration()
            {
                Address = serviceAddress.Host,
                ID = _registrationId,
                Name = serviceName,
                Port = serviceAddress.Port
            };
            _ = Task.FromResult(_consulClient.Agent.ServiceDeregister(_registrationId, cancellationToken)).Result;
            return Task.FromResult(_consulClient.Agent.ServiceRegister(agentServiceRegister, cancellationToken));
        }

        /// <summary>
        /// De-registering while stopping service
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(_consulClient.Agent.ServiceDeregister(_registrationId, cancellationToken));
        }

        /// <summary>
        /// Set registration-id of service
        /// </summary>
        private void SetRegistrationId()
        {
            var serviceId = _config.GetValue<string>("ServiceConfiguration:ServiceId");
            var serviceName = _config.GetValue<string>("ServiceConfiguration:ServiceName");

            _registrationId = $"{serviceName}-{serviceId}";
        }
    }
}
