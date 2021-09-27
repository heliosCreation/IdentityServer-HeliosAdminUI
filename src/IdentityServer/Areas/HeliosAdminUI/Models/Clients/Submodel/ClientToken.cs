using IdentityServer4.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Areas.HeliosAdminUI.Models.Clients.Submodel
{
    public class ClientToken
    {
        [Display(Name = "Identity Token Lifetime - in seconds")]
        public int IdentityTokenLifetime { get; set; }

        public ICollection<string> AllowedIdentityTokenSigningAlgorithms { get; set; }

        [Display(Name ="Allowed identity token sign in Algorithms")]
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

        [Display(Name ="Access token type")]
        public AccessTokenType AccessTokenType { get; set; }
        public int AccessTokenTypeValue { get; set; } = 0;

        [Display(Name = "Include JTI")]
        public bool IncludeJwtId { get; set; } = true;

        [Display(Name = "Allowed cors origins")]
        public ICollection<string> AllowedCorsOrigins { get; set; }
        public string AllowedCorsOriginsString { get; set; }

        [Display(Name ="Claims")]
        public ICollection<ClientClaim> Claims { get; set; }
        public string ClaimsString { get; set; }

        [Display(Name ="Always send client claims")]
        public bool AlwaysSendClientClaims { get; set; }

        [Display(Name = "Always Include user claims in Id token")]
        public bool AlwaysIncludeUserClaimsInIdToken { get; set; }

        [Display(Name ="CLient claim prefix")]
        public string ClientClaimsPrefix { get; set; } = "client_";

        [Display(Name = "Pair wise subject salt")]
        public string PairWiseSubjectSalt { get; set; }

    }
}
