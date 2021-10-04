using AutoMapper;
using IdentityServer.Areas.HeliosAdminUI.Models.UserManagement;
using IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Areas.HeliosAdminUI.Controllers
{
    [Area("HeliosAdminUI")]
    [Authorize(Roles ="IsAdmin")]
    public class UserManagementController : Controller
    {
        private readonly UserManager<ApplicationUser> _userMgr;
        private readonly RoleManager<IdentityRole> _roleMgr;
        private readonly IMapper _mapper;

        public UserManagementController(
            UserManager<ApplicationUser> userMgr,
            RoleManager<IdentityRole> roleMgr,
            IMapper mapper
            )
        {
            _userMgr = userMgr ?? throw new System.ArgumentNullException(nameof(userMgr));
            _roleMgr = roleMgr ?? throw new System.ArgumentNullException(nameof(roleMgr));
            _mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
        }
        // GET: UserManagementController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserHome()
        {
            return View();
        }
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userMgr.Users.ToListAsync();
            var vm = _mapper.Map<List<UserWithRoles>>(users);
            foreach (var user in vm)
            {
                var roles = await _userMgr.GetRolesAsync(new ApplicationUser { Id = user.Id });
                user.Roles = (List<string>)roles;
            }

            return View(vm);
        }

        [HttpGet]
        public ActionResult CreateUser(bool isSuccess = false)
        {
            ViewBag.isSuccess = isSuccess;
           var vm = new CreateUserWithRoleWithViewModel();
           vm.RoleChoices = _roleMgr.Roles.Select(x => x.Name).ToList();

           return View(vm);
        }

        // POST: UserManagementController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(CreateUserWithRoleWithViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = _mapper.Map<ApplicationUser>(model);
            var result = await _userMgr.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                foreach (var role in model.Roles)
                {
                    var roleResult = await _userMgr.AddToRoleAsync(user, role);
                    if (!roleResult.Succeeded)
                    {
                        ModelState.AddModelError(string.Empty, "An error occured while adding this user to his roles. Please contact your administrator.");
                        return View(model);
                    }
                }
            }
            return RedirectToAction(nameof(CreateUser), new { isSuccess = true });
        }

        // GET: UserManagementController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserManagementController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserManagementController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserManagementController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
