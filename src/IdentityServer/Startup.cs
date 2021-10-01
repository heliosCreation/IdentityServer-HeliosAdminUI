// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer.Data;
using IdentityServer.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IdentityServer4.Configuration;
using System;
using System.Reflection;
using IdentityServer.Services;
using IdentityServer.Extensions;
using IdentityServer4.EntityFramework.Interfaces;
using IdentityServer4.Services;

namespace IdentityServer
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation(); ;
            services.AddHttpContextAccessor();

            services.AddIdentityFrameworkService(Configuration);
            services.AddIdentityServerService(Configuration);
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IConfigurationDbContext, CustomConfigurationDbContext>();
            services.AddDbContext<CustomConfigurationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConfigurationAndOperationData")));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ILocalUserService, LocalUserService>();
            services.AddAdminUIRepositries();

            services.AddAuthenticationService();

        }

        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }

            app.UseStaticFiles();

            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {

                endpoints.MapAreaControllerRoute(
                    name: "HeliosAdminUI",
                    areaName: "HeliosAdminUI",
                    pattern: "HeliosAdminUI/{controller=Home}/{action=Index}"
                );

                endpoints.MapControllerRoute(
                    name: "areaRoute",
                    pattern: "{area:exists}/{controller}/{action}"
                );

                endpoints.MapDefaultControllerRoute();

            });


        }
    }
}