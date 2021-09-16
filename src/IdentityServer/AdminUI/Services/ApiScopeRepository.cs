using IdentityServer.AdminUI.Services.Contracts;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Entities;

namespace IdentityServer.AdminUI.Services
{
    public class ApiScopeRepository : BaseRepository<ApiScope>, IApiScopeRepository
    {
        public ApiScopeRepository(ConfigurationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
