﻿using Microsoft.EntityFrameworkCore;
namespace Server.Models
{   
    public class Like
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}
