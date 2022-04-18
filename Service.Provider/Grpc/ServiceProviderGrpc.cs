using Grpc.Core;
using Service.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Provider
{
    /// <summary>
    /// Service provider grpc class
    /// </summary>
    public class ServiceProviderGrpc : SreviceProvider.SreviceProviderBase
    {
        private readonly IServiceProviderInternal _services;

        /// <summary>
        /// ctr
        /// </summary>
        /// <param name="serviceProviderInternal"></param>
        public ServiceProviderGrpc(IServiceProviderInternal serviceProviderInternal)
        {
            _services = serviceProviderInternal;
        }

        /// <summary>
        /// Returns availiable service provider
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<ServiceProviderResponse> GetServiceProviderAvailiable(ServiceProviderRequest request, ServerCallContext context)
        {
            ServiceProvider nearestVendor = GetNearestVendor(request);

            if(nearestVendor == default)
            {
                return Task.FromResult(new ServiceProviderResponse
                {
                    RequestId = request.RequestId,
                    Availiable = false
                }) ;
            }
            var response = new ServiceProviderResponse
            {
                Name = nearestVendor.Name,
                ContactNumber = nearestVendor.ContactNumber,
                RequestId = request.RequestId,
                Availiable = true
            };
            return Task.FromResult(response);
        }

        /// <summary>
        /// Get nearest vendor details
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private ServiceProvider GetNearestVendor(ServiceProviderRequest request)
        {
            var serviceProviderList = _services.GetSpecificServiceProvider((Services)request.ServiceType);
            if (!serviceProviderList.Any())
                return default;

            var nearestVendor = CalculateNearestVendor(serviceProviderList, request.Location);
            return nearestVendor;
        }

        /// <summary>
        /// Calculate nearest vendor
        /// </summary>
        /// <param name="serviceProviderList"></param>
        /// <param name="locationOfRequester"></param>
        /// <returns></returns>
        private static ServiceProvider CalculateNearestVendor(List<ServiceProvider> serviceProviderList, int locationOfRequester)
        {
            int minDistance = int.MaxValue, key = -1;
            foreach(var vendor in serviceProviderList)
            {
                if(minDistance > Math.Abs(locationOfRequester - vendor.Location))
                {
                    minDistance = Math.Abs(locationOfRequester - vendor.Location);
                    key = vendor.Id;
                }
            }
            return serviceProviderList.Where(x => x.Id == key).FirstOrDefault();
        }
    }
}
