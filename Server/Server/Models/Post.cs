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
        public string Name { get; set; }
        public DateTime Datetime { get; set; }
        public int Likes_Count { get; set; }
        public Image Image { get; set; }
        public List<Like> Likes { get; set; }
        public List<Comment> Comments { get; set; }

        public Post(string Text, int UserId, string Name, DateTime Datetime, int Likes_Count)
        {
            this.Text = Text;
            this.UserId = UserId;
            this.Name = Name;
            this.Datetime = Datetime;
            this.Likes_Count = Likes_Count;
        }
    }
}
