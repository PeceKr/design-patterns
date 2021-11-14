using DesignPatterns.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.Repository.Infrastructure
{
    public class PostsDbContext : DbContext
    {
        public PostsDbContext(DbContextOptions<PostsDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }
    }
}
