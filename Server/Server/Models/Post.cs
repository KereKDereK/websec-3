

using System;

namespace Server.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public int LikeCount { get; set; }
        public Post(int postId, string text, int userId, DateTime date, int likeCount)
        {
            PostId = postId;
            Text = text;
            UserId = userId;
            Date = date;
            LikeCount = likeCount;
        }


    }
}
