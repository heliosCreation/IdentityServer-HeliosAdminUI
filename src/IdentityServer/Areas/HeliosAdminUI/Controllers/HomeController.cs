using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Areas.HeliosAdminUI.Controllers
{
    [Area("HeliosAdminUI")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
