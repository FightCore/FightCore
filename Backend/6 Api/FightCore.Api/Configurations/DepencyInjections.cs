using FightCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FightCore.Data;
using FightCore.Repositories.Patterns;
using FightCore.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FightCore.Services.Characters;
using FightCore.Repositories.Characters;
using FightCore.Repositories.Games;
using FightCore.Services.Games;

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
            services.AddScoped<ICharacterRepository, CharacterRepository>();
            services.AddScoped<ITechniqueRepository, TechniqueRepository>();
            services.AddScoped<IGameRepository, GameRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICharacterService, CharacterService>();
            services.AddScoped<ITechniqueService, TechniqueService>();
            services.AddScoped<IGameService, GameService>();

            return services;
        }
    }
}
