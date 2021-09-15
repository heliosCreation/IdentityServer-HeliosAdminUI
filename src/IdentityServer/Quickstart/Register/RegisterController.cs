using IdentityServer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer.Quickstart.Register
{
    [Route("[controller]")]
    public class RegisterController : Controller
    {
        private readonly ILocalUserService _localUserService;

        public RegisterController(ILocalUserService localUserService)
        {
            _localUserService = localUserService;
        }


        [HttpGet]
        public IActionResult RegisterUser()
        {
            return View(new RegisterUserViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterUser(RegisterUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var response = await _localUserService.RegisterUser(model);
            if (!response.Result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, response.Result.Errors.First().Description);
                return View(model);
            }

            var code = await _localUserService.GenerateRegistrationEncodedToken(response.User);
            var callbackLink = Url.ActionLink("ConfirmEmail", "Register", new { Email = response.User.Email, code = code });

            //Temp
            Console.WriteLine(callbackLink);

            //TODO: Add email service.
            //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
            //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
            return View("RegistrationSucceeded");
        }
        [Route("registerSuccess")]
        [HttpGet]
        public IActionResult RegistrationSucceeded()
        {
            return View();
        }

        [Route("ConfirmEmail")]
        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string email, string code, string returnUrl)
        {
            var user = await _localUserService.GetUserByEmail(email);
            if (user == null)
                return View("Error");
            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await _localUserService.ConfirmEmail(user, code);
            return View(result.Succeeded ? nameof(ConfirmEmail) : "Error");
        }
    }
}
