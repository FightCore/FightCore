using System;
using System.Collections.Generic;
using System.Text;

namespace FightCore.Models.PlayerStatistics
{
    public class WinLossRecord
    {
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Total { get; set; }
        public List<SetGame> Games { get; set; }

    }
}
