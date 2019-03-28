using FightCore.Data.Configurations;
using FightCore.Models;
using FightCore.Models.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FightCore.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public ApplicationDbContext() : base()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.UseOpenIddict();

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            //// Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Post>().HasOne(x => x.Author).WithMany().HasForeignKey(x => x.AuthorId);
            builder.ApplyConfiguration(new ApplicationUserConfiguration());
            builder.ApplyConfiguration(new NotificationConfiguration());
            builder.ApplyConfiguration(new UpvotesConfiguration());
        }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<Upvote> Upvotes { get; set; }
    }
}
