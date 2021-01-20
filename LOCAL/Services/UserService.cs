using System;
using LOCAL.Interface;
using System.Linq;
using DAL.Interface;
using LOCAL.Models;
using LOCAL.Tools;
using System.Collections.Generic;

namespace LOCAL.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        

        public IEnumerable<User> Get()
        {
            return _userRepo.Get().Select(x => x.toLocal());
        }

        public User Get(int id)
        {
            return _userRepo.Get(id).toLocal();
        }

        public void Insert(User user)
        {
            _userRepo.Insert(user.toDal());
        }

        public void Update(User user)
        {
            _userRepo.Update(user.toDal());
        }

        public void Delete(int id)
        {
            _userRepo.Delete(id);
        }

        //public void AddVideoGame(User user, VideoGame videoGame, Plateform plateform)
        //{
        //    _userRepo.AddVideoGame(user.toDal(), videoGame.toDal(), plateform.toDal());
        //}
    }
}
