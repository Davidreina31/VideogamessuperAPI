using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interface;
using LOCAL.Interface;
using LOCAL.Models;
using LOCAL.Tools;

namespace LOCAL.Services
{
    public class QuestionService : IQuestionService
    {
        private IQuestionRepository _questionRepo;
        private IAnswerService _answerService;

        public QuestionService(IQuestionRepository questionRepo, IAnswerService answerService)
        {
            _questionRepo = questionRepo;
            _answerService = answerService;
        }


        //public Question GetOne(int id)
        //{
        //    return _questionRepo.GetOne(id).toLocal();
        //}

        public IEnumerable<Question> GetByVideoGameId(int id)
        {
            IEnumerable<Question> questions;
            questions = _questionRepo.GetByVideoGameId(id).Select(x => x.toLocal());

            //foreach (Question q in questions)
            //{
            //    //q.User = _questionRepo.GetUser(q.QuestionId).toLocal();
            //    q.User = _userService.Get(q.UserId);
            //}
            return questions;
             
        }

        public Question GetAnswersByQuestionId(int id)
        {
            Question question = new Question();

            question = _questionRepo.GetOne(id).toLocal();
            question.AnswersList = _answerService.GetByQuestionId(id);

            return question;
        }

        public void Insert(Question question)
        {
            _questionRepo.Insert(question.toDal());
        }

        public void Delete(int id)
        {
            _questionRepo.Delete(id);
        }

        
    }
}
