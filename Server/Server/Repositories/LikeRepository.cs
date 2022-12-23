using System;
using System.Collections.Generic;
using System.Linq;
using Server.Models;

namespace Server.Repositories
{
    public class LikeRepository: ILikeRepository
    {
        public List<Like> GetAllLikes(string cookie)
        {
            List<Like> likes;
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                likes = db.Likes.ToList();
            }
            return likes;
        }

        public Like GetLike(int id, string cookie)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var like = db.Likes.Find(id);
                return like;
            }
        }

        public int AddLike(Like like, string cookie)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var likes = db.Likes.ToList();
                foreach (Like l in likes)
                    if (l.UserId == like.UserId && l.PostId == like.PostId)
                        return -1;
                db.Likes.Add(like);
                var change = db.Posts.ToList().Where(p => p.Id == like.PostId).SingleOrDefault();
                change.Likes_Count = change.Likes_Count + 1;
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

        public int DeleteLike(int id, string cookie)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var like = db.Likes.ToList().Where(x => x.Id == id).SingleOrDefault();
                db.Likes.Remove(like);
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
    }
}
