using System.Collections.Generic;
using FightCore.Api.Resources.Posts;

namespace FightCore.Api.Resources.Characters
{
    /// <summary>
    /// The resource that represents the character class.
    /// </summary>
    public class CharacterResource
    {
        /// <summary>
        /// The name of the character.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The url of the image that belongs with this character.
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// The game this character belongs to.
        /// </summary>
        public object Game { get; set; }

        /// <summary>
        /// A description about this character.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The posts made the character.
        /// </summary>
        public List<PostResource> Posts { get; set; }
    }
}