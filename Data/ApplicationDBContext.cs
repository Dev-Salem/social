using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using social.Models;

namespace social.Data
{
    public class ApplicationDBContext(DbContextOptions dbContextOptions)
        : IdentityDbContext(dbContextOptions)
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<AppUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            List<IdentityRole> roles =
            [
                new IdentityRole() { Name = "User", NormalizedName = "USER" },
                new IdentityRole() { Name = "Admin", NormalizedName = "ADMIN" },
            ];
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
