using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using NLog;
using StackExchange.Profiling;
using StackExchange.Profiling.Storage;

namespace FightCore.Api.Swagger
{
    /// <summary>
    /// A class used to save the profile data in NLog as well as MemoryCache
    /// </summary>
    public class NLogStorage : MemoryCacheStorage
    {
        private readonly ILogger<NLogStorage> _logger;

        /// <summary>
        /// Saves the current profile to a file as well as the cache
        /// </summary>
        /// <param name="profiler"></param>
        public new void Save(MiniProfiler profiler)
        {
            _logger.LogTrace(profiler.RenderPlainText());
            base.Save(profiler);
        }

        /// <summary>
        /// Creates new instance of the <see cref="NLogStorage"/> class
        /// </summary>
        /// <param name="cache"></param>
        /// <param name="cacheDuration"></param>
        /// <param name="logger"></param>
        public NLogStorage(IMemoryCache cache, TimeSpan cacheDuration, ILogger<NLogStorage> logger) : base(cache, cacheDuration)
        {
            _logger = logger;
        }
    }
}
