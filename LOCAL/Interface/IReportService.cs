using System;
using System.Collections.Generic;
using LOCAL.Models;

namespace LOCAL.Interface
{
    public interface IReportService
    {
        IEnumerable<Report> Get();

        Report Get(int id);

        void Insert(Report report);

        void Update(Report report);

        void Delete(int id);
    }
}
