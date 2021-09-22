using IdentityServer.Areas.HeliosAdminUI.Models.Clients.Enum;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Areas.HeliosAdminUI.Models.Clients
{
    public class CreateClientViewModel
    {
        [Required]
        [Display(Name = "Client Id")]
        [StringLength(250)]
        public string ClientId { get; set; }

        [Required]
        [Display(Name = "Client Name")]
        [StringLength(250)]
        public string ClientName { get; set; }

        [Required]
        [Display(Name = "Client Secret")]
        [StringLength(250)]
        public string ClientSecret { get; set; }

        [Display(Name = "Redirect Uri")]
        [StringLength(250)]
        public string RedirectUris { get; set; }/* = "https://localhost:5002/signin-oidc";*/

        [Display(Name = "Front Channel Logout Uri")]
        [StringLength(250)]
        public string FrontChannelLogoutUri { get; set; } /*= "https://localhost:5002/signout-oidc";*/

        [Display(Name = "Post Logout redirect Uri")]
        [StringLength(250)]
        public string PostLogoutRedirectUris { get; set; }/* = "https://localhost:5002/signout-callback-oidc";*/


        public GrantTypes AllowedGrantTypes { get; set; }

        public IEnumerable<string> AllowedScopes { get; set; }

        public GrantTypesEnum GrantTypesEnum { get; set; }
        public string AllowedGrantTypesString { get; set; }
        public string AllowedScopesString { get; set; }
    }
}
