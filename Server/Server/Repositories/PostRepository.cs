using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Server.Repositories;

namespace Server.Repositories
{
    public class PostRepository: IPostRepository
    {
        public List<Post> GetAllPosts(int id, string cookie)
        {
            List<Post> posts = new List<Post>();
            List<User> userList = new List<User>();
            User tmp = new User();
            List<User> users = new List<User>();
            try
            {
                using (Models.ApplicationContext db = new Models.ApplicationContext())
                {
                    try
                    {
                    if (db.Users.ToList().Where(x => x.PasswordHash == cookie).Count() <= 0)
                        throw new Exception("ex");
                    var userPosts = db.Users.Include(u => u.Subber).ToList().Where(x => x.PasswordHash == cookie).SingleOrDefault();
                    foreach (Subscriptions s in userPosts.Subber)
                        userList.Add(db.Users.ToList().Where(u => u.Id == s.SecondUserId).SingleOrDefault());
                    foreach (User u in userList)
                    {
                        tmp = db.Users.Include(us => us.Posts).ToList().Where(us => us.Id == u.Id).SingleOrDefault();
                        foreach (Post p in tmp.Posts)
                        {
                            posts.Add(db.Posts.Include(ps => ps.Comments).Include(ps => ps.Likes).Include(ps => ps.Image).ToList().Where(ps => ps.Id == p.Id).SingleOrDefault());
                        }
                    }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception();
                    }
                }
            }
            catch (Exception ex)
            {
                return new List<Post>();
            }
            return posts;
        }

        public List<Post> GetPost(int id, string cookie)
        {
            List<Post> abo = new List<Post>();
            try
            {
                var checker = new User();
                using (Models.ApplicationContext db = new Models.ApplicationContext())
                {
                    try
                    {
                        checker = db.Users.ToList().Where(x => x.PasswordHash == cookie).SingleOrDefault();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("ex");
                    }
                }
                List<Post> posts = new List<Post>();
                using (Models.ApplicationContext db = new Models.ApplicationContext())
                {
                    try
                    {
                        var user = db.Users.Include(u => u.Posts).Include(u => u.Sub).ToList().Where(u => u.Id == id).SingleOrDefault();
                        if (user == null)
                            return new List<Post>();
                        var tmp = user.Posts;
                        foreach (Post p in tmp)
                            posts.Add(db.Posts.Include(ps => ps.Comments).Include(ps => ps.Likes).Include(ps => ps.Image).ToList().Where(ps => ps.Id == p.Id).SingleOrDefault());

                        user.PasswordHash = "secret";
                        user.Posts = posts;
                        return new List<Post> (user.Posts);
                    }
                    catch (Exception ex)
                    {
                        return new List<Post>();
                    }
                }
            }
            catch (Exception ex)
            {
                return new List<Post>();
            }
        }

        public int AddPost(Post post, string cookie)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                
                try
                {
                    post.Name = db.Users.Find(post.UserId).UserName;
                    db.Posts.Add(post);
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
