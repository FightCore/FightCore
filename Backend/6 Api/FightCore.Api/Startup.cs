using AspNet.Security.OpenIdConnect.Primitives;
using AutoMapper;
using FightCore.Api.Configurations;
using FightCore.Api.Middleware;
using FightCore.Api.Notifications;
using FightCore.Api.OperationFilters;
using FightCore.Data;
using FightCore.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using OpenIddict.Abstractions;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace FightCore.Api
{
    /// <summary>
    /// Startup class that is ran by MVC6 to set up the application.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The base configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        private IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">The services for Dependency Injection.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            RegisterCors(services);

            RegisterSignalR(services);

            RegisterMvc(services);

            RegisterSwagger(services);

            RegisterContext(services);

            RegisterIdentity(services);

            RegisterAuthentication(services);

            RegisterVersioning(services);

            services.AddAutoMapper(option => option.AddProfile(new AutoMapperConfiguration()));
            services.AddPatterns();
            services.AddServicesAndRepositories();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">The application builder.</param>
        /// <param name="env">The current environment.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseHsts();
            }

            RegisterCors(app);

            RegisterAuthentication(app);

            RegisterSwagger(app);

            RegisterSignalR(app);

            RegisterMvc(app);
        }

        #region Swagger
        private void RegisterSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1", new Info { Title = $"{nameof(FightCore)} API", Version = "v1" });
                    options.IncludeXmlComments($@"{AppDomain.CurrentDomain.BaseDirectory}{nameof(FightCore)}.Api.xml");
                    options.DescribeAllEnumsAsStrings();
                    options.OperationFilter<ApiVersionOperationFilter>();

                    //// o.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new ApiKeyScheme()
                    //// {
                    //// 	Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    //// 	Name = "Authorization",
                    //// 	In = "header",
                    //// 	Type = "apiKey"
                    //// });

                    options.AddSecurityDefinition(
                        JwtBearerDefaults.AuthenticationScheme,
                        new OAuth2Scheme
                        {
                            Type = "oauth2",
                            Flow = "password",
                            TokenUrl = "/connect/token"
                        });
                    options.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                                                       {
                                                           { "Bearer", Array.Empty<string>() }
                                                       });
                });
        }

        private void RegisterSwagger(IApplicationBuilder application)
        {
            application
                .UseSwagger()
                .UseSwaggerUI(c =>
                    {
                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "FightCore API V1");
                        c.DocExpansion(DocExpansion.None);
                        c.RoutePrefix = string.Empty;
                        c.DisplayRequestDuration();
                    });
        }
        #endregion Swagger

        #region Cors
        private void RegisterCors(IServiceCollection services)
        {
            services.AddCors(options =>
                {
                    options.AddPolicy(
                        "AllowSpecificOrigin",
                        builder => builder.WithOrigins("http://localhost:4200")
                                .AllowAnyMethod()
                                .AllowAnyHeader().AllowCredentials());
                });
        }

        private void RegisterCors(IApplicationBuilder application)
        {
            application.UseCors("AllowSpecificOrigin");
        }
        #endregion Cors

        #region Mvc

        private void RegisterMvc(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        private void RegisterMvc(IApplicationBuilder application)
        {
            application.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "/{controller=Home}/{action=Index}/{id?}");
                });
        }

        #endregion

        #region Identity

        private void RegisterIdentity(IServiceCollection services)
        {
			// Registers the BCrypt password hasher, has to be done before AddIdentity.
			services.AddScoped<IPasswordHasher<ApplicationUser>, BCryptPasswordHasher<ApplicationUser>>();

            services.AddIdentity<ApplicationUser, IdentityRole<int>>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.ClaimsIdentity.UserNameClaimType = OpenIdConnectConstants.Claims.Name;
                options.ClaimsIdentity.UserIdClaimType = OpenIdConnectConstants.Claims.Subject;
                options.ClaimsIdentity.RoleClaimType = OpenIdConnectConstants.Claims.Role;
            });

            // Register OpenIddict services
            services.AddOpenIddict()
                .AddCore(options =>
                {
                    options.UseEntityFrameworkCore()
                        .UseDbContext<ApplicationDbContext>();
                })
                .AddServer(options =>
                    {
                        options.UseMvc();

                        options.Services.AddCors(
                            corsOptions =>
                                {
                                    corsOptions.AddPolicy(
                                        "AllowSpecificOrigins",
                                        builder => builder.WithOrigins("http://localhost:4200").AllowAnyMethod()
                                            .AllowAnyHeader().AllowCredentials());
                                });
                        services.Configure<MvcOptions>(
                            mvcOptions =>
                                {
                                    mvcOptions.Filters.Add(
                                        new CorsAuthorizationFilterFactory("AllowSpecificOrigins"));
                                });
                        options
                        // These endpoints still need to be implemented
                        //.EnableAuthorizationEndpoint("/connect/authorize")
                        //.EnableLogoutEndpoint("/connect/logout")
                        //.EnableIntrospectionEndpoint("/connect/introspect")
                            .EnableTokenEndpoint("/connect/token")
                            .EnableUserinfoEndpoint("/api/userinfo");


                        options.RegisterScopes(
                            OpenIdConnectConstants.Scopes.Email,
                            OpenIdConnectConstants.Scopes.Profile,
                            OpenIddictConstants.Scopes.Roles);


                        options.EnableRequestCaching();

                        options.AllowPasswordFlow();
                        options.AllowRefreshTokenFlow();

                        options.AcceptAnonymousClients();
#if DEBUG
                        options.AddDevelopmentSigningCertificate();
                        options.DisableHttpsRequirement();
#endif

                        options.UseJsonWebTokens();
                        options.AddEphemeralSigningKey();
                    });

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap.Clear();
        }

        #endregion

        #region Authentication

        private void RegisterAuthentication(IServiceCollection services)
        {
            services.AddAuthentication(options =>
                    {
                        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    })
                .AddJwtBearer(options =>
                {
                    options.Authority = Configuration.GetSection("Jwt:Authority").Value;
                    options.Audience = "resource_server";
#if DEBUG
                    options.RequireHttpsMetadata = false;
#endif
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = OpenIdConnectConstants.Claims.Subject,
                        RoleClaimType = OpenIdConnectConstants.Claims.Role
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                            {
                                if (context.Request.Query.TryGetValue("token", out var token))
                                {
                                    context.Token = token;
                                }

                                return Task.CompletedTask;
                            }
                    };
                });
        }

        private void RegisterAuthentication(IApplicationBuilder application)
        {
            application
                .UseAuthentication()
                .UseHttpsRedirection();
        }

        #endregion

        #region SignalR

        private void RegisterSignalR(IServiceCollection services)
        {
            services.AddSignalR();
        }

        private void RegisterSignalR(IApplicationBuilder application)
        {
            application.UseSignalR(routes =>
                {
                    routes.MapHub<NotifyHub>("/notify");
                });
        }

        #endregion

        #region Context

        private void RegisterContext(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                    options.UseOpenIddict();
                });
        }

        #endregion

        #region Versioning

        private void RegisterVersioning(IServiceCollection services)
        {
            services.AddApiVersioning(
                options =>
                    {
                        options.DefaultApiVersion = new ApiVersion(1, 0); // specify the default api version
                        options.AssumeDefaultVersionWhenUnspecified = true; // assume that the caller wants the default version if they don't specify
                    });
        }

        #endregion
    }
}
