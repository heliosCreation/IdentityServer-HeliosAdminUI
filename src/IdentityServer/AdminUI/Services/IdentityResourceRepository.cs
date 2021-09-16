using IdentityServer.AdminUI.Services.Contracts;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Entities;

namespace IdentityServer.AdminUI.Services
{
    public class IdentityResourceRepository : BaseRepository<IdentityResource>, IIdentityResourceRepository
    {
        public IdentityResourceRepository(ConfigurationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
