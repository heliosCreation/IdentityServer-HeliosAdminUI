using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Quickstart.PasswordReset
{
    public class RequestResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [MaxLength(250)]
        public string Email { get; set; }
    }
}
