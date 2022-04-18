using Service.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Provider
{
    internal class DataProvider : IDataProvider
    {
        private readonly List<ServiceProvider> _dataBase;

        /// <summary>
        /// ctr
        /// </summary>
        public DataProvider()
        {
            _dataBase = ServiceProviderDataBase.Data;
        }

        public List<ServiceProvider> GetAllActivieServiceProvider()
        {
            return _dataBase.Select(x => x).Where(v => v.IsAvailiable == true).ToList();
        }

        public List<ServiceProvider> GetAllServiceProviders() => _dataBase.Select(x => x).ToList();

        public List<ServiceProvider> GetSpecificActiveServiceProvider(Services serviceType)
        {
            return _dataBase.Select(x => x).Where(v => v.ServiceOffered == serviceType && v.IsAvailiable == true).ToList();
        }

        public List<ServiceProvider> GetSpecificServiceProvider(Services serviceType)
        {
            return _dataBase.Select(x => x).Where(v => v.ServiceOffered == serviceType).ToList();
        }
    }
}
