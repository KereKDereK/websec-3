using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace Server.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
        public int LikeCount { get; set; }
        public List<Image> Images { get; set; }
        public List<Like> Likes { get; set; }
        public List<Comment> Comments { get; set; }
        public Post(int postId, string text, int userId, DateTime date, int likeCount)
        {
            Id = postId;
            Text = text;
            UserId = userId;
            Date = date;
            LikeCount = likeCount;
        }

        public Post(string text, int userId, DateTime date, int likeCount)
        {
            Text = text;
            UserId = userId;
            Date = date;
            LikeCount = likeCount;
        }


    }
}
