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
        public DateTime Datetime { get; set; }
        public int Likes_Count { get; set; }
        public List<Image> Images { get; set; }
        public List<Like> Likes { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
