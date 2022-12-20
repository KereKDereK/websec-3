using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Server.Repositories
{
    public class PostRepository: IPostRepository
    {
        public List<Post> GetAllPosts()
        {
            List<Post> posts;
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                posts = db.Posts.ToList();
            }
            return posts;
        }

        public Post GetPost(int id)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var post = db.Posts.ToList().Where(x => x.Id == id);
                if (post.Count() == 0)
                    throw new Exception("No element with such ID");
                return (Post)post;
            }
        }

        public int AddPost(Post post)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                db.Posts.Add(post);
                try
                {
                    db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }
            return 1;
        }

        public int UpdatePost(int id, Post newPost)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var post = (Post)db.Posts.ToList().Where(x => x.Id == id);
                post.Text = newPost.Text;
                post.LikeCount = newPost.LikeCount;
                post.Date = newPost.Date;
                try
                {
                    db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }
            return 1;
        }

        public int DeletePost(int id)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var post = (Post)db.Posts.ToList().Where(x => x.Id == id);
                db.Posts.Remove(post);
                try
                {
                    db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }
            return 1;
        }
        public int CountLikes(int id)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var post = (Post)db.Posts.Include(x => x.Likes).ToList().Where(x => x.Id == id);
                return post.Likes.Count;
            }
        }

        public List<Comment> GetPostComments(int id)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var post = (Post)db.Posts.Include(x => x.Comments).ToList().Where(x => x.Id == id);
                return post.Comments;
            }
        }

    }
}
