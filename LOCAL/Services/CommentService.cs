using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interface;
using LOCAL.Interface;
using LOCAL.Models;
using LOCAL.Tools;

namespace LOCAL.Services
{
    public class CommentService : ICommentService
    {
        private ICommentRepository _commentRepo;

        public CommentService(ICommentRepository commentRepo)
        {
            _commentRepo = commentRepo;
        }

        public IEnumerable<Comment> Get(int id)
        {
            return _commentRepo.Get(id).Select(x => x.toLocal());
        }

        public void Insert(Comment comment)
        {
            _commentRepo.Insert(comment.toDal());
        }

        public void Update(Comment comment)
        {
            _commentRepo.Update(comment.toDal());
        }

        public void Delete(int id)
        {
            _commentRepo.Delete(id);
        }
    }
}
