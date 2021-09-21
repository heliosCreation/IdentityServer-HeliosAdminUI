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
        protected readonly CustomConfigurationDbContext _dbContext;

        public BaseRepository(CustomConfigurationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public virtual async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }


        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<bool> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public virtual async Task<bool> UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return await _dbContext.SaveChangesAsync() > 0 ;
        }
    }
}


