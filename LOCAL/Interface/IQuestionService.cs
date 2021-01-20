using System;
using System.Collections.Generic;
using LOCAL.Models;

namespace LOCAL.Interface
{
    public interface IQuestionService
    {
        //Question GetOne(int id);

        IEnumerable<Question> Get(int id);

        void Insert(Question question);

        void Delete(int id);
    }
}
