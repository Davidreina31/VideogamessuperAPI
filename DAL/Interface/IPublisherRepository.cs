using System;
using DAL.Models;

namespace DAL.Interface
{
    public interface IPublisherRepository
    {
        Publisher GetByVideoGameId(int id);
    }
}
