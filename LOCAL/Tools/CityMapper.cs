using System;
namespace LOCAL.Tools
{
    public static class CityMapper
    {
        public static LOCAL.Models.City toLocal(this DAL.Models.City city)
        {
            return new LOCAL.Models.City
            {
                CityId = city.CityId,
                Name = city.Name,
                CountryCode = city.CountryCode
            };
        }

        public static DAL.Models.City toDal(this LOCAL.Models.City city)
        {
            return new DAL.Models.City
            {
                CityId = city.CityId,
                Name = city.Name,
                CountryCode = city.CountryCode
            };
        }
    }
}
