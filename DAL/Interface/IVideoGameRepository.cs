using System;
using System.Collections.Generic;
using DAL.Models;

namespace DAL.Interface
{
    public interface IVideoGameRepository
    {
        IEnumerable<VideoGame> Get();
        VideoGame Get(int id);
        //Developer GetDeveloperByVideoGameId(int id);
    }
}
