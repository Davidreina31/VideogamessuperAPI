﻿using System;
namespace LOCAL.Models
{
    public class Comment
    {
        public int CommentId { get; set; }

        public int Note { get; set; }

        public string CommentText { get; set; }

        public DateTime CommentDate { get; set; }

        public int UserId { get; set; }

        public int Plateform_VideoGameId { get; set; }

    }
}