using System;
using System.Collections.Generic;

namespace LOCAL.Models
{
    public class Question
    {
        public int QuestionId { get; set; }

        public string QuestionText { get; set; }

        public DateTime QuestionDate { get; set; }

        public int UserId { get; set; }

        public int Plateform_VideoGameId { get; set; }

        public User User { get; set; }

        public IEnumerable<Answer> AnswersList { get; set; }

    }
}
