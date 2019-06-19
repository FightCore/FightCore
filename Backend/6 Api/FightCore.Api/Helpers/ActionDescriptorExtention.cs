using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace FightCore.Api.Helpers
{
    /// <summary>
    /// A class to help with the API version.
    /// </summary>
    public static class ActionDescriptorExtensions
    {
        /// <summary>
        /// Gets the API version based on the attribute.
        /// </summary>
        /// <param name="actionDescriptor">The descriptor.</param>
        /// <returns>The api version model.</returns>
        public static ApiVersionModel GetApiVersion(this ActionDescriptor actionDescriptor)
        {
            return actionDescriptor?.Properties
                .Where((kvp) => ((Type)kvp.Key) == typeof(ApiVersionModel))
                .Select(kvp => kvp.Value as ApiVersionModel).FirstOrDefault();
        }
    }
}
