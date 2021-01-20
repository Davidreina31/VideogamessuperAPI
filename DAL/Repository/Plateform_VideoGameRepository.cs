using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DAL.Interface;
using DAL.Models;
using Microsoft.Extensions.Configuration;

namespace DAL.Repository
{
    public class Plateform_VideoGameRepository : BaseRepository, IPlateform_VideoGameRepository
    {
        public Plateform_VideoGameRepository(IConfiguration config) : base(config)
        {

        }

        public IEnumerable<Plateform_VideoGame> Get()
        {
            using (_connection)
            {
                _connection.Open();

                using (SqlCommand cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, VideoGameId, PlateformId FROM PLATEFORM_VIDEOGAME";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return new Plateform_VideoGame
                            {
                                Plateform_VideoGameId = (int)reader["Id"],
                                VideoGameId = (int)reader["VideoGameId"],
                                PlateformId = (int)reader["PlateformId"]
                            };
                        }
                    }
                }
            }
        }

        public Plateform_VideoGame Get(int id)
        {
            Plateform_VideoGame plateform_VideoGame = new Plateform_VideoGame();
            using (_connection)
            {
                _connection.Open();

                using (SqlCommand cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, VideoGameId, PlateformId" +
                        " FROM PLATEFORM_VIDEOGAME WHERE Id = @id";

                    cmd.Parameters.AddWithValue("id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            plateform_VideoGame.Plateform_VideoGameId = (int)reader["Id"];
                            plateform_VideoGame.VideoGameId = (int)reader["VideoGameId"];
                            plateform_VideoGame.PlateformId = (int)reader["PlateformId"];
                        }

                        return plateform_VideoGame;
                    }
                }
            }
        }
    }
}
