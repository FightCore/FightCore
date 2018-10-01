using System;
using System.Collections.Generic;
using System.Text;
using FightCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FightCore.Data.Configurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public static Game Smash4 => new Game
        {
            Id = 1,
            Abbreviation = "SSB4",
            Name = "Super Smash Bros For WiiU"
        };
        public static Game Brawl => new Game
        {
            Id = 2,
            Abbreviation = "SSBB",
            Name = "Super Smash Bros Brawl"
        };
        public static Game Melee => new Game
        {
            Id = 3,
            Abbreviation = "SSBM",
            Name = "Super Smash Bros Melee"
        };
        public static Game Smash64 => new Game
        {
            Id = 4,
            Abbreviation = "SBB",
            Name = "Super Smash Bros"
        };
        public void Configure(EntityTypeBuilder<Game> builder)
        {

            builder.HasData(Smash4, Brawl, Melee, Smash64);
        }
    }
}
