using System.ComponentModel.DataAnnotations;
using System;
using System.Text.Json.Serialization;

namespace Server.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public int PostId { get; set; }
        public DateTime Datetime { get; set; }

        public Comment(string Text, int UserId, int PostId, DateTime Datetime)
        {
            this.Text = Text;
            this.UserId = UserId;
            this.PostId = PostId;
            this.Datetime = Datetime;
        }
        
    }
}
