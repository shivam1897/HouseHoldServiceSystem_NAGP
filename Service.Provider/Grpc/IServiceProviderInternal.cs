using Service.Shared;
using System.Collections.Generic;

namespace Service.Provider
{
    public interface IServiceProviderInternal
    {
        List<ServiceProvider> GetSpecificServiceProvider(Services serviceType, bool isActive = true);
    }
}