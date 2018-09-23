using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using FightCore.Data.Configurations;
using FightCore.Models;
using FightCore.Models.Characters;
using FightCore.Models.PlayerStatistics;
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
        public DbSet<ControllerInput> ControllerInputs { get; set; }
        #region Characters
        public DbSet<Character> Characters { get; set; }
        public DbSet<Technique> Techniques { get; set; }
                public DbSet<Combo> Combos { get; set; }
        public DbSet<Move> Moves { get; set; }
        #endregion
        #region PlayerStatistics
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<SetGame> SetGames { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Character>().HasMany<Combo>(x => x.Combos).WithOne(x => x.Character);
            builder.Entity<Combo>().HasMany<Character>(x => x.WorksOn);
            builder.Entity<InputChain>().HasOne(x => x.Technique).WithMany();
            builder.Entity<InputChain>().HasOne(x => x.Input).WithMany();
            builder.Entity<InputChain>().HasOne(x => x.Move).WithMany();

            builder.Entity<Set>().HasOne(x => x.Player1).WithMany(x => x.Sets).HasForeignKey(x => x.Player1Id);
            builder.Entity<Set>().HasOne(x => x.Player2).WithMany(x => x.Sets).HasForeignKey(x => x.Player2Id);
            builder.Entity<Set>().HasMany(x => x.Games).WithOne(x => x.Set);

            builder.Entity<SetGame>().HasOne(x => x.Character1).WithMany(x => x.Games).HasForeignKey(x => x.Character1Id);
            builder.Entity<SetGame>().HasOne(x => x.Character2).WithMany(x => x.Games).HasForeignKey(x => x.Character2Id);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ApplicationUserConfiguration());
        }
    }
}
