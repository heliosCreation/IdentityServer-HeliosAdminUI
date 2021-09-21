using System.Collections.Generic;

namespace IdentityServer.Areas.HeliosAdminUI.Models.ApiScopes
{
    public class ApiScopesListViewModel
    {
        public IReadOnlyList<ApiScopeViewModel> ApiScopes { get; set; }
    }
}
