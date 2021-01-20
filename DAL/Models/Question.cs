using System;
namespace DAL.Models
{
    public class Question
    {
        public int QuestionId { get; set; }

        public string QuestionText { get; set; }

        public DateTime QuestionDate { get; set; }

        public int UserId { get; set; }

        public int Plateform_VideoGameId { get; set; }

       

    }
}
