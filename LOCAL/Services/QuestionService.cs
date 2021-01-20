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
        private IUserService _userService;

        public QuestionService(IQuestionRepository questionRepo, IUserService userService)
        {
            _questionRepo = questionRepo;
            _userService = userService;
        }


        //public Question GetOne(int id)
        //{
        //    return _questionRepo.GetOne(id).toLocal();
        //}

        public IEnumerable<Question> Get(int id)
        {
            IEnumerable<Question> questions;
            questions = _questionRepo.Get(id).Select(x => x.toLocal());

            //foreach (Question q in questions)
            //{
            //    //q.User = _questionRepo.GetUser(q.QuestionId).toLocal();
            //    q.User = _userService.Get(q.UserId);
            //}
            return questions;
             
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
