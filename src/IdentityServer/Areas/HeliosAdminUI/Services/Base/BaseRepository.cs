using IdentityServer.Areas.HeliosAdminUI.Services.Contracts;
using IdentityServer.Data;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityServer.Areas.HeliosAdminUI.Services.Base
{
    public class BaseRepository<T> : IConfigurationRepository<T> where T : class
    {
        protected readonly CustomConfigurationDbContext _customDbContext;

        public BaseRepository(CustomConfigurationDbContext customDbContext )
        {
            _customDbContext = customDbContext ?? throw new ArgumentNullException(nameof(customDbContext));
        }

        public virtual async Task<IReadOnlyList<T>> GetAllAsync()
        {
            var entities = await _customDbContext.Set<T>().ToListAsync();
            return entities;
        }


        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _customDbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<bool> AddAsync(T entity)
        {
            _customDbContext.Set<T>().Add(entity);
            return await _customDbContext.SaveChangesAsync() > 0;
        }

        public virtual async Task<bool> UpdateAsync(T entity)
        {
            _customDbContext.Entry(entity).State = EntityState.Modified;
            return await _customDbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            _customDbContext.Set<T>().Remove(entity);
            return await _customDbContext.SaveChangesAsync() > 0 ;
        }
    }
}


