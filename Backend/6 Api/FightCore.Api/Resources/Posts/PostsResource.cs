using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FightCore.Api.Resources.Shared;

namespace FightCore.Api.Resources.Posts
{
    public class PostsResource
    {
        public int PageSize { get; set; }

        public int PageNumber { get; set; }

        public int SortOption { get; set; }

        public PostFiltersResource FilterOptions { get; set; }
    }

    public class PostsResultResource //: IPagedResult<PostPreviewResource> TODO discuss with Jawad and maybe implement.
    {
        public PostsResultResource(int pageSize, int pageNumber, int total, ICollection<PostPreviewResource> posts)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
            Total = total;
            Posts = posts;
        }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }

        public int Total { get; set; }

        public ICollection<PostPreviewResource> Posts { get; set; }
    }
}
