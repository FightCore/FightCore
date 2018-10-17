using System;
using System.Collections.Generic;
using System.Text;

namespace FightCore.Models
{
    /// <summary>
    /// The interface used to declare Entities for easy access using the service.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Gets or sets the Id used to identify this entity.
        /// </summary>
        int Id { get; set; }
    }
}
