using System;
using System.Collections.Generic;
using DAL.Models;

namespace DAL.Interface
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> Get(int id);

        void Insert(Comment comment);

        void Update(Comment comment);

        void Delete(int id);
    }
}
