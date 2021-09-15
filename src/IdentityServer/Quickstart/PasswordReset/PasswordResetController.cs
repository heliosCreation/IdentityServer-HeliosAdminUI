using IdentityServer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer.Quickstart.PasswordReset
{
    [Route("[controller]")]
    public class PasswordResetController : Controller
    {
        private readonly ILocalUserService _localUserService;

        public PasswordResetController(ILocalUserService localUserService)
        {
            _localUserService = localUserService;
        }

        [HttpGet]
        public IActionResult RequestResetPassword()
        {
            return View(new RequestResetPasswordViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RequestResetPassword(RequestResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _localUserService.GetUserByEmail(model.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "There was an error with the provided e-mail.");
                return View(model);
            }


            var securityCode = await _localUserService.GenerateResetPasswordEncodedToken(user);
            var callbackLink = Url.ActionLink("ResetPassword", "PasswordReset", new { Email = user.Email, securityCode = securityCode });

            //Temp
            Console.WriteLine(callbackLink);

            //TODO: Add email service.
            //await _emailSender.SendEmailAsync(Input.Email, "Password reset",
            //    $"Finalize your password modification by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
            return View("RequestPasswordResetSent");
        }

        [Route("ResetPassword")]
        [HttpGet]
        public IActionResult ResetPassword(string email, string securityCode)
        {
            //securityCode = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(securityCode));

            var vm = new ResetPasswordViewModel() { Email = email, SecurityCode = securityCode };
            return View(vm);
        }

        [Route("ResetPassword")]
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            var result = await _localUserService.ResetPassword(model);
            return View(result.Succeeded ? "ResetPasswordResult" : "Error");
        }
    }
}
