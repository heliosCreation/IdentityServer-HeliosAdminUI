using IdentityServer.Areas.HeliosAdminUI.Models.ViewModel;
using System.Collections.Generic;

namespace IdentityServer.Areas.HeliosAdminUI.Models
{
    public class ApiScopesListViewModel
    {
        public IReadOnlyList<ApiScopeViewModel> ApiScopes { get; set; }
    }
}
