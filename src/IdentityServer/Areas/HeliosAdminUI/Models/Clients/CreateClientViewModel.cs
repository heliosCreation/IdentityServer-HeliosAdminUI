using IdentityServer.Areas.HeliosAdminUI.Models.Clients.Assets;
using IdentityServer4;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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

        private string _redirectUris;
        [Display(Name = "Redirect Uri")]
        [StringLength(250)]
        public string RedirectUris
        {
            get => _redirectUris;
            set => _redirectUris = String.Format("{0}{1}", value, "/signin-oidc");
        }


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
        public ICollection<string> AllowedGrantTypes
        {
            get
            {
                return string.IsNullOrEmpty(GrantTypesKey) ?
                    new List<string>() :
                    GrantTypesDictionnary.Data[GrantTypesKey];
            }
            set { }
        }

        public SelectList GrantTypesList { get; set; } =
        new SelectList(
            new[]
            {
                        new {Id = "Implicit", Value = "Implicit"},
                        new {Id = "ImplicitAndClientCredentials", Value = "Implicit and client credentials"},
                        new {Id = "Code", Value = "Code"},
                        new {Id = "CodeAndClientCredentials", Value = "Code and client credentials"},
                        new {Id = "Hybrid", Value = "Code"},
                        new {Id = "HybridAndClientCredentials", Value = "Hybrid and client credentials"},
                        new {Id = "ClientCredentials", Value = "Client credentials"},
                        new {Id = "ResourceOwnerPassword", Value = "Resource owner password"},
                        new {Id = "ResourceOwnerPasswordAndClientCredentials", Value = "Resource owner password and client credentials"},
                        new {Id = "DeviceFlow", Value = "Device flow"}
            }, "Id", "Value");
        public string GrantTypesKey { get; set; }

        public IEnumerable<string> StandardScopes = new List<string>()
        {
            IdentityServerConstants.StandardScopes.OpenId,
            IdentityServerConstants.StandardScopes.Profile,
            IdentityServerConstants.StandardScopes.Address,
            IdentityServerConstants.StandardScopes.Email,
            IdentityServerConstants.StandardScopes.Phone,
            IdentityServerConstants.StandardScopes.OfflineAccess,
        };

        public string AllowedScopesString { get; set; }

        public IEnumerable<string> AllowedScopes
        {
            get
            {
                return string.IsNullOrEmpty(AllowedScopesString) ?
                        new List<string>()
                        : AllowedScopesString.Replace(",", " ")
                        .Split(" ").ToList()
                        .Where(c => !string.IsNullOrEmpty(c)).ToList();
            }
            set { }
        }
    }
}
