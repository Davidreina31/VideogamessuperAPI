using System;
using System.Collections.Generic;
using DAL.Models;

namespace DAL.Interface
{
    public interface IPlateform_VideoGameRepository
    {
        IEnumerable<Plateform_VideoGame> Get();
        IEnumerable<Plateform> GetByVideoGameId(int id);
    }
}
