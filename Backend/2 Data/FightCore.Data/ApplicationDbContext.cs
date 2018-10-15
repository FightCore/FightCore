using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using FightCore.Data.Configurations;
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
        public DbSet<Combo> Combos { get; set; }
        public DbSet<Move> Moves { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Character>().HasMany<Combo>(x => x.Combos).WithOne(x => x.Character);
            builder.Entity<Character>().HasOne(x => x.Game).WithOne().HasForeignKey<Character>(x => x.GameId);
            builder.Entity<Character>().HasMany(x => x.Techniques).WithOne(x => x.Character)
                .HasForeignKey(x => x.CharacterId);

            builder.Entity<Combo>().HasMany<Character>(x => x.WorksOn);

            builder.Entity<InputChain>().HasOne(x => x.Technique).WithMany();
            builder.Entity<InputChain>().HasOne(x => x.Input).WithMany();
            builder.Entity<InputChain>().HasOne(x => x.Move).WithMany();


            builder.Entity<Technique>().HasMany(x => x.Characters).WithOne(x => x.Technique)
                .HasForeignKey(x => x.TechniqueId);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ApplicationUserConfiguration());
            builder.ApplyConfiguration(new GameConfiguration());
            builder.ApplyConfiguration(new CharacterConfiguration());
        }
    }
}
