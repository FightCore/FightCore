using System;
using System.Collections.Generic;
using System.Text;

namespace FightCore.Models
{
    using FightCore.Models.Shared;

    public interface IMediaEntity : IEntity
    {
        List<Media> Media { get; set; }
    }
}
