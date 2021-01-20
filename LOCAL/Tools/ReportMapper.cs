using System;
namespace LOCAL.Tools
{
    public static class ReportMapper
    {
        public static LOCAL.Models.Report toLocal(this DAL.Models.Report report)
        {
            return new LOCAL.Models.Report
            {
                ReportId = report.ReportId,
                Reason = report.Reason,
                ReportDate = report.ReportDate,
                CommentId = report.CommentId,
                ReporterUserId = report.ReporterUserId
            };
        }

        public static DAL.Models.Report toDal(this LOCAL.Models.Report report)
        {
            return new DAL.Models.Report
            {
                ReportId = report.ReportId,
                Reason = report.Reason,
                ReportDate = report.ReportDate,
                CommentId = report.CommentId,
                ReporterUserId = report.ReporterUserId
            };
        }
    }
}
