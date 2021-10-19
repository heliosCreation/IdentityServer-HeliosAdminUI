using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer.Areas.HeliosAdminUI.Dictionnary.Clients
{
    public static class ClientsInfo
    {
        public static Dictionary<string, string> Data = new Dictionary<string, string>
        {
            {nameof(Client.ClientId),"Unique ID of the client" },
            {nameof(Client.ClientName),"Client display name (used for logging and consent screen)" },
            {nameof(Client.ClientSecrets),"Credential to access the token endpoint." },
            {nameof(Client.RedirectUris),"Specifies the allowed URI to return tokens or authorization codes to"},
            {nameof(Client.FrontChannelLogoutUri),"Specifies logout URI at client for HTTP based front-channel logout."},
            {nameof(Client.PostLogoutRedirectUris),"Specifies allowed URI to redirect to after logout." },
            {nameof(Client.AllowedGrantTypes),"Specifies the grant types the client is allowed to use." },
            {nameof(Client.AllowedScopes),"Specifies the grant types the client is allowed to use." },
            {nameof(Client.AllowOfflineAccess),"Give the client access to the offline_access scope - this allows requesting refresh tokens for long lived API access" },
            {nameof(Client.UpdateAccessTokenClaimsOnRefresh),"Gets or sets a value indicating whether the access token (and its claims) should be updated on a refresh token request. Defaults to false." },
            {nameof(Client.AccessTokenLifetime),"Lifetime of access token in seconds (defaults to 3600 seconds / 1 hour)" }
        };

    }
}
