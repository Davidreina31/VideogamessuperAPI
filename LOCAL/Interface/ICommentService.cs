using System;
using System.Collections.Generic;
using LOCAL.Models;

namespace LOCAL.Interface
{
    public interface ICommentService
    {
        IEnumerable<Comment> GetByVideoGameId(int id);

        Comment GetOne(int id);

        void Insert(Comment comment);

        void Update(Comment comment);

        void Delete(int id);
    }
}
