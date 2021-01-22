﻿using System;
using System.Collections.Generic;

namespace LOCAL.Models
{
    public class Question
    {
        public int QuestionId { get; set; }

        public string QuestionText { get; set; }

        public DateTime QuestionDate { get; set; }

        public int UserId { get; set; }

        public int VideoGameId { get; set; }

    }
}
