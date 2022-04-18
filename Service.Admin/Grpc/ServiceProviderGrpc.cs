using Grpc.Net.Client;
using Service.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Admin
{
    public class ServiceProviderGrpc
    {
        private SreviceProvider.SreviceProviderClient _client;

        public ServiceProviderGrpc()
        {
            var channel = GrpcChannel.ForAddress("http://localhost:7002");
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
