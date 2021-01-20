using System;
using System.Collections.Generic;
using LOCAL.Models;

namespace LOCAL.Interface
{
    public interface IUserService
    {
        IEnumerable<User> Get();

        User Get(int id);

        void Insert(User user);

        void Update(User user);

        void Delete(int id);

        //void AddVideoGame(User user, VideoGame videoGame, Plateform plateform);
    }
}
