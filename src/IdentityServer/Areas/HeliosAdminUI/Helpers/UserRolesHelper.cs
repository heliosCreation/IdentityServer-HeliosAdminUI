using System.Collections.Generic;
using System.Linq;

namespace IdentityServer.Areas.HeliosAdminUI.Helpers
{
    public static class UserRolesHelper
    {
        public static List<string> CreateRoles(string baseString)
        {
            return baseString.Replace(",", " ").Split(" ").ToList();
        }
    }
}
