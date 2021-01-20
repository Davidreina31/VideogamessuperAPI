using System;
namespace LOCAL.Tools
{
    public static class UserMapper
    {
        public static LOCAL.Models.User toLocal(this DAL.Models.User user)
        {
            return new LOCAL.Models.User
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                Admin = user.Admin,
                DeletedDate = user.DeletedDate,
                //VideoGame = user.VideoGame
                
            };
        }

        public static DAL.Models.User toDal(this LOCAL.Models.User user)
        {
            return new DAL.Models.User
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                Admin = user.Admin,
                DeletedDate = user.DeletedDate,
                //VideoGame = user.VideoGame

            };
        }
    }
}
