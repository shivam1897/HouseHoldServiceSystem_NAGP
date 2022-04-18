using Grpc.Net.Client;
using Service.Shared;
using System;

namespace Service.Admin
{
    public class ServiceProviderGrpc
    {
        private SreviceProvider.SreviceProviderClient _client;

        public ServiceProviderGrpc()
        {
            var channel = GrpcChannel.ForAddress("http://localhost:7012");
            _client = new SreviceProvider.SreviceProviderClient(channel);
        }

        public ServiceProviderResponse GetAvailiableServiceProvider(int service)
        {
            var request = new ServiceProviderRequest
            {
                RequestId = Guid.NewGuid().ToString(),
                ServiceType = service,
                Location = Utility.GenerateRandomLocationSector()
            };

            var response = _client.GetServiceProviderAvailiable(request);
            return response;
        }

    }
}
