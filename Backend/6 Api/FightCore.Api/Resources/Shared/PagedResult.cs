using System.Collections.Generic;

namespace FightCore.Api.Resources.Shared
{
    /// <summary>
    /// An interface intended to be used to implement a paged result.
    /// </summary>
    /// <typeparam name="T">The type of object that will be returned</typeparam>
    public interface IPagedResult<out T>
    {
        /// <summary>
        /// Gets the number of the page provided.
        /// </summary>
        int Page { get; }

        /// <summary>
        /// Gets the amount of items per page.
        /// </summary>
        int PageSize { get; }

        /// <summary>
        /// Gets the total number of items.
        /// </summary>
        int Total { get; }

        /// <summary>
        /// Gets the actual results.
        /// </summary>
        IEnumerable<T> Results { get; }
    }
}
