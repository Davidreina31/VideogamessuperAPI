using System;
using System.Data.SqlClient;
using DAL.Interface;
using DAL.Models;
using Microsoft.Extensions.Configuration;

namespace DAL.Repository
{
    public class DeveloperRepository : BaseRepository ,IDeveloperRepository
    {
        public DeveloperRepository(IConfiguration config) : base(config)
        {
        }

        public Developer GetByVideoGameId(int id)
        {
            Developer developer = new Developer();
            using (_connection)
            {
                _connection.Open();

                using (SqlCommand cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT dev.DeveloperId, dev.[Name]," +
                        " dev.CityId FROM DEVELOPER dev JOIN VIDEOGAME vg ON" +
                        " dev.DeveloperId = vg.DeveloperId WHERE vg.VideoGameId=@id";

                    cmd.Parameters.AddWithValue("id", id);

                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            developer.DeveloperId = (int)reader["DeveloperId"];
                            developer.Name = (string)reader["Name"];
                            developer.CityId = (int)reader["CityId"];
                        }

                        return developer;
                    }
                }
            }
        }
    }
}
