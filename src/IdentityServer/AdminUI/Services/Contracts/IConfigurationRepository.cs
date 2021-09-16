using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityServer.AdminUI.Services
{
    public interface IConfigurationRepository<T>
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
