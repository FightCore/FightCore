using System;
using System.Collections.Generic;
using FightCore.Models;
using FightCore.Models.Characters;
using FightCore.Models.Shared;

namespace FightCore.Models.PlayerStatistics {
    public class Set : IEntity {
        public int Id { get; set; }
        public List<SetGame> Games { get; set; }
        public Tournament Tournament { get; set; }
        public Event Event { get; set; }
        public int Player1Id { get; set; }
        public Player Player1 { get; set; }
        public int Player2Id { get; set; }
        public Player Player2 { get; set; }
        public int Player1Score { get; set; }
        public int Player2Score { get; set; }
        public Player Winner {
            get {
                if (Player1Score == Player2Score)
                    return null;

                if (Player1Score > Player2Score)
                    return Player1;
                return Player2;
            }
        }
        public Player Loser {
            get {
                if (Player1Score == Player2Score)
                    return null;

                if (Player1Score > Player2Score)
                    return Player2;
                return Player1;
            }
        }
    }
}