using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DAL.Interface;
using DAL.Models;
using Microsoft.Extensions.Configuration;

namespace DAL.Repository
{
    public class AnswerRepository : BaseRepository, IAnswerRepository
    {
        public AnswerRepository(IConfiguration config) : base(config)
        {

        }


        public IEnumerable<Answer> GetByQuestionId(int id)
        {
            using (_connection)
            {
                _connection.Open();

                using(SqlCommand cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT AnswerId, AnswerText, AnswerDate," +
                        " UserId, QuestionId FROM ANSWER WHERE QuestionId=@id";

                    cmd.Parameters.AddWithValue("id", id);

                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return new Answer
                            {
                                AnswerId = (int)reader["AnswerId"],
                                AnswerText = (string)reader["AnswerText"],
                                AnswerDate = (DateTime)reader["AnswerDate"],
                                UserId = (int) reader["UserId"],
                                QuestionId = (int) reader["QuestionId"]
                            };
                        }
                    }
                }
            }
        }

        public void Insert(Answer answer)
        {
            using (_connection)
            {
                _connection.Open();

                using(SqlCommand cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO ANSWER (AnswerText, AnswerDate, UserId," +
                        " QuestionId) OUTPUT inserted.AnswerId VALUES (@text, @date, @UId, @QId)";

                    cmd.Parameters.AddWithValue("text", answer.AnswerText);
                    cmd.Parameters.AddWithValue("date", DateTime.Now);
                    cmd.Parameters.AddWithValue("UId", answer.UserId);
                    cmd.Parameters.AddWithValue("QId", answer.QuestionId);

                    int id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Update(Answer answer)
        {
            using (_connection)
            {
                _connection.Open();

                using (SqlCommand cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE ANSWER SET AnswerText=@text, AnswerDate=@date," +
                        " UserId=@UId, QuestionId=@QId WHERE AnswerId=@id";

                    cmd.Parameters.AddWithValue("text", answer.AnswerText);
                    cmd.Parameters.AddWithValue("date", DateTime.Now);
                    cmd.Parameters.AddWithValue("UId", answer.UserId);
                    cmd.Parameters.AddWithValue("QId", answer.QuestionId);
                    cmd.Parameters.AddWithValue("id", answer.AnswerId);

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
                    cmd.CommandText = "DELETE FROM ANSWER WHERE AnswerId=@id";

                    cmd.Parameters.AddWithValue("id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
