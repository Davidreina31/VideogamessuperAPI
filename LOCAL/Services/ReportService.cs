using System;
using LOCAL.Interface;
using System.Linq;
using DAL.Interface;
using LOCAL.Models;
using LOCAL.Tools;
using System.Collections.Generic;

namespace LOCAL.Services
{
    public class ReportService : IReportService
    {
        private IReportRepository _reportRepo;

        public ReportService(IReportRepository reportRepo)
        {
            _reportRepo = reportRepo;
        }
        

        public IEnumerable<Report> Get()
        {
            return _reportRepo.Get().Select(x => x.toLocal());
        }

        public Report Get(int id)
        {
            return _reportRepo.Get(id).toLocal();
        }

        public void Insert(Report report)
        {
            _reportRepo.Insert(report.toDal());
        }

        public void Update(Report report)
        {
            _reportRepo.Update(report.toDal());
        }

        public void Delete(int id)
        {
            _reportRepo.Delete(id);
        }
    }
}
