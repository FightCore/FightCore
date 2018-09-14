using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FightCore.Models.Enum;

namespace FightCore.Api.Resources.Shared
{
    public class MediaResource
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string SourceUrl { get; set; }
        public string Source { get; set; }
        public MediaType MediaType { get; set; }
    }
}
