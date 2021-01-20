using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interface;
using LOCAL.Interface;
using LOCAL.Models;
using LOCAL.Tools;

namespace LOCAL.Services
{
    public class AnswerService : IAnswerService
    {
        private IAnswerRepository _answerRepo;

        public AnswerService(IAnswerRepository answerRepo)
        {
            _answerRepo = answerRepo;
        }

        public IEnumerable<Answer> Get(int id)
        {
            return _answerRepo.Get(id).Select(x => x.toLocal());
        }

        public void Insert(Answer answer)
        {
            _answerRepo.Insert(answer.toDal());
        }

        public void Update(Answer answer)
        {
            _answerRepo.Update(answer.toDal());
        }

        public void Delete(int id)
        {
            _answerRepo.Delete(id);
        }
    }
}
