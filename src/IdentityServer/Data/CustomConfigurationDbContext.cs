using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Extensions;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Data
{
    public class CustomConfigurationDbContext : ConfigurationDbContext<CustomConfigurationDbContext>
    {
        public CustomConfigurationDbContext(DbContextOptions<CustomConfigurationDbContext> options, ConfigurationStoreOptions storeOptions)
        : base(options, storeOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            ConfigurationStoreOptions storeConfigurationOptions = new ConfigurationStoreOptions();
            OperationalStoreOptions storeOperationalOptions = new OperationalStoreOptions();

            builder.ConfigureClientContext(storeConfigurationOptions);
            builder.ConfigureResourcesContext(storeConfigurationOptions);
        }

        public DbSet<IdentityResourceClaim> IdentityResourceClaims { get; set; }

    }
}


