using Service.Shared;
using System.Collections.Generic;

namespace Service.Provider
{
    /// <summary>
    /// All service providers registered 
    /// </summary>
    public static class ServiceProviderDataBase
    {
        /// <summary>
        /// Data of service providers
        /// </summary>
        public static List<ServiceProvider> Data = new List<ServiceProvider>
        {
            {new ServiceProvider{ Id = 1001, Name = "Shravan", ServiceOffered = Services.Electrician, ContactNumber = 1234, IsAvailiable = true, Location = 21} },
            {new ServiceProvider{ Id = 1002, Name = "Rajat", ServiceOffered = Services.Electrician, ContactNumber = 9981, IsAvailiable = true, Location = 56} },
            {new ServiceProvider{ Id = 1003, Name = "Vaibhav", ServiceOffered = Services.Electrician, ContactNumber = 1234, IsAvailiable = false, Location = 44} },
            {new ServiceProvider{ Id = 1004, Name = "Shubhneet", ServiceOffered = Services.Painter, ContactNumber = 3421, IsAvailiable = true, Location = 101} },
            {new ServiceProvider{ Id = 1005, Name = "Pooja", ServiceOffered = Services.Painter, ContactNumber = 5543, IsAvailiable = true, Location = 75} },
            {new ServiceProvider{ Id = 1006, Name = "Kiara", ServiceOffered = Services.Painter, ContactNumber = 1234, IsAvailiable = false, Location = 51} },
            {new ServiceProvider{ Id = 1007, Name = "Shivam", ServiceOffered = Services.Plumber, ContactNumber = 9087, IsAvailiable = true, Location = 13} },
            {new ServiceProvider{ Id = 1008, Name = "Mayur", ServiceOffered = Services.Plumber, ContactNumber = 5432, IsAvailiable = true, Location = 37} },
            {new ServiceProvider{ Id = 1009, Name = "Soorpnakha", ServiceOffered = Services.Plumber, ContactNumber = 0098, IsAvailiable = false, Location = 120} },
            {new ServiceProvider{ Id = 1010, Name = "Kokila", ServiceOffered = Services.Salon, ContactNumber = 0954, IsAvailiable = true, Location = 33 } },
            {new ServiceProvider{ Id = 1011, Name = "Litton", ServiceOffered = Services.Salon, ContactNumber = 1342, IsAvailiable = true, Location = 11 } },
            {new ServiceProvider{ Id = 1012, Name = "Piku", ServiceOffered = Services.Salon, ContactNumber = 5432, IsAvailiable = false, Location = 76 } },
        };
    }
}
