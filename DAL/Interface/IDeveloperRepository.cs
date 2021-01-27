using System;
using DAL.Models;

namespace DAL.Interface
{
    public interface IDeveloperRepository
    {
        Developer GetByVideoGameId(int id);
    }
}
