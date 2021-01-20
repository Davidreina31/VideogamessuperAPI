using System;
using System.Collections.Generic;
using LOCAL.Models;

namespace LOCAL.Interface
{
    public interface IUser_VideoGame_Service
    {
        IEnumerable<User_VideoGame> Get();

        User GetVideoGameByUserId(int id);

        void Insert(User_VideoGame user_VideoGame);

        void Update(User_VideoGame user_VideoGame);

        void Delete(int id);
    }
}
