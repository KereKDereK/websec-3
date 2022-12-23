using Server.Models;
using System.Collections.Generic;

namespace Server.Repositories
{
    public interface ICommentRepository
    {
        public int AddComment(Comment comment, string cookie);
        public int UpdateComment(int id, Comment newComment, string cookie);
        public int DeleteComment(int id, string cookie);
        //public int DeleteAllUsers();
        Comment GetComment(int id, string cookie);
        public List<Comment> GetAllComments(string cookie);
    }
}
