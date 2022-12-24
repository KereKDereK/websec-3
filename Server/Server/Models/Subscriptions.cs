using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Server.Models
{
    public class Subscriptions
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public int SecondUserId { get; set; }
        [JsonIgnore]
        public User SecondUser { get; set; }
    }
}
