using IdentityServer.Areas.HeliosAdminUI.Helpers;
using IdentityServer4.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Areas.HeliosAdminUI.Models.IdentityResources
{
    public class CreateIdentityResourceViewModel
    {
        [Required]
        [Display(Name="Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name ="Display name")]
        public string DisplayName { get; set; }

        [Required]
        public string UserClaimsString { get; set; }

        [Display(Name = "User Claim(s)")]
        public List<IdentityResourceClaim> UserClaims
        {
            get
            {
                return string.IsNullOrEmpty(UserClaimsString) ?
                        new List<IdentityResourceClaim>()
                        : IdentityResourceClaimsHelper.CreateClaims(UserClaimsString, default(int)); 
            }
            set {}
        }
    }
}
