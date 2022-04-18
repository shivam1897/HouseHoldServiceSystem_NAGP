using Service.Shared;
using System.Collections.Generic;

namespace Service.Provider
{
    internal class ServiceProviderInternal : IServiceProviderInternal
    {
        private readonly IDataProvider _dataProvider;

        public ServiceProviderInternal(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider; 
        }

        public List<ServiceProvider> GetSpecificServiceProvider(Services serviceType, bool isActive = true)
        {
            if(isActive)
                return _dataProvider.GetSpecificActiveServiceProvider(serviceType);

            return _dataProvider.GetSpecificServiceProvider(serviceType);
        }
    }
}
