using IdentityServer4.EntityFramework.Entities;
using System.Threading.Tasks;

namespace IdentityServer.Areas.HeliosAdminUI.Services.Contracts
{
    public interface IClientRepository : IConfigurationRepository<Client>
    {
    }
}
