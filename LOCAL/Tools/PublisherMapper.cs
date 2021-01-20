using System;
namespace LOCAL.Tools
{
    public static class PublisherMapper
    {
        public static LOCAL.Models.Publisher toLocal(this DAL.Models.Publisher publisher)
        {
            return new LOCAL.Models.Publisher
            {
                PublisherId = publisher.PublisherId,
                Name = publisher.Name,
                CityId = publisher.CityId
            };
        }

        public static DAL.Models.Publisher toDal(this LOCAL.Models.Publisher publisher)
        {
            return new DAL.Models.Publisher
            {
                PublisherId = publisher.PublisherId,
                Name = publisher.Name,
                CityId = publisher.CityId
            };
        }
    }
}
