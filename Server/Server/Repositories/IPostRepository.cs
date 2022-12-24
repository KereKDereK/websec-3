using Server.Models;
using System.Collections.Generic;

namespace Server.Repositories
{
    public interface IPostRepository
    {
        public int AddPost(Post post, string cookie);
        public int UpdatePost(int id, Post newPost, string cookie);
        public int DeletePost(int id, string cookie);
        //public int DeleteAllUsers();
        Post GetPost(int id, string cookie);
        public List<User> GetAllPosts(string cookie);
        public int CountLikes(int id, string cookie);
        public List<Comment> GetPostComments(int id, string cookie);

    }
}
