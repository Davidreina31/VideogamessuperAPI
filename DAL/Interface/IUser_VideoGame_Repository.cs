using System;
using System.Collections.Generic;
using DAL.Models;

namespace DAL.Interface
{
    public interface IUser_VideoGame_Repository
    {
        IEnumerable<User_VideoGame> Get();

        IEnumerable<VideoGame> GetVideoGameByUserId(int id);

        void Insert(User_VideoGame user_VideoGame);

        void Update(User_VideoGame user_VideoGame);

        void Delete(int id);
    }
}
