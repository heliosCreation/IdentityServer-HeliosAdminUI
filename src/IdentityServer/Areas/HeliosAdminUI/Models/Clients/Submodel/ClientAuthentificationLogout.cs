using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Areas.HeliosAdminUI.Models.Clients.Submodel
{
    public class ClientAuthentificationLogout
    {
        private string _frontChannelLogoutUri;
        [Display(Name = "Front Channel Logout Uri")]
        [StringLength(250)]
        public string FrontChannelLogoutUri
        {
            get => _frontChannelLogoutUri;
            set => _frontChannelLogoutUri = String.Format("{0}{1}", value, "/signout-oidc");
        }

        private string _postLogoutRedirectUris;
        [Display(Name = "Post Logout redirect Uri")]
        [StringLength(250)]
        public string PostLogoutRedirectUris
        {
            get => _postLogoutRedirectUris;
            set => _postLogoutRedirectUris = String.Format("{0}{1}", value, "/signout-callback-oidc");
        }

        [Display(Name = "Front channel logout session required")]
        public bool FrontChannelLogoutSessionRequired { get; set; } = true;

        [Display(Name = "Back channel logout uri")]
        public string BackChannelLogoutUri { get; set; }

        [Display(Name = "Back channel logout session required")]
        public bool BackChannelLogoutSessionRequired { get; set; } = true;

        [Display(Name = "Enable local login")]
        public bool EnableLocalLogin { get; set; } = true;
        public ICollection<string> IdentityProviderRestrictions { get; set; }

        [Display(Name = "Identity Provider restriction")]
        public string IdentityProviderRestrictionsString { get; set; }

        [Display(Name = "User Single-sign-on lifetime")]
        public int? UserSsoLifetime { get; set; }
    }
}
