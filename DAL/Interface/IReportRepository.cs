using System;
using System.Collections.Generic;
using DAL.Models;

namespace DAL.Interface
{
    public interface IReportRepository
    {
        IEnumerable<Report> Get();

        Report Get(int id);

        void Insert(Report report);

        void Update(Report report);

        void Delete(int id);
    }
}
