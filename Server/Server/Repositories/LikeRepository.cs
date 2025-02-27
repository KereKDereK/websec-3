﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<Like> GetLike(int id, string cookie)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var like = await db.Likes.FindAsync(id);
                return like;
            }
        }

        public async Task<int> AddLike(Like like, string cookie)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                like.UserId = db.Users.ToList().Where(u => u.PasswordHash == cookie).SingleOrDefault().Id;
                var likes = db.Likes.ToList();
                foreach (Like l in likes)
                    if (l.UserId == like.UserId && l.PostId == like.PostId)
                        return -1;
                db.Likes.Add(like);
                var change = db.Posts.ToList().Where(p => p.Id == like.PostId).SingleOrDefault();
                change.Likes_Count = change.Likes_Count + 1;
                try
                {
                    await db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }
            return 1;
        }

        public async Task<int> DeleteLike(int id, string cookie)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var userId = db.Users.ToList().Where(u => u.PasswordHash == cookie).SingleOrDefault().Id;
                var post = await db.Posts.FindAsync(id);
                post.Likes_Count = post.Likes_Count - 1;
                var like = db.Likes.ToList().Where(x => x.UserId == userId && x.PostId == id).SingleOrDefault();
                db.Likes.Remove(like);
                try
                {
                    await db.SaveChangesAsync();
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
