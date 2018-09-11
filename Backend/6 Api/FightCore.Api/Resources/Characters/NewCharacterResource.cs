using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FightCore.Api.Resources.Games;

namespace FightCore.Api.Resources.Characters
{
    public class NewCharacterResource
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int GameId { get; set; }
        public GameResource Game { get; set; }
    }
}
