using IdentityServer.Areas.HeliosAdminUI.Dictionnary.Clients;
using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace IdentityServer.Areas.HeliosAdminUI.Models.Clients
{
    public class CreateClientViewModel
    {
        #region Basics
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
        public string ClientSecrets { get; set; }

        public bool Enable { get; set; } = true;
        public bool RequireClientSecret { get; set; } = true;
        public bool RequireRequestObject { get; set; } = false;
        public bool RequirePkce { get; set; } = true;
        public bool AllowPlainTextPkce { get; set; } = false;

        [Display(Name ="Allow Offline Access")]
        public bool AllowOfflineAccess { get; set; }
        public bool AllowAccessTokensViaBrowser { get; set; } = false;

        private string _redirectUris;
        [Display(Name = "Redirect Uri")]
        [StringLength(250)]
        public string RedirectUris
        {
            get => _redirectUris;
            set => _redirectUris = String.Format("{0}{1}", value, "/signin-oidc");
        }

        [Display(Name = "Allowed grant type")]
        public ICollection<string> AllowedGrantTypes
        {
            get
            {
                return string.IsNullOrEmpty(GrantTypesKey) ?
                    new List<string>() :
                    GrantTypesDictionary.Data[GrantTypesKey];
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
                        new {Id = "Hybrid", Value = "Hybrid"},
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

        [Display(Name = "Allowed scopes")]
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

        #endregion

        #region Token
        [Display(Name = "Identity Token Lifetime - in seconds")]
        public int IdentityTokenLifetime { get; set; }

        public ICollection<string> AllowedIdentityTokenSigningAlgorithms { get; set; }

        [Display(Name = "Allowed identity token sign in Algorithms")]
        public string AllowedIdentityTokenSigningAlgorithmsString { get; set; }

        [Display(Name = "Access Token Lifetime - in seconds")]
        public int AccessTokenLifetime { get; set; } = 3600;

        [Display(Name = "Authorization code Lifetime - in seconds")]
        public int AuthorizationCodeLifetime { get; set; } = 300;

        [Display(Name = "Absolute refresh token  Lifetime - in seconds")]
        public int AbsoluteRefreshTokenLifetime { get; set; } = 2592000;

        [Display(Name = "Sliding refresh token  Lifetime - in seconds")]
        public int SlidingRefreshTokenLifetime { get; set; } = 2592000;

        [Display(Name = "Refresh Token usage")]
        public TokenUsage RefreshTokenUsage { get; set; }
        public int RefreshTokenUsageValue { get; set; } = 1;

        [Display(Name = "Refresh Token expiration")]
        public TokenExpiration RefreshTokenExpiration { get; set; }
        public int RefreshTokenExpirationValue { get; set; } = 0;

        [Display(Name = "Update access token on refresh  ")]
        public bool UpdateAccessTokenClaimsOnRefresh { get; set; } = false;

        [Display(Name = "Access token type")]
        public AccessTokenType AccessTokenType { get; set; }
        public int AccessTokenTypeValue { get; set; } = 0;

        [Display(Name = "Include JTI")]
        public bool IncludeJwtId { get; set; } = true;

        [Display(Name = "Allowed cors origins")]
        public ICollection<string> AllowedCorsOrigins { get; set; }
        public string AllowedCorsOriginsString { get; set; }

        [Display(Name = "Claims")]
        public ICollection<ClientClaim> Claims { get; set; }
        public string ClaimsString { get; set; }

        [Display(Name = "Always send client claims")]
        public bool AlwaysSendClientClaims { get; set; }

        [Display(Name = "Always Include user claims in Id token")]
        public bool AlwaysIncludeUserClaimsInIdToken { get; set; }

        [Display(Name = "CLient claim prefix")]
        public string ClientClaimsPrefix { get; set; } = "client_";

        [Display(Name = "Pair wise subject salt")]
        public string PairWiseSubjectSalt { get; set; }
        #endregion

        #region Authentication&Logout
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
        #endregion

        #region ConsentScreen
        [Display(Name = "Require consent screen")]
        public bool RequireConsent { get; set; } = false;

        [Display(Name = "Allow to remember consent")]
        public bool AllowRememberConsent { get; set; } = true;

        [Display(Name = "Consent Lifetime - in seconds")]
        public int? ConsentLifetime { get; set; }

        [Display(Name = "Client Uri")]
        [StringLength(250)]
        public string ClientUri { get; set; }

        [Display(Name = "Client logo uri")]
        [StringLength(250)]
        public string LogoUri { get; set; }
        #endregion
    }
}
