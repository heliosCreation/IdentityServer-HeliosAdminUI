using IdentityServer.AdminUI.Services.Contracts;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Entities;

namespace IdentityServer.AdminUI.Services
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(ConfigurationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
