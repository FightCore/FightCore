using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FightCore.Api.Resources.Shared;

namespace FightCore.Api.Resources.Posts
{
    /// <summary>
    /// The list of posts
    /// </summary>
    public class PostsResultResource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PostsResultResource"/> class.
        /// </summary>
        /// <param name="pageSize">The size of the page provided.</param>
        /// <param name="pageNumber">The number of the page that we are on.</param>
        /// <param name="total">The total amount of posts sent back.</param>
        /// <param name="posts">The posts that are being sent.</param>
        public PostsResultResource(int pageSize, int pageNumber, int total, ICollection<PostPreviewResource> posts)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
            Total = total;
            Posts = posts;
        }

		/// <summary>
		/// The amount of items per page.
		/// </summary>
		public int PageSize { get; set; }

		/// <summary>
		/// A number to indicate which page is displayed. This page number is 1 based.
		/// </summary>
		public int PageNumber { get; set; }

		/// <summary>
		/// The total amount of posts that are available
		/// </summary>
		public int Total { get; set; }

		/// <summary>
		/// The posts on this page.
		/// </summary>
		public ICollection<PostPreviewResource> Posts { get; set; }
    }
}
