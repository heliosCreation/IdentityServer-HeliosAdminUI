using IdentityServer.Areas.HeliosAdminUI.Services.Base;
using IdentityServer.Areas.HeliosAdminUI.Services.Contracts;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Areas.HeliosAdminUI.Services
{
    public class IdentityResourceRepository : BaseRepository<IdentityResource>, IIdentityResourceRepository
    {
        public IdentityResourceRepository(ConfigurationDbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<IReadOnlyList<IdentityResource>> GetAllAsync()
        {
            var entities = await _dbContext.IdentityResources.Include(i => i.UserClaims).ToListAsync();
            return entities;
        }

        public override async Task<IdentityResource> GetByIdAsync(int id)
        {
            var entity = await _dbContext.IdentityResources
                .Include(i => i.UserClaims)
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();


            return entity;
        }


    }
}
