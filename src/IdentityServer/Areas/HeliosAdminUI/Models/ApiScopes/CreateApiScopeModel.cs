using IdentityServer4.EntityFramework.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Areas.HeliosAdminUI.Models.ApiScopes
{
    public class CreateApiScopeModel
    {

        [Required]
        [MaxLength(250)]
        [Display(Name="Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        [Display(Name = "Display name")]
        public string DisplayName { get; set; }

        [MaxLength(250)]
        [Display(Name ="Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Required")]
        public bool Required { get; set; }

        [Display(Name = "Emphasize")]
        public bool Emphasize { get; set; }

        [Required]
        [Display(Name = "Enabled")]
        public bool Enabled { get; set; } = true;

        [Required]
        [Display(Name = "Show in Discovery Document")]
        public bool ShowInDiscoveryDocument { get; set; } = true;
        public List<ApiScopeClaim> UserClaims { get; set; }
        public List<ApiScopeProperty> Properties { get; set; }
    }
}
