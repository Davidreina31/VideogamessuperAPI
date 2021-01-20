using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interface;
using LOCAL.Interface;
using LOCAL.Models;
using LOCAL.Tools;

namespace LOCAL.Services
{
    public class User_VideoGame_Service : IUser_VideoGame_Service
    {
        private IUser_VideoGame_Repository _UvRepo;
        private IUserService _userService;

        public User_VideoGame_Service(IUser_VideoGame_Repository UvRepo, IUserService userService)
        {
            _UvRepo = UvRepo;
            _userService = userService;
        }

        public IEnumerable<User_VideoGame> Get()
        {
            return _UvRepo.Get().Select(x => x.toLocal());
        }

        public User GetVideoGameByUserId(int id)
        {
            User user = new User();

            user = _userService.Get(id);
            user.videoGamesList = _UvRepo.GetVideoGameByUserId(id).Select(x => x.toLocal());
            return user;

        }

        public void Insert(User_VideoGame user_VideoGame)
        {
            _UvRepo.Insert(user_VideoGame.toDal());
        }

        public void Update(User_VideoGame user_VideoGame)
        {
            _UvRepo.Update(user_VideoGame.toDal());
        }

        public void Delete(int id)
        {
            _UvRepo.Delete(id);
        }
    }
}
