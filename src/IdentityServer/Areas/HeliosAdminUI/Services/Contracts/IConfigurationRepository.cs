using IdentityServer4.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityServer.Areas.HeliosAdminUI.Services.Contracts
{
    public interface IConfigurationRepository<T>
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> UpdateAsync(int id, T entity);

        Task<bool> DeleteAsync(T entity);
    }
}
