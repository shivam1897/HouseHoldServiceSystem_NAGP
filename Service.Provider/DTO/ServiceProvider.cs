using Service.Shared;

namespace Service.Provider
{
    /// <summary>
    /// Service provider dto class
    /// </summary>
    public class ServiceProvider
    {
        /// <summary>
        /// Vendor unique id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Service offered 
        /// </summary>
        public Services ServiceOffered { get; set; }

        /// <summary>
        /// Contact number
        /// </summary>
        public int ContactNumber { get; set; }

        /// <summary>
        /// Location in sector of Gurgaon
        /// </summary>
        public int Location { get; set; }

        /// <summary>
        /// Is provider availiable for service
        /// </summary>
        public bool IsAvailiable { get; set; }
    }
}
