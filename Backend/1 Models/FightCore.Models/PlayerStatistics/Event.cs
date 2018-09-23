using System;
using System.Collections.Generic;
using FightCore.Models;
using FightCore.Models.Shared;
namespace FightCore.Models.PlayerStatistics {
    public class Event : IEntity {
        public int Id { get; set; }
        public string EventName { get; set; }
        public List<Media> Media { get; set; }
    }
}