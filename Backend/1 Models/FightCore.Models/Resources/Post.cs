using System;
using System.Collections.Generic;
using System.Text;

namespace FightCore.Models.Resources
{
    public class Post : IEntity
    {
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the user who has written this resource
        /// </summary>
        public ApplicationUser Author { get; set; }

        public int AuthorId { get; set; }

        /// <summary>
        /// Gets or sets the content of the resource
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the link that the feature is about
        /// </summary>
        public string FeaturedLink { get; set; }

        /// <summary>
        /// Gets or sets the title of the resource
        /// </summary>
        public string Title { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastEdit { get; set; }

        /// <summary>
        /// Gets or sets the suggested skill for the reader
        /// </summary>
        public int SkillLevel { get; set; }

        /// <summary>
        /// Gets or sets the amount of views the post has
        /// </summary>
        public int Views { get; set; }

        public ResourceCategory Category { get; set; }

        /// <summary>
        /// Gets or sets the patch dependent id.
        /// </summary>
        public int PatchId { get; set; }
    }
}
