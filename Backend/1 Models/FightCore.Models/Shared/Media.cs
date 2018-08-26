using System;
using System.Collections.Generic;
using System.Text;
using FightCore.Models.Enum;

namespace FightCore.Models.Shared
{
    public class Media
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string SourceUrl { get; set; }
        public string Source { get; set; }
        public MediaType MediaType { get; set; }
    }
}
