using FightCore.Data.Configurations;
using FightCore.Models;
using FightCore.Models.Resources;
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

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Post>().HasOne(x => x.Author).WithMany().HasForeignKey(x => x.AuthorId);
#if DEBUG
            builder.ApplyConfiguration(new ApplicationUserConfiguration());
#endif
            builder.ApplyConfiguration(new UserCharacterConfiguration());
            builder.ApplyConfiguration(new UserGameConfiguration());

            #region Character

            builder.ApplyConfiguration(new CharacterConfiguration());
            builder.ApplyConfiguration(new TechniqueConfiguration());
            builder.ApplyConfiguration(new ComboConfiguration());
            builder.ApplyConfiguration(new MoveConfiguration());

            #endregion

            #region Shared

            builder.ApplyConfiguration(new GameConfiguration());
            builder.ApplyConfiguration(new InputChainConfiguration());

            #endregion
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Notification> Notifications { get; set; }
    }
}
