using System;
namespace DAL.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }

        public string AnswerText { get; set; }

        public DateTime AnswerDate { get; set; }

        public int UserId { get; set; }

        public int QuestionId { get; set; }
    }
}
