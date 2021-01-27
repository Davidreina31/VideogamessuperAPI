using System;
using System.Data.SqlClient;
using DAL.Interface;
using DAL.Models;
using Microsoft.Extensions.Configuration;

namespace DAL.Repository
{
    public class PublisherRepository : BaseRepository ,IPublisherRepository
    {
        public PublisherRepository(IConfiguration config) : base(config)
        {
        }

        public Publisher GetByVideoGameId(int id)
        {
            Publisher publisher = new Publisher();
            using (_connection)
            {
                _connection.Open();

                using (SqlCommand cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT pu.PublisherId, pu.[Name]," +
                        " pu.CityId FROM PUBLISHER pu JOIN VIDEOGAME vg ON" +
                        " pu.PublisherId = vg.PublisherId WHERE vg.VideoGameId =@id";

                    cmd.Parameters.AddWithValue("id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            publisher.PublisherId = (int)reader["PublisherId"];
                            publisher.Name = (string)reader["Name"];
                            publisher.CityId = (int)reader["CityId"];
                        }

                        return publisher;
                    }
                }
            }
        }
    }
}
