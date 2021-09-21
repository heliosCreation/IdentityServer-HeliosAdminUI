using System.Collections.Generic;

namespace IdentityServer.Areas.HeliosAdminUI.Models.IdentityResources
{
    public class IdentityResourceViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public IEnumerable<string> UserClaims { get; set; }
    }
}
