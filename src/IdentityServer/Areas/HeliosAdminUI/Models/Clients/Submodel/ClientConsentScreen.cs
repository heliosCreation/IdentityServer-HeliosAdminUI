using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Areas.HeliosAdminUI.Models.Clients.Submodel
{
    public class ClientConsentScreen
    {
        [Display(Name = "Require consent screen")]
        public bool RequireConsent { get; set; } = false;

        [Display(Name = "Allow to remember consent")]
        public bool AllowRememberConsent { get; set; } = true;

        [Display(Name = "Consent Lifetime - in seconds")]
        public int? ConsentLifetime { get; set; }

        [Display(Name ="Client Uri")]
        [StringLength(250)]
        public string ClientUri { get; set; }

        [Display(Name ="Client logo uri")]
        [StringLength(250)]
        public string LogoUri { get; set; }
    }
}
