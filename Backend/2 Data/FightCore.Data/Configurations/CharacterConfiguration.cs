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
        }
    }
}
