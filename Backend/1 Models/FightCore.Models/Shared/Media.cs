using FightCore.Models.Enum;

namespace FightCore.Models.Shared
{
    /// <summary>
    /// A class to use to link media objects like GIFs, Links, Videos and Images to database objects.
    /// </summary>
    public class Media : IEntity
    {
        /// <inheritdoc cref="IEntity.Id"/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the url of the actual media item being linked to
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the description of the media object
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the url of the source's website
        /// </summary>
        public string SourceUrl { get; set; }

        /// <summary>
        /// Gets or sets the name of the source this media item is taken from
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets which type of media object this is
        /// </summary>
        public MediaType MediaType { get; set; }
    }
}
