using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DAL.Interface;
using DAL.Models;
using Microsoft.Extensions.Configuration;

namespace DAL.Repository
{
    public class User_VideoGame_Repository : BaseRepository, IUser_VideoGame_Repository
    {
        public User_VideoGame_Repository(IConfiguration config) : base(config)
        {

        }

        public IEnumerable<User_VideoGame> Get()
        {
            using (_connection)
            {
                _connection.Open();

                using (SqlCommand cmd = _connection.CreateCommand())
                {
                    //cmd.CommandText = "SELECT u.UserId, uv.User_VideoGame_id, PlVg.Id, u.UserName," +
                    //    "  vg.Name, Pl.PlateformName FROM [USER] u JOIN USER_VIDEOGAME uv ON u.UserId = uv.UserId" +
                    //    " JOIN PLATEFORM_VIDEOGAME PlVg ON uv.Plateform_VideoGameId = PlVg.Id JOIN" +
                    //    " PLATEFORM pl ON PlVg.PlateformId = pl.PlateformId JOIN" +
                    //    " VIDEOGAME vg ON PlVg.VideoGameId = vg.VideoGameId";

                    cmd.CommandText = "SELECT UserId, User_VideoGame_id, VideoGameId FROM USER_VIDEOGAME";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return new User_VideoGame
                            {
                                User_VideoGame_id = (int)reader["User_VideoGame_id"],
                                UserId = (int)reader["UserId"],
                                VideoGameId = (int)reader["VideoGameId"],
                                //UserName = (string)reader["UserName"],
                                //VideoGameName = (string)reader["Name"],
                                //PlateformName = (string)reader["PlateformName"],

                            };
                        }
                    }

                }
            }
        }

        public IEnumerable<User_VideoGame> GetOne(int id)
        {
            using (_connection)
            {
                _connection.Open();

                using (SqlCommand cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT UserId, User_VideoGame_id, VideoGameId" +
                        " FROM USER_VIDEOGAME WHERE UserId=@id";

                    cmd.Parameters.AddWithValue("id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return new User_VideoGame
                            {
                                User_VideoGame_id = (int)reader["User_VideoGame_id"],
                                UserId = (int)reader["UserId"],
                                VideoGameId = (int)reader["VideoGameId"]
                            };
                        }
                    }
                }
            }
        }



        public IEnumerable<VideoGame> GetVideoGameByUserId(int id)
        {
            using (_connection)
            {
                _connection.Open();

                using (SqlCommand cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT vg.VideoGameId, vg.Name, vg.[Description]," +
                        " vg.ReleaseDate, vg.DeveloperId, vg.PublisherId, vg.JacketUrl" +
                        " FROM USER_VIDEOGAME uv JOIN VIDEOGAME vg" +
                        " ON uv.VideoGameId = vg.VideoGameId WHERE uv.UserId = @id";

                    cmd.Parameters.AddWithValue("id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
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

        //public User_VideoGame GetByUserId(int id)
        //{
        //    User_VideoGame user_VideoGame = new User_VideoGame();

        //    using (_connection)
        //    {
        //        _connection.Open();

        //        using (SqlCommand cmd = _connection.CreateCommand())
        //        {
        //            //cmd.CommandText = "SELECT u.UserId, u.UserName, vg.Name, pl.PlateformName" +
        //            //    " FROM [USER] u JOIN USER_VIDEOGAME uv ON u.UserId = uv.UserId" +
        //            //    " JOIN PLATEFORM_VIDEOGAME plvg ON uv.Plateform_VideoGameId = plvg.Id JOIN" +
        //            //    " PLATEFORM pl ON PlVg.PlateformId = pl.PlateformId" +
        //            //    " JOIN VIDEOGAME vg ON plvg.VideoGameId = vg.VideoGameId WHERE u.UserId = @id";

        //            cmd.CommandText = "SELECT UserId, User_VideoGame_id, Plateform_VideoGameId FROM USER_VIDEOGAME WHERE User_VideoGame_id=@id";

        //            cmd.Parameters.AddWithValue("id", id);

        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    user_VideoGame.User_VideoGame_id = (int)reader["User_VideoGame_id"];
        //                    user_VideoGame.UserId = (int)reader["UserId"];
        //                    user_VideoGame.Plateform_VideoGame_Id = (int)reader["Plateform_VideoGameId"];
        //                    //user_VideoGame.UserName = (string)reader["UserName"];
        //                    //user_VideoGame.VideoGameName = (string)reader["Name"];
        //                    //user_VideoGame.PlateformName = (string)reader["PlateformName"];
        //                    //user_VideoGame.videoGamesList.Add(reader.GetString("Name"));
        //                    //user_VideoGame.PlateformList.Add(reader.GetString("PlateformName"));
        //                }

        //                return user_VideoGame;
        //            }
        //        }
        //    }
        //}

        public void Insert(User_VideoGame user_VideoGame)
        {
            using (_connection)
            {
                _connection.Open();

                using (SqlCommand cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = " INSERT INTO USER_VIDEOGAME (UserId, VideoGameId)" +
                        " OUTPUT inserted.User_VideoGame_id VALUES (@UId, @VgId)";

                    cmd.Parameters.AddWithValue("UId", user_VideoGame.UserId);
                    cmd.Parameters.AddWithValue("VgId", user_VideoGame.VideoGameId);


                    int id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Update(User_VideoGame user_VideoGame)
        {
            using (_connection)
            {
                _connection.Open();

                using (SqlCommand cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE USER_VIDEOGAME SET UserId = @UId," +
                        " Plateform_VideoGameId = @VgId" +
                        " WHERE User_VideoGame_id = @id";

                    cmd.Parameters.AddWithValue("UId", user_VideoGame.UserId);
                    cmd.Parameters.AddWithValue("VgId", user_VideoGame.VideoGameId);
                    cmd.Parameters.AddWithValue("id", user_VideoGame.User_VideoGame_id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int UserId, int VideoGameId)
        {
            using (_connection)
            {
                _connection.Open();

                using (SqlCommand cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = "delete from USER_VIDEOGAME WHERE UserId =@userId and VideoGameId=@videoGameId";

                    cmd.Parameters.AddWithValue("userId", UserId);
                    cmd.Parameters.AddWithValue("videoGameId", VideoGameId);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
