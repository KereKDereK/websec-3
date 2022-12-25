using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Repositories
{
    public interface ICommentRepository
    {
        public Task<int> AddComment(Comment comment, string cookie);
        public Task<int> UpdateComment(int id, Comment newComment, string cookie);
        public Task<int> DeleteComment(int id, string cookie);
        //public int DeleteAllUsers();
        Task<Comment> GetComment(int id, string cookie);
        public List<Comment> GetAllComments(string cookie);
    }
}
