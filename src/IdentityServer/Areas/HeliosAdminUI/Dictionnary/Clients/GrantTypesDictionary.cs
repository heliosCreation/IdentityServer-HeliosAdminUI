using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer.Areas.HeliosAdminUI.Dictionnary.Clients
{
    public static class GrantTypesDictionary
    {
        public static Dictionary<string, ICollection<string>> Data = new Dictionary<string, ICollection<string>>
        {
            {"Implicit", GrantTypes.Implicit},
            {"ImplicitAndClientCredentials", GrantTypes.ImplicitAndClientCredentials},
            {"Code", GrantTypes.Code},
            {"CodeAndClientCredentials", GrantTypes.CodeAndClientCredentials},
            {"Hybrid", GrantTypes.Hybrid},
            {"HybridAndClientCredentials", GrantTypes.HybridAndClientCredentials},
            {"ClientCredentials" ,GrantTypes.ClientCredentials},
            {"ResourceOwnerPassword", GrantTypes.ResourceOwnerPassword},
            {"ResourceOwnerPasswordAndClientCredentials", GrantTypes.ResourceOwnerPasswordAndClientCredentials},
            { "DeviceFlow", GrantTypes.DeviceFlow},
        };
    }
}

