using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Quickstart.PasswordReset
{
    public class ResetPasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [MaxLength(250)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [MaxLength(250)]
        [Compare(nameof(NewPassword))]
        [Display(Name = "Confirm your password")]
        public string ConfirmationPassword { get; set; }

        public string Email { get; set; }
        public string SecurityCode { get; set; }
    }
}
