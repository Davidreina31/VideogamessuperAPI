using System;
namespace LOCAL.Tools
{
    public static class Plateform_VideoGameMapper
    {
        public static LOCAL.Models.Plateform_VideoGame toLocal(this DAL.Models.Plateform_VideoGame plateform_VideoGame)
        {
            return new LOCAL.Models.Plateform_VideoGame
            {
                Plateform_VideoGameId = plateform_VideoGame.Plateform_VideoGameId,
                VideoGameId = plateform_VideoGame.VideoGameId,
                PlateformId = plateform_VideoGame.PlateformId
            };
        }

        public static DAL.Models.Plateform_VideoGame toDal(this LOCAL.Models.Plateform_VideoGame plateform_VideoGame)
        {
            return new DAL.Models.Plateform_VideoGame
            {
                Plateform_VideoGameId = plateform_VideoGame.Plateform_VideoGameId,
                VideoGameId = plateform_VideoGame.VideoGameId,
                PlateformId = plateform_VideoGame.PlateformId
            };
        }
    }
}
