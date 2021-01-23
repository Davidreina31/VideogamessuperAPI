using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DAL.Interface;
using DAL.Models;
using Microsoft.Extensions.Configuration;

namespace DAL.Repository
{
    public class CommentRepository : BaseRepository, ICommentRepository
    {
        public CommentRepository(IConfiguration config) : base(config)
        {

        }


        public IEnumerable<Comment> GetByVideoGameId(int id)
        {
            using (_connection)
            {
                _connection.Open();

                using (SqlCommand cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT CommentId, Note, CommentText, CommentDate," +
                        " UserId, VideoGameId FROM COMMENT WHERE VideoGameId=@id"; 

                    cmd.Parameters.AddWithValue("id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return new Comment
                            {
                                CommentId = (int) reader["CommentId"],
                                Note = (int) reader["Note"],
                                CommentText = (string) reader["CommentText"],
                                CommentDate = (DateTime) reader["CommentDate"],
                                UserId = (int) reader["UserId"],
                                VideoGameId = (int) reader ["VideoGameId"],
                                
                            };
                        }
                    }
                }
            }
        }

        public Comment GetOne(int id)
        {
            Comment comment = new Comment();
            using (_connection)
            {
                _connection.Open();

                using(SqlCommand cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT CommentId, Note, CommentText, CommentDate," +
                        " UserId, VideoGameId FROM COMMENT WHERE CommentId=@id";

                    cmd.Parameters.AddWithValue("id", id);

                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comment.CommentId = (int)reader["CommentId"];
                            comment.Note = (int)reader["Note"];
                            comment.CommentText = (string)reader["CommentText"];
                            comment.CommentDate = (DateTime)reader["CommentDate"];
                            comment.UserId = (int)reader["UserId"];
                            comment.VideoGameId = (int)reader["VideoGameId"];
                        }

                        return comment;
                    }
                }
            }
        }


        public void Insert(Comment comment)
        {
            using (_connection)
            {
                _connection.Open();

                using (SqlCommand cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO COMMENT (Note, CommentText, CommentDate," +
                        " UserId, VideoGameId) OUTPUT" +
                        " inserted.CommentId VALUES (@note, @text, @date, @UId, @VgId)";

                    cmd.Parameters.AddWithValue("note", comment.Note);
                    cmd.Parameters.AddWithValue("text", comment.CommentText);
                    cmd.Parameters.AddWithValue("date", DateTime.Now);
                    cmd.Parameters.AddWithValue("UId", comment.UserId);
                    cmd.Parameters.AddWithValue("VgId", comment.VideoGameId);

                    int id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Update(Comment comment)
        {
            using (_connection)
            {
                _connection.Open();

                using (SqlCommand cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE COMMENT SET Note=@note, CommentText=@text," +
                        " CommentDate=@date, UserId=@UId, VideoGameId=@VgId" +
                        " WHERE CommentId=@id";

                    cmd.Parameters.AddWithValue("note", comment.Note);
                    cmd.Parameters.AddWithValue("text", comment.CommentText);
                    cmd.Parameters.AddWithValue("date", DateTime.Now);
                    cmd.Parameters.AddWithValue("UId", comment.UserId);
                    cmd.Parameters.AddWithValue("VgId", comment.VideoGameId);
                    cmd.Parameters.AddWithValue("id", comment.CommentId);

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
                    cmd.CommandText = "DELETE FROM REPORT WHERE CommentId=@id ";
                    cmd.CommandText += "DELETE FROM COMMENT WHERE CommentId=@id";

                    cmd.Parameters.AddWithValue("id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
