using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Entities;

namespace IdentityServer.AdminUI.Services
{
    public class ApiScopesRepository : BaseRepository<ApiScope>
    {
        public ApiScopesRepository(ConfigurationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
