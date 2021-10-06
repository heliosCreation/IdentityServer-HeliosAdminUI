using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer.Areas.HeliosAdminUI.Dictionnary.ApiScopes
{
    public static class ApiScopesInfo
    {
        public static Dictionary<string, string> Data = new Dictionary<string, string>
        {
            {nameof(ApiScope.Name),"The unique name of the API. This value is used for authentication with introspection and will be added to the audience of the outgoing access token." },
            {nameof(ApiScope.DisplayName),"This value can be used e.g. on the consent screen." },
            {nameof(ApiScope.Description),"This value can be used e.g. on the consent screen." },
            {nameof(ApiScope.Required)," Specifies whether the user can de-select the scope on the consent screen. Defaults to false."},
            {nameof(ApiScope.Emphasize),"Specifies whether the consent screen will emphasize this scope. Use this setting for sensitive or important scopes. Defaults to false." },
            {nameof(ApiScope.Enabled),"Indicates if this resource is enabled. Defaults to True." },
            {nameof(ApiScope.ShowInDiscoveryDocument),"Specifies whether this scope is shown in the discovery document. Defaults to True." },
            {nameof(ApiScope.UserClaims),"List of associated user claims that should be included when this resource is requested." },
            {nameof(ApiScope.Properties),"Gets or sets the custom properties for the resource." }
        };

    }
}
