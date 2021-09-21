using IdentityServer4.EntityFramework.Entities;
using System.Collections.Generic;
using System.Linq;

namespace IdentityServer.Areas.HeliosAdminUI.Helpers
{
    public class IdentityResourceClaimsHelper
    {
        public IdentityResourceClaimsHelper(string claims)
        {
        }

        public static List<IdentityResourceClaim> CreateClaims(string claims, int? id)
        {
            var claimList = claims
                .Replace(",", " ")
                .Split(" ").ToList()
                .Where(c => !string.IsNullOrEmpty(c)).ToList();

            var resourcesClaims = new List<IdentityResourceClaim>();
            foreach (var claim in claimList)
            {
                resourcesClaims.Add(new IdentityResourceClaim() { Type = claim, IdentityResourceId = id.Value});
            }

            return resourcesClaims;
        }

        public static string CreateString(List<IdentityResourceClaim> claims)
        {
            var result = "";
            foreach (var item in claims)
            {
                result += $"{ item.Type},";
            }
            return result;
        }
    }
}
