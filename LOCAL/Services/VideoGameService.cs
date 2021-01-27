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
        private IPlateform_VideoGameService _plateform_VideoGameService;
        private IDeveloperService _developerService;
        private IPublisherService _publisherService;

        public VideoGameService(IVideoGameRepository videoGameRepo, IPlateform_VideoGameService plateform_VideoGameService, IDeveloperService developerService, IPublisherService publisherService)
        {
            _videoGameRepo = videoGameRepo;
            _plateform_VideoGameService = plateform_VideoGameService;
            _developerService = developerService;
            _publisherService = publisherService;
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
            VideoGame videoGame = new VideoGame();

            videoGame = _videoGameRepo.Get(id).toLocal();
            videoGame.Developer = _developerService.GetByVideoGameId(id);
            videoGame.Publisher = _publisherService.GetByVideoGameId(id);
            videoGame.plateforms = _plateform_VideoGameService.GetByVideoGameId(id);

            return videoGame;

        }
    }
}
