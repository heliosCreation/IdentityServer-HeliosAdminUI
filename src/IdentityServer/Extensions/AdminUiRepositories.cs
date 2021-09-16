﻿using IdentityServer.AdminUI.Services;
using IdentityServer.AdminUI.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer.Extensions
{
    public static class AdminUiRepositories
    {
        public static IServiceCollection AddAdminUIRepositries(this IServiceCollection services)
        {

            services.AddScoped(typeof(IConfigurationRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IApiScopeRepository, ApiScopeRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IIdentityResourceRepository, IdentityResourceRepository>();

            return services;
        }
    }
}
