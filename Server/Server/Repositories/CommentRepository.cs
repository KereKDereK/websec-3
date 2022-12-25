using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Repositories
{
    public class CommentRepository : ICommentRepository
    {

        public List<Comment> GetAllComments(string cookie)
        {
            return new List<Comment>();
        }

        public async Task<Comment> GetComment(int id, string cookie)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var comment = await db.Comments.FindAsync(id);
                return comment;
            }
        }

        public async Task<int> AddComment(Comment comment, string cookie)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                try 
                { 
                    var user = db.Users.ToList().Where(u => u.PasswordHash == cookie).SingleOrDefault();
                    comment.Name = user.UserName;
                    comment.UserId = user.Id;
                    comment.Datetime = DateTime.Now;
                    db.Comments.Add(comment);
                    await db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }
            return 1;
        }

        public async Task<int> UpdateComment(int id, Comment newComment, string cookie)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var comment = db.Comments.ToList().Where(x => x.Id == id).SingleOrDefault();
                comment.Text = newComment.Text;
                comment.Datetime = newComment.Datetime;
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

        public async Task<int> DeleteComment(int id, string cookie)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var comment = db.Comments.ToList().Where(x => x.Id == id).SingleOrDefault();
                db.Comments.Remove(comment);
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
