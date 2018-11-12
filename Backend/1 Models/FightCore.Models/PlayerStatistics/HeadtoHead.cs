using System.Collections.Generic;

namespace FightCore.Models.PlayerStatistics
{
    public class HeadToHead
    {
        public HeadToHeadPlayer Player1 { get; set; }
        public HeadToHeadPlayer Player2 { get; set; }
        public List<Set> Sets { get; set; }

    }
}
