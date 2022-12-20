using System.ComponentModel.DataAnnotations;
using System;

namespace Server.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } 
        public int PostId { get; set; }
        public Post Post { get; set; }
        public DateTime Datetime { get; set; }
        
    }
}
