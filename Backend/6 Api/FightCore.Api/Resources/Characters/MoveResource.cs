using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FightCore.Api.Resources.Shared;

namespace FightCore.Api.Resources.Characters
{
    public class MoveResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ControllerInputResource Input { get; set; }
        public List<MediaResource> Media { get; set; }
    }
}
