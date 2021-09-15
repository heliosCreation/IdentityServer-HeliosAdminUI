using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Quickstart.Register
{
    public class RegisterUserViewModel
    {
        [Required]
        [MaxLength(250)]
        public string Username { get; set; }

        [Required]
        [MaxLength(250)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(250)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        [Display(Name = "Password confirmation")]
        public string PasswordConfirmation { get; set; }

        [Required]
        [MaxLength(250)]
        [Display(Name = "Given name")]

        public string GivenName { get; set; }

        [Required]
        [MaxLength(250)]
        [Display(Name = "Family name")]
        public string FamilyName { get; set; }

        [Required]
        [MaxLength(250)]
        public string Address { get; set; }

        [Required]
        [MaxLength(250)]
        public string Country { get; set; }
        public SelectList CountryCodes { get; set; } =
            new SelectList(
                new[]
                {
                    new {Id = "En", Value = "England"},
                    new {Id = "Fr", Value = "France"},
                    new {Id = "Nc", Value = "New Caledonia"}
                }, "Id", "Value");

    }
}
