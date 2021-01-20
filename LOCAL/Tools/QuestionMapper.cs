using System;
namespace LOCAL.Tools
{
    public static class QuestionMapper
    {
        public static LOCAL.Models.Question toLocal(this DAL.Models.Question question)
        {
            return new LOCAL.Models.Question
            {
                QuestionId = question.QuestionId,
                QuestionText = question.QuestionText,
                QuestionDate = question.QuestionDate,
                UserId = question.UserId,
                Plateform_VideoGameId = question.Plateform_VideoGameId
            };
        }

        public static DAL.Models.Question toDal(this LOCAL.Models.Question question)
        {
            return new DAL.Models.Question
            {
                QuestionId = question.QuestionId,
                QuestionText = question.QuestionText,
                QuestionDate = question.QuestionDate,
                UserId = question.UserId,
                Plateform_VideoGameId = question.Plateform_VideoGameId

            };
        }
    }
}
