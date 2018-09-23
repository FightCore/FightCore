using System;
using System.Collections.Generic;
using FightCore.Models;
using FightCore.Models.Shared;
namespace FightCore.Models.PlayerStatistics {
    public class Tournament : IEntity {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        /// <summary>
        /// Stores the smash.gg url if the tournament was pulled off smash.gg
        /// </summary>
        /// <value>The url of the tournament or NULL if not from smash.gg</value>
        public string SmashggUrl { get; set; }
        public List<Media> Medias { get; set; }
    }
}