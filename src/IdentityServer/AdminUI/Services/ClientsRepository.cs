using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Entities;

namespace IdentityServer.AdminUI.Services
{
    public class ClientsRepository : BaseRepository<Client>
    {
        public ClientsRepository(ConfigurationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
