using System;
using System.Collections.Generic;
using FightCore.Models.Characters;
using FightCore.Models.PlayerStatistics;

namespace FightCore.Models.PlayerStatistics {
    public class SetGame : IEntity {
        public int Id { get; set; }
        public Set Set { get; set; }
        public int? Character1Id { get; set; }
        public Character Character1 { get; set; }
        public int? Character2Id { get; set; }
        public Character Character2 { get; set; }
        public int? Stocks1 { get; set; }
        public int? Stocks2 { get; set; }
        public int? StageId { get; set; }
        public int Winner { get; set;}
        public int Loser { get; set; }
    }
}