using System.Collections.Generic;

namespace IdentityServer.Areas.HeliosAdminUI.Helpers
{
    public static class ClientTagHelper
    {
        public static string CreateAllowedScopeString(IEnumerable<string> scopes)
        {
            var result = "";
            foreach (var item in scopes)
            {
                result += $"{item},";
            }
            return result;
        }
    }
}

