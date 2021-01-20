using System;
namespace LOCAL.Tools
{
    public static class CommentMapper
    {
        public static LOCAL.Models.Comment toLocal(this DAL.Models.Comment comment)
        {
            return new LOCAL.Models.Comment
            {
                CommentId = comment.CommentId,
                Note = comment.Note,
                CommentText = comment.CommentText,
                CommentDate = comment.CommentDate,
                UserId = comment.UserId,
                Plateform_VideoGameId = comment.Plateform_VideoGameId
            };
        }

        public static DAL.Models.Comment toDal(this LOCAL.Models.Comment comment)
        {
            return new DAL.Models.Comment
            {
                CommentId = comment.CommentId,
                Note = comment.Note,
                CommentText = comment.CommentText,
                CommentDate = comment.CommentDate,
                UserId = comment.UserId,
                Plateform_VideoGameId = comment.Plateform_VideoGameId

            };
        }
    }
}
