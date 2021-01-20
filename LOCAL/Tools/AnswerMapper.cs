using System;
namespace LOCAL.Tools
{
    public static class AnswerMapper
    {
        public static LOCAL.Models.Answer toLocal(this DAL.Models.Answer answer)
        {
            return new LOCAL.Models.Answer
            {
                AnswerId = answer.AnswerId,
                AnswerText = answer.AnswerText,
                AnswerDate = answer.AnswerDate,
                UserId = answer.UserId,
                QuestionId = answer.QuestionId
            };
        }

        public static DAL.Models.Answer toDal(this LOCAL.Models.Answer answer)
        {
            return new DAL.Models.Answer
            {
                AnswerId = answer.AnswerId,
                AnswerText = answer.AnswerText,
                AnswerDate = answer.AnswerDate,
                UserId = answer.UserId,
                QuestionId = answer.QuestionId
            };
        }
    }
}
