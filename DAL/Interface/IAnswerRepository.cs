using System;
using System.Collections.Generic;
using DAL.Models;

namespace DAL.Interface
{
    public interface IAnswerRepository
    {
        IEnumerable<Answer> GetByQuestionId(int id);

        void Insert(Answer answer);

        void Update(Answer answer);

        void Delete(int id);
    }
}
