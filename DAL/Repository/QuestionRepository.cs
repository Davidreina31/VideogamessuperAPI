using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DAL.Interface;
using DAL.Models;
using Microsoft.Extensions.Configuration;

namespace DAL.Repository
{
    public class QuestionRepository : BaseRepository, IQuestionRepository
    {
        public QuestionRepository(IConfiguration config) : base(config)
        {

        }


        //public Question GetOne(int id)
        //{
        //    Question question = new Question();
        //    using (_connection)
        //    {
        //        _connection.Open();

        //        using (SqlCommand cmd = _connection.CreateCommand())
        //        {
        //            cmd.CommandText = "SELECT QuestionId, QuestionText, QuestionDate," +
        //                " UserId, Plateform_VideoGameId FROM QUESTION WHERE QuestionId=@id";

        //            cmd.Parameters.AddWithValue("id", id);

        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    question.QuestionId = (int)reader["QuestionId"];
        //                    question.QuestionText = (string)reader["QuestionText"];
        //                    question.QuestionDate = (DateTime)reader["QuestionDate"];
        //                    question.UserId = (int)reader["UserId"];
        //                    question.Plateform_VideoGameId = (int)reader["Plateform_VideoGameId"];

        //                }
        //                return question;
        //            }
        //        }
        //    }
        //}

        public IEnumerable<Question> GetByVideoGameId(int id)
        {
            using (SqlConnection c = _connection)
            {
                c.Open();

                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "SELECT q.QuestionId, q.QuestionText, q.QuestionDate," +
                        " q.UserId, q.Plateform_VideoGameId FROM QUESTION Q JOIN PLATEFORM_VIDEOGAME PL" +
                        " ON Q.Plateform_VideoGameId = PL.Id JOIN VIDEOGAME VG " +
                        "ON pl.VideoGameId = vg.VideoGameId" +
                        " WHERE vg.VideoGameId=@id";

                    cmd.Parameters.AddWithValue("id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return new Question
                            {
                                QuestionId = (int)reader["QuestionId"],
                                QuestionText = (string)reader["QuestionText"],
                                QuestionDate = (DateTime)reader["QuestionDate"],
                                UserId = (int)reader["UserId"],
                                Plateform_VideoGameId = (int)reader["Plateform_VideoGameId"]
                            };
                        }
                    }
                }
            }

        }

        public Question GetOne(int id)
        {
            Question question = new Question();

            _connection.Open();

            using(SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "SELECT QuestionId, QuestionText, QuestionDate, UserId," +
                    " Plateform_VideoGameId FROM QUESTION WHERE QuestionId=@id";

                cmd.Parameters.AddWithValue("id", id);

                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        question.QuestionId = (int)reader["QuestionId"];
                        question.QuestionText = (string)reader["QuestionText"];
                        question.QuestionDate = (DateTime)reader["QuestionDate"];
                        question.UserId = (int)reader["UserId"];
                        question.Plateform_VideoGameId = (int)reader["Plateform_VideoGameId"];
                    }

                    return question;
                }
            }
        }


        public void Insert(Question question)
        {
            using (_connection)
            {
                _connection.Open();

                using (SqlCommand cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO QUESTION (QuestionText, QuestionDate," +
                        " UserId, Plateform_VideoGameId) OUTPUT inserted.QuestionId" +
                        " VALUES (@text, @date, @UId, @PlVgId)";

                    cmd.Parameters.AddWithValue("text", question.QuestionText);
                    cmd.Parameters.AddWithValue("date", DateTime.Now);
                    cmd.Parameters.AddWithValue("UId", question.UserId);
                    cmd.Parameters.AddWithValue("PlVgId", question.Plateform_VideoGameId);


                    int id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Delete(int id)
        {
            using (_connection)
            {
                _connection.Open();

                using (SqlCommand cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM QUESTION WHERE QuestionId=@id";

                    cmd.Parameters.AddWithValue("id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        

        //public User GetUser(int id)
        //{
        //    User user = new User();

        //    using (SqlConnection c = _connection)
        //    {
        //        c.Open();

        //        using (SqlCommand cmd = c.CreateCommand())
        //        {
        //            cmd.CommandText = "SELECT u.UserId, u.UserName, u.Email," +
        //                " u.PasswordHash, u.Admin, u.DeletedDate FROM QUESTION q" +
        //                " JOIN [USER] u on q.UserId = u.UserId" +
        //                " WHERE q.QuestionId=@id";

        //            cmd.Parameters.AddWithValue("id", id);

        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    user.UserId = (int)reader["UserId"];
        //                    user.UserName = (string)reader["UserName"];
        //                    user.Email = (string)reader["Email"];
        //                    user.PasswordHash = (string)reader["PasswordHash"];
        //                    user.Admin = (bool)reader["Admin"];
        //                    user.DeletedDate = (DateTime)reader["DeletedDate"];
        //                }
        //                return user;
        //            }
        //        }
        //    }
        //}
    }
}
