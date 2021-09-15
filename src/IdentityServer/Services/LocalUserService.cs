using IdentityModel;
using IdentityServer.Models;
using IdentityServer.Quickstart.PasswordReset;
using IdentityServer.Quickstart.Register;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public class LocalUserService : ILocalUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LocalUserService> _logger;


        public LocalUserService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<LocalUserService> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        public async Task<ApplicationUser> GetUserByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<RegistrationResponse> RegisterUser(RegisterUserViewModel model)
        {
            var user = new ApplicationUser()
            {
                UserName = model.Username,
                Email = model.Email,
                EmailConfirmed = false
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                _logger.LogInformation("Error while creating a new user.");
                return new RegistrationResponse(result);
            }

            result = await _userManager.AddClaimsAsync(user, new Claim[]{
                        new Claim(JwtClaimTypes.Address, model.Address),
                        new Claim("country", model.Country),
                    });

            if (!result.Succeeded)
            {
                _logger.LogInformation("Error while adding claims to new user.");
                return new RegistrationResponse(result);
            }
            _logger.LogInformation("User created a new account with password.");
            return new RegistrationResponse(result, user);
        }

        public async Task<string> GenerateResetPasswordEncodedToken(ApplicationUser user)
        {
            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }

        //public async Task<SignInResult> SignInPasswordAsync(LoginModel login)
        //{
        //    ApplicationUserModel signedUser = await _userManager.FindByEmailAsync(login.Email);
        //    var result = await _signInManager.PasswordSignInAsync(signedUser, login.Password, login.RememberMe, false);
        //    return result;
        //}

        //public async Task SignOutAsync()
        //{
        //    await _signInManager.SignOutAsync();
        //}


        public async Task<IdentityResult> ResetPassword(ResetPasswordViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            var result =  await _userManager.ResetPasswordAsync(user, model.SecurityCode, model.NewPassword);
            return result; 
        }

        public async Task<IdentityResult> ConfirmEmail(ApplicationUser user, string token)
        {
            return await _userManager.ConfirmEmailAsync(user, token);
        }

        public async Task<string> GenerateRegistrationEncodedToken(ApplicationUser user)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            return WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        }

        //private async Task SendConfirmationMail(ApplicationUserModel user, string token)
        //{
        //    string appDomain = _configuration.GetSection("Application:AppDomain").Value;
        //    string confirmationUrl = _configuration.GetSection("Application:EmailConfirmation").Value;
        //    EmailOptions emailOptions = new EmailOptions
        //    {
        //        DestinationAdressess = new List<string>() { user.Email },
        //        PlaceHolders = new List<KeyValuePair<string, string>>()
        //        {
        //            new KeyValuePair<string, string>("{{Username}}", user.FirstName),
        //            //"confirm-email?uid={0}&token={1}"
        //            new KeyValuePair<string, string>("{{ConfirmationLink}}",  string.Format(appDomain+confirmationUrl,user.Id, token))
        //        }
        //    };

        //    await _emailService.SendConfirmationMail(emailOptions);
        //}


        //private async Task SendForgottenPasswordMail(ApplicationUserModel user, string token)
        //{
        //    string appDomain = _configuration.GetSection("Application:AppDomain").Value;
        //    string confirmationUrl = _configuration.GetSection("Application:ForgotPassword").Value;
        //    EmailOptions emailOptions = new EmailOptions
        //    {
        //        DestinationAdressess = new List<string>() { user.Email },
        //        PlaceHolders = new List<KeyValuePair<string, string>>()
        //        {
        //            new KeyValuePair<string, string>("{{Username}}", user.FirstName),
        //            //"confirm-email?uid={0}&token={1}"
        //            new KeyValuePair<string, string>("{{ConfirmationLink}}",  string.Format(appDomain+confirmationUrl,user.Id, token))
        //        }
        //    };

        //    await _emailService.SendPasswordForgottenMail(emailOptions);
        //}
    }
}
