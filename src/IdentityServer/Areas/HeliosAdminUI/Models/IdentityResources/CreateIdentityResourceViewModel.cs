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
        public string Name { get; set; }
        [Required]
        public string DisplayName { get; set; }
        [Required]
        public string UserClaimsString { get; set; }
        public List<IdentityResourceClaim> UserClaims
        {
            get
            {
                return string.IsNullOrEmpty(UserClaimsString) ?
                        new List<IdentityResourceClaim>()
                        : IdentityResourceClaimsHelper.CreateClaims(UserClaimsString); 
            }
            set {}
        }
    }
}
