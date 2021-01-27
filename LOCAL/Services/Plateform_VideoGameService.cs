using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interface;
using LOCAL.Interface;
using LOCAL.Models;
using LOCAL.Tools;

namespace LOCAL.Services
{
    public class Plateform_VideoGameService : IPlateform_VideoGameService
    {
        private IPlateform_VideoGameRepository _plateform_VideoGameRepo;

        public Plateform_VideoGameService(IPlateform_VideoGameRepository plateform_VideoGameRepo)
        {
            _plateform_VideoGameRepo = plateform_VideoGameRepo;
        }

        public IEnumerable<Plateform_VideoGame> Get()
        {
            return _plateform_VideoGameRepo.Get().Select(x => x.toLocal());
        }

        public IEnumerable<Plateform> GetByVideoGameId(int id)
        {
            return _plateform_VideoGameRepo.GetByVideoGameId(id).Select(x => x.toLocal());
        }
    }
}
