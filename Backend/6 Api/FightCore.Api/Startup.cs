using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using AspNet.Security.OpenIdConnect.Primitives;
using AutoMapper;
using FightCore.Api.Configurations;
using FightCore.Data;
using FightCore.Models;
using FightCore.Repositories;
using FightCore.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OpenIddict.Abstractions;

namespace FightCore.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

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
                    options.EnableAuthorizationEndpoint("/connect/authorize")
                        .EnableLogoutEndpoint("/connect/logout")
                        .EnableIntrospectionEndpoint("/connect/introspect")
                        .EnableTokenEndpoint("/connect/token")
                        .EnableUserinfoEndpoint("/api/userinfo");


                    options.RegisterScopes(OpenIdConnectConstants.Scopes.Email,
                        OpenIdConnectConstants.Scopes.Profile,
                        OpenIddictConstants.Scopes.Roles);

                    options.EnableRequestCaching();


                    options.AllowPasswordFlow();
                    options.AllowClientCredentialsFlow();
                    options.AllowRefreshTokenFlow();

                    options.DisableHttpsRequirement();
                    options.AddEphemeralSigningKey();

                    options.UseJsonWebTokens();
                });

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap.Clear();

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.Authority = Configuration.GetSection("Jwt:Authority").Value;
                    options.Audience = "resource_server";
                    options.RequireHttpsMetadata = false;
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

            services.AddAutoMapper(option => option.AddProfile(new AutoMapperConfiguration()));
            services.AddPatterns();
            services.AddServicesAndRepositories();
        }

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

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
