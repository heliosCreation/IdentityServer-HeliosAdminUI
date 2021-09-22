using IdentityServer4.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Areas.HeliosAdminUI.Models.Clients
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public IEnumerable<string> AllowedGrantTypes { get; set; }
        public string RedirectUris { get; set; }
        public string FrontChannelLogoutUri { get; set; }
        public string PostLogoutRedirectUris { get; set; }
        public IEnumerable<string> AllowedScopes { get; set; }
    }
}
