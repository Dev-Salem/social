using Microsoft.EntityFrameworkCore;
using social.Models;

namespace social.Data
{
    public class ApplicationDBContext(DbContextOptions dbContextOptions)
        : DbContext(dbContextOptions)
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Vote> Votes { get; set; }
    }
}
