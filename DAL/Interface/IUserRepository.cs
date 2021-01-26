using System;
using System.Collections.Generic;
using DAL.Models;

namespace DAL.Interface
{
    public interface IUserRepository
    {
        User CorrectUser(string email, string password);

        IEnumerable<User> Get();

        User Get(int id);

        void Insert(User user);

        void Update(User user);

        void Delete(int id);

    }
}
