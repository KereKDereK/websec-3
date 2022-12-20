using Server.Models;
using System.Collections.Generic;

namespace Server.Repositories
{
    public interface ICommentRepository
    {
        public int AddComment(Comment comment);
        public int UpdateComment(int id, Comment newComment);
        public int DeleteComment(int id);
        //public int DeleteAllUsers();
        Comment GetComment(int id);
        public List<Comment> GetAllComments();
    }
}
