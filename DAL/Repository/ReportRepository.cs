using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DAL.Interface;
using DAL.Models;
using Microsoft.Extensions.Configuration;

namespace DAL.Repository
{
    public class ReportRepository : BaseRepository, IReportRepository
    {
        public ReportRepository(IConfiguration config) : base(config)
        {

        }
        public int x;


        public IEnumerable<Report> Get()
        {
            using (_connection)
            {
                _connection.Open();

                using (SqlCommand cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT ReportId, Reason, ReportDate," +
                        " CommentId, ReporterUserId FROM REPORT";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return new Report
                            {
                                ReportId = (int) reader["ReportId"],
                                Reason = (string) reader["Reason"],
                                ReportDate = (DateTime) reader["ReportDate"],
                                CommentId = (int) reader["CommentId"],
                                ReporterUserId = (int) reader["ReporterUserId"],
                            };
                        }
                    }
                }
            }
        }

        public Report Get(int id)
        {
            Report report = new Report();
            using (_connection)
            {
                _connection.Open();

                using(SqlCommand cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT ReportId, Reason, ReportDate," +
                        " CommentId, ReporterUserId FROM REPORT WHERE ReportId=@id";

                    cmd.Parameters.AddWithValue("id", id);

                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            report.ReportId = (int)reader["ReportId"];
                            report.Reason = (string)reader["Reason"];
                            report.ReportDate = (DateTime)reader["ReportDate"];
                            report.CommentId = (int)reader["CommentId"];
                            report.ReporterUserId = (int)reader["ReporterUserId"];
                        }

                        return report;
                    }
                }
            }
        }

        public void Insert(Report report)
        {
            using (_connection)
            {
                _connection.Open();

                using (SqlCommand cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO REPORT (Reason, ReportDate, CommentId, ReporterUserId)" +
                        " OUTPUT inserted.ReportId VALUES (@reason, @date, @CId, @RUId)";

                    cmd.Parameters.AddWithValue("reason", report.Reason);
                    cmd.Parameters.AddWithValue("date", DateTime.Now);
                    cmd.Parameters.AddWithValue("CId", report.CommentId);
                    cmd.Parameters.AddWithValue("RUId", report.ReporterUserId);

                    int id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Update(Report report)
        {
            using (_connection)
            {
                _connection.Open();

                using (SqlCommand cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE REPORT SET Reason=@reason, ReportDate=@date," +
                        " CommentId=@CId, ReporterUserId=@RUId WHERE ReportId=@id";

                    cmd.Parameters.AddWithValue("reason", report.Reason);
                    cmd.Parameters.AddWithValue("date", DateTime.Now);
                    cmd.Parameters.AddWithValue("CId", report.CommentId);
                    cmd.Parameters.AddWithValue("RUId", report.ReporterUserId);
                    cmd.Parameters.AddWithValue("id", report.ReportId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (_connection)
            {
                _connection.Open();

                using(SqlCommand cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM REPORT WHERE ReportId=@id";

                    cmd.Parameters.AddWithValue("id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
