using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FightCore.Api.Swagger;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StackExchange.Profiling;
using StackExchange.Profiling.Storage;

namespace FightCore.Api.Configurations
{
    /// <summary>
    /// An extension class to be used to set up MiniProfiler
    /// </summary>
    public static class MiniProfilerConfiguration
    {
        /// <summary>
        /// Adds MiniProfiler to the project and sets it up properly
        /// </summary>
        /// <param name="services">The services MP needs to be configured for</param>
        /// <returns>the same services with MP added</returns>
        public static IServiceCollection AddMiniProfilerSetup(this IServiceCollection services)
        {
            services.AddMiniProfiler(options =>
                {
                    options.AddEntityFramework();
                    options.Storage = new NLogStorage(new MemoryCache(new MemoryCacheOptions()), TimeSpan.FromMinutes(30), 
                        new Logger<NLogStorage>(new LoggerFactory()));
                }
            );
            return services;
        }
    }
}
