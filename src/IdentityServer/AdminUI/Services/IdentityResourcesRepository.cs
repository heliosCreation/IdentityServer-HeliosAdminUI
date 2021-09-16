using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Entities;

namespace IdentityServer.AdminUI.Services
{
    public class IdentityResourcesRepository : BaseRepository<IdentityResource>
    {
        public IdentityResourcesRepository(ConfigurationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
