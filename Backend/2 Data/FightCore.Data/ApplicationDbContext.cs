using System;
using System.Collections.Generic;
using System.Text;
using FightCore.Models;
using FightCore.Models.Characters;
using FightCore.Models.Shared;
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
        public DbSet<Game> Games { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Technique> Techniques { get; set; }
        public DbSet<ControllerInput> ControllerInputs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
