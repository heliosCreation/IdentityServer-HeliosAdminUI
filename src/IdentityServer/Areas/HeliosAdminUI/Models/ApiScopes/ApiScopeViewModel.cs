using IdentityServer4.EntityFramework.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Areas.HeliosAdminUI.Models.ApiScopes
{
    public class ApiScopeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public bool Required { get; set; }
        public bool Emphasize { get; set; }
        public bool Enabled { get; set; }
        public bool ShowInDiscoveryDocument { get; set; }
        public List<ApiScopeClaim> UserClaims { get; set; }
        public List<ApiScopeProperty> Properties { get; set; }
    }
}
