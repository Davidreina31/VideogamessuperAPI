using System;
using LOCAL.Models;

namespace LOCAL.Interface
{
    public interface IPublisherService
    {
        Publisher GetByVideoGameId(int id);
    }
}
