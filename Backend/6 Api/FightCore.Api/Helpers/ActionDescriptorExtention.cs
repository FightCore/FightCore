using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace FightCore.Api.Helpers
{
    public static class ActionDescriptorExtensions
    {
        public static ApiVersionModel GetApiVersion(this ActionDescriptor actionDescriptor)
        {
            return actionDescriptor?.Properties
                .Where((kvp) => ((Type)kvp.Key) == typeof(ApiVersionModel))
                .Select(kvp => kvp.Value as ApiVersionModel).FirstOrDefault();
        }
    }
}
