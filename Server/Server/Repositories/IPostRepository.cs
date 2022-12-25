using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Repositories
{
    public interface IPostRepository
    {
        public Task<int> AddPost(Post post, string cookie);
        public Task<int> UpdatePost(int id, Post newPost, string cookie);
        public Task<int> DeletePost(int id, string cookie);
        //public int DeleteAllUsers();
        List<Post> GetPost(int id, string cookie);
        public List<Post> GetAllPosts(int id, string cookie);
        public int CountLikes(int id, string cookie);
        public List<Comment> GetPostComments(int id, string cookie);

    }
}
