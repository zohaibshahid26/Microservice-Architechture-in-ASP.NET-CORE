using Microservice_Architechture.Models;
using Microsoft.EntityFrameworkCore;
namespace Microservice_Architechture.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Technology" },
                new Category { CategoryId = 2, Name = "Health" },
                new Category { CategoryId = 3, Name = "Science" }
            );
        }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
