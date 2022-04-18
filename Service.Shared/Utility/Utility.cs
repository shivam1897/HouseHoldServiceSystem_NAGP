using System;

namespace Service.Shared
{
    public static class Utility
    {
        public static int GenerateRandomLocationSector()
        {
            var random = new Random();
            return random.Next(1, 150);
        }
    }
}
