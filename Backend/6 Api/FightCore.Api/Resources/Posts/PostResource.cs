using FightCore.Models;
using System;

using FightCore.Api.Resources;

namespace FightCore.Api.Resources.Posts
{
    /// <summary>
    /// UI Resource of the <see cref="Models.Resources.Post"/> class.
    /// </summary>
    public class PostResource
    {
		/// <summary>
		/// The category of the post.
		/// </summary>
        public int Category { get; set; }

        /// <summary>
        /// The title of the post.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The contents of the post in the HTML format.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// The link that is featured in the post.
        /// </summary>
        public string FeaturedLink { get; set; }
    }

    /// <summary>
    /// Describes the server response for a single post.
    /// </summary>
    public class PostResultResource : PostResource
    {
		/// <summary>
		/// The id of the post.
		/// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The user who has written this resource.
        /// </summary>
        public UserResource Author { get; set; }

		/// <summary>
		/// The id of the user who has written this resource.
		/// </summary>
        public int AuthorId { get; set; }


		/// <summary>
		/// The date on which this post was created.
		/// </summary>
        public DateTime CreatedDate { get; set; }

		/// <summary>
		/// The date on which this post was last edited.
		/// </summary>
        public DateTime LastEdit { get; set; }

        /// <summary>
        /// The suggested skill for the reader
        /// </summary>
        public int SkillLevel { get; set; }

        /// <summary>
        /// The amount of views the post has.
        /// </summary>
        public int Views { get; set; }

        /// <summary>
        /// If the post is patch dependent this will contain the patchId.
        /// </summary>
        public int PatchId { get; set; }

        /// <summary>
        /// Indicates if the post has been published.
        /// </summary>
        public bool Published { get; set; }
    }
}
