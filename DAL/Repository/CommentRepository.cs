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
                    cmd.CommandText = "SELECT c.CommentId, c.Note, c.CommentText," +
                        " c.CommentDate, c.UserId, c.Plateform_VideoGameId, vg.VideoGameId," +
                        "vg.Name FROM COMMENT c JOIN PLATEFORM_VIDEOGAME pl " +
                        "ON c.Plateform_VideoGameId = pl.Id JOIN VIDEOGAME vg " +
                        "ON pl.VideoGameId = vg.VideoGameId WHERE vg.VideoGameId=@id";

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
                                Plateform_VideoGameId = (int) reader ["Plateform_VideoGameId"],
                                
                            };
                        }
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
                        " UserId, Plateform_VideoGameId) OUTPUT" +
                        " inserted.CommentId VALUES (@note, @text, @date, @UId, @PlVgId)";

                    cmd.Parameters.AddWithValue("note", comment.Note);
                    cmd.Parameters.AddWithValue("text", comment.CommentText);
                    cmd.Parameters.AddWithValue("date", DateTime.Now);
                    cmd.Parameters.AddWithValue("UId", comment.UserId);
                    cmd.Parameters.AddWithValue("PlVgId", comment.Plateform_VideoGameId);

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
                        " CommentDate=@date, UserId=@UId, Plateform_VideoGameId=@PlVgId" +
                        " WHERE CommentId=@id";

                    cmd.Parameters.AddWithValue("note", comment.Note);
                    cmd.Parameters.AddWithValue("text", comment.CommentText);
                    cmd.Parameters.AddWithValue("date", DateTime.Now);
                    cmd.Parameters.AddWithValue("UId", comment.UserId);
                    cmd.Parameters.AddWithValue("PlVgId", comment.Plateform_VideoGameId);
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
                    cmd.CommandText = "DELETE FROM COMMENT WHERE CommentId=@id";

                    cmd.Parameters.AddWithValue("id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
