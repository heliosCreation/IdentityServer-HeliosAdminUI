using IdentityServer.Areas.HeliosAdminUI.Services.Base;
using IdentityServer.Areas.HeliosAdminUI.Services.Contracts;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Entities;

namespace IdentityServer.Areas.HeliosAdminUI.Services
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(ConfigurationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
