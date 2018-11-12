using AspNet.Security.OpenIdConnect.Primitives;
using AutoMapper;
using FightCore.Api.Configurations;
using FightCore.Api.Notifications;
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
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace FightCore.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

            app.UseCors("AllowSpecificOrigins");

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(
                c =>
                    {
                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "FightCore API V1");
                        c.DocExpansion(DocExpansion.None);
                        c.RoutePrefix = string.Empty;
                        c.DisplayRequestDuration();
                    });

            app.UseSignalR(routes => { routes.MapHub<NotifyHub>("/notify"); });
            app.UseAuthentication();
            app.UseMvc(
                routes => { routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}"); });
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(
                options =>
                    {
                        options.AddPolicy(
                            "AllowSpecificOrigins",
                            builder => builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader()
                                .AllowCredentials());
                    });

            // Register OpenIddict services
            services.AddOpenIddict()
                .AddCore(options => { options.UseEntityFrameworkCore().UseDbContext<ApplicationDbContext>(); })
                .AddServer(
                    options =>
                    {
                        options.Services.AddCors(
                            corsOptions =>
                            {
                                corsOptions.AddPolicy(
                                        "AllowSpecificOrigins",
                                        builder => builder.WithOrigins("http://localhost:4200").AllowAnyMethod()
                                            .AllowAnyHeader().AllowCredentials());
                            });

                        options.UseMvc();
                        services.Configure<MvcOptions>(
                            mvcOptions =>
                            {
                                mvcOptions.Filters.Add(
                                        new CorsAuthorizationFilterFactory("AllowSpecificOrigins"));
                            });

                        options

                            // These endpoints still need to be implemented
                            // .EnableAuthorizationEndpoint("/connect/authorize")
                            // .EnableLogoutEndpoint("/connect/logout")
                            // .EnableIntrospectionEndpoint("/connect/introspect")
                            .EnableTokenEndpoint("/connect/token").EnableUserinfoEndpoint("/api/userinfo");

                        options.AllowPasswordFlow();

                        options.RegisterScopes(
                            OpenIdConnectConstants.Scopes.Email,
                            OpenIdConnectConstants.Scopes.Profile,
                            OpenIddictConstants.Scopes.Roles);

                        options.EnableRequestCaching();

                        options.AllowRefreshTokenFlow();

                        options.AcceptAnonymousClients();

                        options.DisableHttpsRequirement();

                        options.UseJsonWebTokens();
                        options.AddEphemeralSigningKey();
                    });

            services.AddSignalR();

            services.AddDbContext<ApplicationDbContext>(
                options =>
                    {
                        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                        options.UseOpenIddict();
                    });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.Configure<MvcOptions>(
                options => { options.Filters.Add(new CorsAuthorizationFilterFactory("AllowSpecificOrigins")); });

            services.AddSwaggerGen(
                options =>
                    {
                        options.SwaggerDoc("v1", new Info { Title = $"{nameof(FightCore)} API", Version = "v1" });
                        options.IncludeXmlComments(
                            $@"{AppDomain.CurrentDomain.BaseDirectory}{nameof(FightCore)}.Api.xml");
                        options.DescribeAllEnumsAsStrings();

                        options.AddSecurityDefinition(
                            JwtBearerDefaults.AuthenticationScheme,
                            new OAuth2Scheme { Type = "oauth2", Flow = "password", TokenUrl = "/connect/token" });
                        options.AddSecurityRequirement(
                            new Dictionary<string, IEnumerable<string>> { { "Bearer", new string[] { } } });
                    });


            services.AddIdentity<ApplicationUser, IdentityRole<int>>().AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(
                options =>
                    {
                        options.ClaimsIdentity.UserNameClaimType = OpenIdConnectConstants.Claims.Name;
                        options.ClaimsIdentity.UserIdClaimType = OpenIdConnectConstants.Claims.Subject;
                        options.ClaimsIdentity.RoleClaimType = OpenIdConnectConstants.Claims.Role;
                    });

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap.Clear();

            services.AddAuthentication(
                options =>
                    {
                        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    }).AddJwtBearer(
                options =>
                    {
                        options.Authority = Configuration.GetSection("Jwt:Authority").Value;
                        options.Audience = "resource_server";
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters =
                            new TokenValidationParameters
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

            services.AddAutoMapper(option => option.AddProfile(new AutoMapperConfiguration()));
            services.AddPatterns();
            services.AddServicesAndRepositories();
        }
    }
}