using System;
namespace LOCAL.Tools
{
    public static class VideoGameMapper
    {
        public static LOCAL.Models.VideoGame toLocal(this DAL.Models.VideoGame videoGame)
        {
            return new LOCAL.Models.VideoGame
            {
                VideoGameId = videoGame.VideoGameId,
                Name = videoGame.Name,
                Description = videoGame.Description,
                ReleaseDate = videoGame.ReleaseDate,
                DeveloperId = videoGame.DeveloperId,
                PublisherId = videoGame.PublisherId,
                JacketUrl = videoGame.JacketUrl
            };
        }

        public static DAL.Models.VideoGame toDal(this LOCAL.Models.VideoGame videoGame)
        {
            return new DAL.Models.VideoGame
            {
                VideoGameId = videoGame.VideoGameId,
                Name = videoGame.Name,
                Description = videoGame.Description,
                ReleaseDate = videoGame.ReleaseDate,
                DeveloperId = videoGame.DeveloperId,
                PublisherId = videoGame.PublisherId,
                JacketUrl = videoGame.JacketUrl
            };
        }
    }
}
