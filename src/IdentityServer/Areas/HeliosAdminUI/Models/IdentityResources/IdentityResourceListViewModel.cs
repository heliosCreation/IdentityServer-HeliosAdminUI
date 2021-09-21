using System.Collections.Generic;

namespace IdentityServer.Areas.HeliosAdminUI.Models.IdentityResources
{
    public class IdentityResourceListViewModel
    {
        public IReadOnlyList<IdentityResourceViewModel> IdentityResourcesList { get; set; }
    }
}
