using IdentityServer.Areas.HeliosAdminUI.Helpers;
using IdentityServer4.EntityFramework.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Areas.HeliosAdminUI.Models.IdentityResources
{
    public class UpdateIdentityResourceViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Display name")]
        public string DisplayName { get; set; }

        private string userClaimsString;

        [Required]
        public string UserClaimsString
        {
            get { return this.UserClaims.Count > 0 ? IdentityResourceClaimsHelper.CreateString(UserClaims) : userClaimsString; }
            set { userClaimsString =  value; }
        }
        [Display(Name ="User Claim(s)")]
        public List<IdentityResourceClaim> UserClaims { get; set; } = new List<IdentityResourceClaim>();
    }
}
