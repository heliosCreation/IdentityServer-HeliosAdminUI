using IdentityServer.Areas.HeliosAdminUI.Helpers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Areas.HeliosAdminUI.Models.UserManagement
{
    public class CreateUserWithRoleWithViewModel
    {
        [Required]
        [Display(Name = "The Username")]
        [StringLength(250)]
        public string UserName { get; set; }

        [Required]
        [StringLength(250)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [StringLength(250)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmationPassword { get; set; }

        [Required]
        [StringLength(250)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name ="Email confirmed ? ")]
        public bool EmailConfirmed { get; set; } = false; 

        public List<string> Roles
        {
            get { return string.IsNullOrEmpty(RolesString) ? new List<string>() : UserRolesHelper.CreateRoles(RolesString); }
            set {}
        }

        [Display(Name ="Roles")]
        [StringLength(250)]
        public string RolesString { get; set; }
        public List<string> RoleChoices { get; set; }
    }
}
