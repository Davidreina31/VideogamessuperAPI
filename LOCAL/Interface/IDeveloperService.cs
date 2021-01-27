using System;
using LOCAL.Models;

namespace LOCAL.Interface
{
    public interface IDeveloperService
    {
        Developer GetByVideoGameId(int id);
    }
}
