using System;
namespace LOCAL.Models
{
    public class Report
    {
        public int ReportId { get; set; }

        public string Reason { get; set; }

        public DateTime ReportDate { get; set; }

        public int CommentId { get; set; }

        public int ReporterUserId { get; set; }
    }
}
