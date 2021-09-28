using IdentityServer.Areas.HeliosAdminUI.Services.Base;
using IdentityServer.Areas.HeliosAdminUI.Services.Contracts;
using IdentityServer.Data;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.Stores;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Areas.HeliosAdminUI.Services
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public IClientStore MyProperty { get; set; }
        public ClientRepository(CustomConfigurationDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<IReadOnlyList<Client>> GetAllAsync()
        {
            return await _dbContext.Clients
                .Include(c => c.AllowedGrantTypes)
                .Include(c => c.AllowedScopes)
                .ToListAsync();
        }

        public override async Task<Client> GetByIdAsync(int id)
        {
            return await _dbContext.Clients
                .Include(c => c.AllowedGrantTypes)
                .Include(c => c.AllowedScopes)
                .Include(c => c.RedirectUris)
                .Include(c => c.PostLogoutRedirectUris)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
        }

        public override async Task<bool> UpdateAsync( int id, Client newEntity)
        {
            var oldEntity = await GetByIdAsync(id);
            oldEntity.ClientId = newEntity.ClientId;
            oldEntity.ClientName = newEntity.ClientName;
            oldEntity.RedirectUris = newEntity.RedirectUris;
            oldEntity.FrontChannelLogoutUri = newEntity.FrontChannelLogoutUri;
            oldEntity.PostLogoutRedirectUris = newEntity.PostLogoutRedirectUris;
            oldEntity.AllowedGrantTypes = newEntity.AllowedGrantTypes;
            oldEntity.AllowedScopes = newEntity.AllowedScopes;
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
