using Microsoft.EntityFrameworkCore;
namespace Server.Models

{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<Image> Images { get; set; } = null!;
        public DbSet<Like> Likes { get; set; } = null!;
        public DbSet<Post> Posts { get; set; } = null!;
        public DbSet<Subscriptions> Subscriptions { get; set; } = null!;

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user=student;password=P@ssw0rd;database=stogramm;",
                ServerVersion.AutoDetect("server=localhost;user=student;password=P@ssw0rd;database=stogramm;"));
        }
    }
}
