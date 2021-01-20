using System;
using System.Collections.Generic;
using LOCAL.Models;

namespace LOCAL.Interface
{
    public interface IVideoGameService
    {
        IEnumerable<VideoGame> Get();
        VideoGame Get(int id);
    }
}
