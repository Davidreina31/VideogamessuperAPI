using System;
using System.Collections.Generic;
using LOCAL.Models;

namespace LOCAL.Interface
{
    public interface IPlateform_VideoGameService
    {
        IEnumerable<Plateform_VideoGame> Get();
        IEnumerable<Plateform> GetByVideoGameId(int id);
    }
}
