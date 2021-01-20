using System;
namespace LOCAL.Tools
{
    public static class PlateformMapper
    {
        public static LOCAL.Models.Plateform toLocal(this DAL.Models.Plateform plateform)
        {
            return new LOCAL.Models.Plateform
            {
                PlateformId = plateform.PlateformId,
                PlateformName = plateform.PlateformName
            };
        }

        public static DAL.Models.Plateform toDal(this LOCAL.Models.Plateform plateform)
        {
            return new DAL.Models.Plateform
            {
                PlateformId = plateform.PlateformId,
                PlateformName = plateform.PlateformName
            };
        }
    }
}
