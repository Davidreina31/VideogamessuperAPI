using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DAL.Interface;
using DAL.Models;
using Microsoft.Extensions.Configuration;

namespace DAL.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {

        public UserRepository(IConfiguration config) : base(config)
        {
        }


        public IEnumerable<User> Get()
        {
            List<User> usersList = new List<User>();

            using (_connection)
            {
                _connection.Open();

                using (SqlCommand cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT UserId, UserName, Email, PasswordHash, [Admin]," +
                        " DeletedDate FROM [USER]";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usersList.Add(new User
                            {
                                UserId = (int)reader["UserId"],
                                UserName = (string)reader["UserName"],
                                Email = (string)reader["Email"],
                                PasswordHash = (string)reader["PasswordHash"],
                                Admin = (bool)reader["Admin"],
                                DeletedDate = reader["DeletedDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["DeletedDate"],
                            });
                        }

                        return usersList;
                    }
                }
            }
        }

        public User Get(int id)
        {
            User user = new User();

            using (_connection)
            {
                _connection.Open();

                using (SqlCommand cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT UserId, UserName, Email, PasswordHash, [Admin]," +
                        " DeletedDate FROM [USER] WHERE UserId=@id";

                    cmd.Parameters.AddWithValue("id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            user.UserId = (int)reader["UserId"];
                            user.UserName = (string)reader["UserName"];
                            user.Email = (string)reader["Email"];
                            user.PasswordHash = (string)reader["PasswordHash"];
                            user.Admin = (bool)reader["Admin"];
                            user.DeletedDate = reader["DeletedDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["DeletedDate"];
                            //user.VideoGame.Add(reader.GetInt32("Plateform_VideoGameId"));
                            ////user.VideoGamesList.Add(reader.GetString("Name"));
                        }

                        return user;
                    }
                }
            }
        }

        public void Insert(User user)
        {
            using (_connection)
            {
                _connection.Open();

                using(SqlCommand cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO [USER] (UserName, Email, PasswordHash, [Admin])" +
                        " OUTPUT inserted.UserId VALUES(@UN, @mail, @pwd, @admin)";

                    cmd.Parameters.AddWithValue("UN", user.UserName);
                    cmd.Parameters.AddWithValue("mail", user.Email);
                    cmd.Parameters.AddWithValue("pwd", user.PasswordHash);
                    cmd.Parameters.AddWithValue("admin", user.Admin);

                    int id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Update(User user)
        {
            using (_connection)
            {
                _connection.Open();

                using (SqlCommand cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE [USER] SET UserName=@UN, Email=@mail, PasswordHash=@pwd," +
                        " [Admin]=@admin WHERE UserId=@id";

                    cmd.Parameters.AddWithValue("UN", user.UserName);
                    cmd.Parameters.AddWithValue("mail", user.Email);
                    cmd.Parameters.AddWithValue("pwd", user.PasswordHash);
                    cmd.Parameters.AddWithValue("admin", user.Admin);
                    cmd.Parameters.AddWithValue("id", user.UserId);

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
                    cmd.CommandText = "DELETE FROM [USER] WHERE UserId = @id";

                    cmd.Parameters.AddWithValue("id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        //public void AddVideoGame(User user, VideoGame videoGame, Plateform plateform)
        //{
        //    using (_connection)
        //    {
        //        _connection.Open();

        //        using (SqlCommand cmd = _connection.CreateCommand())
        //        {
        //            cmd.CommandText = "INSERT INTO USER_VIDEOGAME (UserId, VideoGameId, PlateformId)" +
        //                " VALUES (@UId, @VGId, @PId)";

        //            cmd.Parameters.AddWithValue("UId", user.UserId);
        //            cmd.Parameters.AddWithValue("VGId", videoGame.VideoGameId);
        //            cmd.Parameters.AddWithValue("PId", plateform.PlateformId);

        //            cmd.ExecuteScalar();
        //        }
        //    }
        //}
    }
}
