using System;
using System.Collections.Generic;
using LOCAL.Models;

namespace LOCAL.Interface
{
    public interface IAnswerService
    {
        IEnumerable<Answer> Get(int id);

        void Insert(Answer answer);

        void Update(Answer answer);

        void Delete(int id);
    }
}
