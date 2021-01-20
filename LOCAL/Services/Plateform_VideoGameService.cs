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

        public Plateform_VideoGame Get(int id)
        {
            return _plateform_VideoGameRepo.Get(id).toLocal();
        }
    }
}
