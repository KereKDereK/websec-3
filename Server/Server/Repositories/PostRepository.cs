using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Server.Repositories
{
    public class PostRepository: IPostRepository
    {
        public List<Post> GetAllPosts(string cookie)
        {
            List<Post> posts;
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                posts = db.Posts.ToList();
            }
            return posts;
        }

        public Post GetPost(int id, string cookie)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var post = db.Posts.Find(id);
                return post;
            }
        }

        public int AddPost(Post post, string cookie)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                if (post.Likes_Count != 0)
                    post.Likes_Count = 0;
                db.Posts.Add(post);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }
            return 1;
        }

        public int UpdatePost(int id, Post newPost, string cookie)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var post = db.Posts.ToList().Where(x => x.Id == id).SingleOrDefault();
                post.Text = newPost.Text;
                post.Likes_Count = newPost.Likes_Count;
                post.Datetime = newPost.Datetime;
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }
            return 1;
        }

        public int DeletePost(int id, string cookie)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var post = db.Posts.ToList().Where(x => x.Id == id).SingleOrDefault();
                db.Posts.Remove(post);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }
            return 1;
        }
        public int CountLikes(int id, string cookie)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var post = db.Posts.Include(x => x.Likes).ToList().Where(x => x.Id == id).SingleOrDefault();
                return post.Likes.Count;
            }
        }

        public List<Comment> GetPostComments(int id, string cookie)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var post = db.Posts.Include(x => x.Comments).ToList().Where(x => x.Id == id).SingleOrDefault();
                return post.Comments;
            }
        }

    }
}
