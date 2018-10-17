using System;
using System.Collections.Generic;
using System.Text;

namespace FightCore.Models.Resources
{
    public class UserResource : IEntity
    {
        public int Id { get; set; }
        /// <summary>
        /// The user who has written this resource
        /// </summary>
        public ApplicationUser Author { get; set; }
        public int AuthorId { get; set; }
        /// <summary>
        /// The content of the resource
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// The link that the feature is about
        /// </summary>
        public string FeaturedLink { get; set; }
        /// <summary>
        /// The title of the resource
        /// </summary>
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastEdit { get; set; }
        /// <summary>
        /// The suggested skill for the reader
        /// </summary>
        public int SkillLevel { get; set; }
        /// <summary>
        /// The amount of views the post has
        /// </summary>
        public int Views { get; set; }
        public ResourceCategory Category { get; set; }
        /// <summary>
        /// If the post is patch dependent this will contain the patchId
        /// </summary>
        public int PatchId { get; set; }
    }
}
