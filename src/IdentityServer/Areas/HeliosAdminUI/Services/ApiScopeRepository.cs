using IdentityServer.Areas.HeliosAdminUI.Services.Base;
using IdentityServer.Areas.HeliosAdminUI.Services.Contracts;
using IdentityServer.Data;
using IdentityServer4.EntityFramework.Entities;

namespace IdentityServer.Areas.HeliosAdminUI.Services
{
    public class ApiScopeRepository : BaseRepository<ApiScope>, IApiScopeRepository
    {
        public ApiScopeRepository(CustomConfigurationDbContext customDbContext) : base(customDbContext)
        {
        }
    }
}
