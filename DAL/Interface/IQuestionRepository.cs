using System;
using System.Collections.Generic;
using DAL.Models;

namespace DAL.Interface
{
    public interface IQuestionRepository
    {
        //Question GetOne(int id);

        IEnumerable<Question> Get(int id);

        User GetUser(int id);

        void Insert(Question question);

        void Delete(int id);
    }
}
