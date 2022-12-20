using Server.Models;
using System.Collections.Generic;

namespace Server.Repositories
{
    public interface IPostRepository
    {
        public int AddPost(Post post);
        public int UpdatePost(int id, Post newPost);
        public int DeletePost(int id);
        //public int DeleteAllUsers();
        Post GetPost(int id);
        public List<Post> GetAllPosts();
        public int CountLikes(int id);
        public List<Comment> GetPostComments(int id);

    }
}
