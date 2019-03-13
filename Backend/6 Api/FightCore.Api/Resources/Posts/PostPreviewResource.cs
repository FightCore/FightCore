using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FightCore.Api.Resources.Posts
{
    /// <summary>
    /// Simplified UI resource of the <see cref="Models.Resources.Post"/> class
    /// </summary>
    public class PostPreviewResource
    {
		/// <summary>
		/// The Id of the post.
		/// </summary>
        public int Id { get; set; }

		/// <summary>
		/// The author of the post.
		/// </summary>
        public UserResource Author { get; set; }

		/// <summary>
		/// The author's Id
		/// </summary>
        public int AuthorId { get; set; }

		/// <summary>
		/// The title of the post.
		/// </summary>
        public string Title { get; set; }

		/// <summary>
		/// The amount of views the post has gotten.
		/// </summary>
        public int Views { get; set; }

		/// <summary>
		/// The category the post was made in.
		/// </summary>
        public int Category { get; set; }

		/// <summary>
        /// The link featured in the post.
        /// </summary>
        public string FeaturedLink { get; set; }
    }
}
