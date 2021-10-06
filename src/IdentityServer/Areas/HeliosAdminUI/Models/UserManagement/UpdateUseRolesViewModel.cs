using IdentityServer.Areas.HeliosAdminUI.Helpers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Areas.HeliosAdminUI.Models.UserManagement
{
    public class UpdateUseRolesViewModel
    {
        [Editable(false)]
        public string Id { get; set; }
        public List<string> Roles
        {
            get { return string.IsNullOrEmpty(RolesString) ? new List<string>() : UserRolesHelper.CreateRoles(RolesString); }
            set { }
        }

        [Display(Name = "Roles")]
        [StringLength(250)]
        public string RolesString { get; set; }
        public List<string> RoleChoices { get; set; }
    }
}
