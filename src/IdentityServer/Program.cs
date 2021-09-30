// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class Program
    {
        public async static Task<int> Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
                .MinimumLevel.Override("System", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Information)
                .Enrich.FromLogContext()
                // uncomment to write to Azure diagnostics stream
                //.WriteTo.File(
                //    @"D:\home\LogFiles\Application\identityserver.txt",
                //    fileSizeLimitBytes: 1_000_000,
                //    rollOnFileSizeLimit: true,
                //    shared: true,
                //    flushToDiskInterval: TimeSpan.FromSeconds(1))
                .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}", theme: AnsiConsoleTheme.Code)
                .CreateLogger();

            try
            {
                var seedRoles = args.Contains("/seedRoles");
                var seedUsers = args.Contains("/seedUsers");
                var seedConfig = args.Contains("/seedConfig");
                var seeded = false;

                if (seedRoles)
                {
                    args = args.Except(new[] { "/seedRoles" }).ToArray();
                }
                if (seedUsers)
                {
                    args = args.Except(new[] { "/seedUsers" }).ToArray();
                }
                if (seedConfig)
                {
                    args = args.Except(new[] { "/seedConfig" }).ToArray();
                }

                var host = CreateHostBuilder(args).Build();

                if (seedRoles)
                {
                    Log.Information("Seeding roles in database...");
                    var config = host.Services.GetRequiredService<IConfiguration>();
                    var connectionString = config.GetConnectionString("UserStore");
                    await SeedData.EnsureSeedRoles(connectionString);
                    Log.Information("Done seeding roles in database.");
                    seeded = true;
                }
                if (seedUsers)
                {
                    Log.Information("Seeding Users database...");
                    var config = host.Services.GetRequiredService<IConfiguration>();
                    var connectionString = config.GetConnectionString("UserStore");
                    await SeedData.EnsureSeedUsersData(connectionString);
                    Log.Information("Done seeding users database.");
                    seeded = true;
                }
                if (seedConfig)
                {
                    Log.Information("Seeding Configuration and Operation database...");
                    var config = host.Services.GetRequiredService<IConfiguration>();
                    var connectionString = config.GetConnectionString("ConfigurationAndOperationData");
                    SeedData.EnsureSeedConfigurationAndOperationalData(connectionString);
                    Log.Information("Done seeding config database.");
                    seeded = true; 
                }
                if (seeded)
                {
                    return 0;
                }
                Log.Information("Starting host...");
                host.Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly.");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}