using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FightCore.Api.Resources.Posts
{
    public class PostsResource
    {
        public int PageSize { get; set; }

        public int PageNumber { get; set; }

        public int SortOption { get; set; }

        public PostFiltersResource FilterOptions { get; set; }
    }

    public class PostsResultResource
    {
        public int PageSize { get; set; }

        public int PageNumber { get; set; }

        public int Total { get; set; }

        public ICollection<PostPreviewResource> Posts { get; set; }
    }
}
