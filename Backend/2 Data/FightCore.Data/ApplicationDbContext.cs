using System;
using System.Collections.Generic;
using System.Text;
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<UserResource>().HasOne(x => x.Author).WithMany().HasForeignKey(x => x.AuthorId);
            builder.ApplyConfiguration(new ApplicationUserConfiguration());
        }

        public DbSet<UserResource> Resources { get; set; }
    }
}
