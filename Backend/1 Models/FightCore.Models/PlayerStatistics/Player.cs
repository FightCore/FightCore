using System;
using System.Collections.Generic;
using FightCore.Models;
using FightCore.Models.Characters;
using FightCore.Models.Shared;
namespace FightCore.Models.PlayerStatistics
{
    public class Player : IEntity
    {
        public int Id { get; set; }
        public string Sponsor { get; set; }
        public string Name { get; set; }
        public string DisplayName => $"{Sponsor} | {Name}";
        /// <summary>
        /// A player doesn't nessesairly have to have a smash.gg Id to exist.
        /// </summary>
        /// <value>An int representing the smash.gg Id or NULL when the player doesn't have one</value>
        public int? SmashggId { get; set; }
        public List<Media> Media { get; set; }
        public List<Set> Sets { get; set; }
    }
}
