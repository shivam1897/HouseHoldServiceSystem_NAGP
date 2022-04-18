using Service.Shared;
using System.Collections.Generic;

namespace Service.Provider
{
    internal interface IDataProvider
    {
        List<ServiceProvider> GetAllServiceProviders();

        List<ServiceProvider> GetSpecificServiceProvider(Services serviceType);

        List<ServiceProvider> GetSpecificActiveServiceProvider(Services serviceType);

        List<ServiceProvider> GetAllActivieServiceProvider();
    }
}