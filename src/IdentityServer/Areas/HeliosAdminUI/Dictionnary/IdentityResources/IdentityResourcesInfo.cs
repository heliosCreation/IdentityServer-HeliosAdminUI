using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer.Areas.HeliosAdminUI.Dictionnary.IdentityResources
{
    public static class IdentityResourcesInfo
    {
        public static Dictionary<string, string> Data = new Dictionary<string, string>
        {
            {nameof(IdentityResource.Name),"The unique name of the resource." },
            {nameof(IdentityResource.DisplayName),"Display name of the resource." },
            {nameof(IdentityResource.UserClaims),"List of associated user claims that should be included when this resource is requested." }

        };
    }
}
