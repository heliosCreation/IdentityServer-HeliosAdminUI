using System;
using System.Collections.Generic;

namespace IdentityServer.Areas.HeliosAdminUI.Models.UserManagement
{
    public class UserWithRoles
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTimeOffset LockoutEnd { get; set; }
        public List<string> Roles { get; set; }
    }
}
