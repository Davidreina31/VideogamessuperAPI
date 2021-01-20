using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DAL.Interface;
using DAL.Models;
using Microsoft.Extensions.Configuration;

namespace DAL.Repository
{
    public class VideoGameRepository : BaseRepository, IVideoGameRepository
    {

        public VideoGameRepository(IConfiguration config) : base (config)
        {

        }


        public IEnumerable<VideoGame> Get()
        {
            using (_connection)
            {
                _connection.Open();

                using(SqlCommand cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT VideoGameId, [Name], [Description]," +
                        " ReleaseDate, DeveloperId, PublisherId, JacketUrl FROM VIDEOGAME";

                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return new VideoGame
                            {
                                VideoGameId = (int)reader["VideoGameId"],
                                Name = (string)reader["Name"],
                                Description = (string)reader["Description"],
                                ReleaseDate = (DateTime)reader["ReleaseDate"],
                                DeveloperId = (int)reader["DeveloperId"],
                                PublisherId = (int)reader["PublisherId"],
                                JacketUrl = (string)reader["JacketUrl"]
                            };
                        }
                    }
                }
            }
        }

        public VideoGame Get(int id)
        {
            VideoGame videoGame = new VideoGame();

            using (_connection)
            {
                _connection.Open();

                using (SqlCommand cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT VideoGameId, [Name], [Description]," +
                        " ReleaseDate, DeveloperId, PublisherId, JacketUrl FROM VIDEOGAME WHERE VideoGameId=@id";

                    cmd.Parameters.AddWithValue("id", id);

                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            videoGame.VideoGameId = (int)reader["VideoGameId"];
                            videoGame.Name = (string)reader["Name"];
                            videoGame.Description = (string)reader["Description"];
                            videoGame.ReleaseDate = (DateTime)reader["ReleaseDate"];
                            videoGame.DeveloperId = (int)reader["DeveloperId"];
                            videoGame.PublisherId = (int)reader["PublisherId"];
                            videoGame.JacketUrl = (string)reader["JacketUrl"];

                        }

                        return videoGame;
                    }
                }
            }
        }

        //public Developer GetDeveloperByVideoGameId(int id)
        //{
        //    Developer developer = new Developer();

        //    using (_connection)
        //    {
        //        _connection.Open();

        //        using(SqlCommand cmd = _connection.CreateCommand())
        //        {
        //            cmd.CommandText = "SELECT dev.DeveloperId, dev.Name, dev.CityId" +
        //                " FROM VIDEOGAME vg JOIN DEVELOPER dev ON" +
        //                " vg.DeveloperId = dev.DeveloperId WHERE vg.VideoGameId=@id";

        //            cmd.Parameters.AddWithValue("id", id);

        //            using(SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    developer.DeveloperId = (int)reader["DeveloperId"];
        //                    developer.Name = (string)reader["Name"];
        //                    developer.CityId = (int)reader["CityId"];
        //                }

        //                return developer;
        //            }
        //        }
        //    }
        //}
    }
}
