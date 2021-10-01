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

        // GET: UserManagementController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserManagementController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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
