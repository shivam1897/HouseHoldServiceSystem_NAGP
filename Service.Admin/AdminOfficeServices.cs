namespace Service.Admin
{
    /// <summary>
    /// Admin office services
    /// </summary>
    public class AdminOfficeServices : IAdminOfficeServices
    {
        private readonly ServiceProviderGrpc _grpcClient;

        /// <summary>
        /// ctr
        /// </summary>
        public AdminOfficeServices()
        {
            _grpcClient = new ServiceProviderGrpc();
        }

        /// <summary>
        /// Gets Availiable service provider
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceProviderResponse GetAvailiableServiceProvider(int id)
        {
            var grpcRespnse = _grpcClient.GetAvailiableServiceProvider(id);
            return grpcRespnse;
        }
    }
}
