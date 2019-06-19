using System;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace FightCore.Api
{
    /// <summary>
    /// The program to be executed for the ASP.Net application.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The method that is executed when running the program.
        /// </summary>
        /// <param name="args">The provided arguments to run with.</param>
        public static void Main(string[] args)
        {
			var config = CreateConfiguration(args);

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .Enrich.FromLogContext()
                .CreateLogger();

            CreateWebHostBuilder(args, config).Build().Run();
        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args, IConfiguration configuration)
        {
            return WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().UseConfiguration(configuration)
                .UseSerilog();
        }

		private static IConfiguration CreateConfiguration(string[] args)
		{
			var configBuilder = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

			foreach (var argument in args)
			{
				configBuilder.AddJsonFile($"appsettings.{argument}.json", true, true);
			}

			configBuilder.AddEnvironmentVariables();
			return configBuilder.Build();
		}
	}
}
