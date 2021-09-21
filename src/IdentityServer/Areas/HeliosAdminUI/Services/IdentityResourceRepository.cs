using IdentityServer.Areas.HeliosAdminUI.Services.Base;
using IdentityServer.Areas.HeliosAdminUI.Services.Contracts;
using IdentityServer.Data;
using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Areas.HeliosAdminUI.Services
{
    public class IdentityResourceRepository : BaseRepository<IdentityResource>, IIdentityResourceRepository
    {
        public IdentityResourceRepository(CustomConfigurationDbContext customDbContext) : base(customDbContext)
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

        public override async Task<bool> UpdateAsync(IdentityResource entity)
        {
            var existingParent = await _dbContext.IdentityResources
                    .Where(i => i.Id == entity.Id)
                    .Include(c => c.UserClaims)
                    .FirstOrDefaultAsync();

            if (existingParent != null)
            {
                // Update parent
                _dbContext.Entry(existingParent).CurrentValues.SetValues(entity);

                // Delete children
                foreach (var existingChild in existingParent.UserClaims.ToList())
                {
                    if (!entity.UserClaims.Any(c => c.Type == existingChild.Type && c.IdentityResourceId == existingChild.IdentityResourceId))
                        _dbContext.IdentityResourceClaims.Remove(existingChild);
                }

                // Update and Insert children
                foreach (var childModel in entity.UserClaims)
                {
                    var existingChild = existingParent.UserClaims
                        .Where(c => c.Type == childModel.Type && c.IdentityResourceId == childModel.IdentityResourceId)
                        .SingleOrDefault();

                    if (existingChild != null)
                        // Update child
                        existingChild.Type = childModel.Type;
                    else
                    {
                        // Insert child
                        var newChild = new IdentityResourceClaim
                        {
                            Type = childModel.Type,
                            IdentityResourceId = childModel.IdentityResourceId
                            //...
                        };
                        existingParent.UserClaims.Add(newChild);
                    }
                }

            }

            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
