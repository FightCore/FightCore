using FightCore.Repositories;
using FightCore.Data;
using FightCore.Repositories.Patterns;
using FightCore.Repositories.Resources;
using FightCore.Services;
using FightCore.Services.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.SignalR;
using FightCore.Api.Notifications;
using FightCore.Services.Characters;

namespace FightCore.Api.Configurations
{
    /// <summary>
    /// A class used to do dependency injection.
    /// </summary>
    public static class DependencyInjections
    {
        /// <summary>
        /// Adds the base of patterns to the services so they can be used.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>The same services with the patterns added.</returns>
        public static IServiceCollection AddPatterns(this IServiceCollection services)
        {
            services.AddScoped<DbContext, ApplicationDbContext>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUnitOfWorkAsync, UnitOfWork>();

            services.AddSingleton<IUserIdProvider, UserIdProvider>();

            return services;
        }

        /// <summary>
        /// Adds the services and repositories to the services so they can be used using dependency injection.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>The same services with the services and repositories added.</returns>
        public static IServiceCollection AddServicesAndRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();

            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICharacterService, CharacterService>();
            services.AddScoped<INotificationService, NotificationService>();

            return services;
        }
    }
}
