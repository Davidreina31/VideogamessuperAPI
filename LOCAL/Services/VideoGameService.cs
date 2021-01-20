using System;
using LOCAL.Interface;
using System.Linq;
using DAL.Interface;
using LOCAL.Models;
using LOCAL.Tools;
using System.Collections.Generic;

namespace LOCAL.Services
{
    public class VideoGameService : IVideoGameService
    {
        private IVideoGameRepository _videoGameRepo;

        public VideoGameService(IVideoGameRepository videoGameRepo)
        {
            _videoGameRepo = videoGameRepo;
        }

        public IEnumerable<VideoGame> Get()
        {
            return _videoGameRepo.Get().Select(x => x.toLocal());
        }

        public VideoGame Get(int id)
        {
            //VideoGame videoGame = new VideoGame();

            //videoGame.Developer = _videoGameRepo.GetDeveloperByVideoGameId(id).toLocal();
            //videoGame = _videoGameRepo.Get(id).toLocal();
            //return videoGame;

            return _videoGameRepo.Get(id).toLocal();
        }
    }
}
