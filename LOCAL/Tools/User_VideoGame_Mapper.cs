using System;
namespace LOCAL.Tools
{
    public static class User_VideoGame_Mapper
    {
        public static LOCAL.Models.User_VideoGame toLocal(this DAL.Models.User_VideoGame user_VideoGame)
        {
            return new LOCAL.Models.User_VideoGame
            {
                User_VideoGame_id = user_VideoGame.User_VideoGame_id,
                UserId = user_VideoGame.UserId,
                VideoGameId = user_VideoGame.VideoGameId,
                //UserName = user_VideoGame.UserName,
                //VideoGameName = user_VideoGame.VideoGameName,
                //PlateformName = user_VideoGame.PlateformName,
                //videoGamesList = user_VideoGame.videoGamesList,
                //PlateformList = user_VideoGame.PlateformList
            };
        }

        public static DAL.Models.User_VideoGame toDal(this LOCAL.Models.User_VideoGame user_VideoGame)
        {
            return new DAL.Models.User_VideoGame
            {
                User_VideoGame_id = user_VideoGame.User_VideoGame_id,
                UserId = user_VideoGame.UserId,
                VideoGameId = user_VideoGame.VideoGameId,
                //UserName = user_VideoGame.UserName,
                //VideoGameName = user_VideoGame.VideoGameName,
                //PlateformName = user_VideoGame.PlateformName,
                //videoGamesList = user_VideoGame.videoGamesList,
                //PlateformList = user_VideoGame.PlateformList
            };
        }
    }
}
