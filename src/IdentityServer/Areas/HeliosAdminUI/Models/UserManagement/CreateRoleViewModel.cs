using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Areas.HeliosAdminUI.Models.UserManagement
{
    public class CreateRoleViewModel
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
