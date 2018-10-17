using FightCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FightCore.Data;
using FightCore.Repositories.Patterns;
using FightCore.Repositories.Resources;
using FightCore.Services;
using FightCore.Services.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FightCore.Api.Configurations
{
    /// <summary>
    /// DependencyInjections
    /// </summary>
    public static class DependencyInjections
    {
        /// <summary>
        /// Adds the patterns.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection AddPatterns(this IServiceCollection services)
        {
            services.AddScoped<DbContext, ApplicationDbContext>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUnitOfWorkAsync, UnitOfWork>();

            return services;
        }

        /// <summary>
        /// Adds the services and repositories.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection AddServicesAndRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserResourceRepository, UserResourceRepository>();

            services.AddScoped<IUserResourceService, UserResourceService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
