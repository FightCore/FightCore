using FightCore.Models;
using System;

namespace FightCore.Api.Posts.Resources
{
    /// <summary>
    /// UI Resource of the <see cref="Models.Resources.Post"/> class
    /// </summary>
    public class PostResource
    {
        public int Category { get; set; }
        /// <summary>
        /// The title of the resource
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// The content of the resource
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// The link that the feature is about
        /// </summary>
        public string FeaturedLink { get; set; }
    }

    /// <summary>
    /// Describes the server response for a single post
    /// </summary>
    public class PostResultResource : PostResource
    {
        public int Id { get; set; }
        /// <summary>
        /// The user who has written this resource
        /// </summary>
        public ApplicationUser Author { get; set; }
        public int AuthorId { get; set; }
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
        /// <summary>
        /// If the post is patch dependent this will contain the patchId
        /// </summary>
        public int PatchId { get; set; }
    }
}
