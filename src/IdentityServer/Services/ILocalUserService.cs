using IdentityServer.Models;
using IdentityServer.Quickstart.PasswordReset;
using IdentityServer.Quickstart.Register;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public interface ILocalUserService
    {
        Task<IdentityResult> ConfirmEmail(ApplicationUser user, string token);
        Task<string> GenerateResetPasswordEncodedToken(ApplicationUser user);
        Task<string> GenerateRegistrationEncodedToken(ApplicationUser user);
        Task<ApplicationUser> GetUserByEmail(string email);
        Task<RegistrationResponse> RegisterUser(RegisterUserViewModel model);
        Task<IdentityResult> ResetPassword(ResetPasswordViewModel model);
    }
}