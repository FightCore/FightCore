using System;
using System.Collections.Generic;
using System.Text;
using FightCore.Models.Characters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FightCore.Data.Configurations
{
    public class CharacterConfiguration : IEntityTypeConfiguration<Character>
    {
        public void Configure(EntityTypeBuilder<Character> builder)
        {
            #region Seed

            var mario4 = new Character
                             {
                                 Id = 1,
                                 Description = "The all-star",
                                 Name = "Mario",
                                 GameId = 1
                             };
            var mariob = new Character
                             {
                                 Id = 2,
                                 Description = "The all-star",
                                 Name = "Mario",
                                 GameId = 2
                             };
            var mariom = new Character
                             {
                                 Id = 3,
                                 Description = "The all-star",
                                 Name = "Mario",
                                 GameId = 3
                             };
            var mario64 = new Character
                              {
                                  Id = 4,
                                  Description = "The all-star",
                                  Name = "Mario",
                                  GameId = 4
                              };

            builder.HasData(mario4, mariob, mariom, mario64);

            #endregion

            #region Relationships

            builder.HasMany(x => x.Combos).WithOne(x => x.Character).HasForeignKey(x => x.CharacterId);
            builder.HasMany(x => x.Techniques).WithOne(x => x.Character).HasForeignKey(x => x.CharacterId);
            builder.HasMany(x => x.Moves).WithOne(x => x.Character);
            builder.HasOne(x => x.Game);

            #endregion Relationships
        }
    }
}
