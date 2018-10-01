using System;
using System.Collections.Generic;
using System.Text;
using FightCore.Models.Enum;

namespace FightCore.Models.Shared
{
    public class Media : IEntity
    {
        public int Id { get; set; }
        /// <summary>
        /// The Url of the actual media item being linked to
        /// </summary>
        public string Url { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// The Url of the source's website
        /// </summary>
        public string SourceUrl { get; set; }
        /// <summary>
        /// The name of the source this media item is taken from
        /// </summary>
        public string Source { get; set; }
        public MediaType MediaType { get; set; }
    }
}
