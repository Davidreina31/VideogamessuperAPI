using System;
namespace LOCAL.Tools
{
    public static class DeveloperMapper
    {
        public static LOCAL.Models.Developer toLocal(this DAL.Models.Developer developer)
        {
            return new LOCAL.Models.Developer
            {
                DeveloperId = developer.DeveloperId,
                Name = developer.Name,
                CityId = developer.CityId
            };
        }

        public static DAL.Models.Developer toDal(this LOCAL.Models.Developer developer)
        {
            return new DAL.Models.Developer
            {
                DeveloperId = developer.DeveloperId,
                Name = developer.Name,
                CityId = developer.CityId
            };
        }
    }
}
