using System.Collections.Generic;
using FightCore.Models.Shared;

namespace FightCore.Models
{
    /// <summary>
    /// An interface used to easy add media to entities.
    /// </summary>
    public interface IMediaEntity : IEntity
    {
        /// <summary>
        /// Gets or sets a list of media objects for the entity
        /// </summary>
        List<Media> Media { get; set; }
    }
}
