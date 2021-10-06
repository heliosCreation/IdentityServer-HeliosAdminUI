using AutoMapper;
using IdentityServer.Areas.HeliosAdminUI.Models.UserManagement;
using IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Areas.HeliosAdminUI.Controllers
{
    [Area("HeliosAdminUI")]
    [Authorize(Roles = "IsAdmin")]
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

        public ActionResult RoleHome()
        {
            return View();
        }


        public async Task<IActionResult> GetAllUsers(bool isSuccess = false, bool error = false)
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.error = error;

            var users = await _userMgr.Users.ToListAsync();
            var vm = _mapper.Map<List<UserWithRoles>>(users);
            foreach (var user in vm)
            {
                var roles = await _userMgr.GetRolesAsync(new ApplicationUser { Id = user.Id });
                user.Roles = (List<string>)roles;
            }

            return View(vm);
        }

        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _roleMgr.Roles.ToListAsync();
            var vm = new List<RoleViewModel>();
            foreach (var role in roles)
            {
                vm.Add(new RoleViewModel
                {
                    Id = role.Id,
                    Name = role.Name
                });
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

        [HttpGet]
        public ActionResult CreateRole(bool isSuccess = false)
        {
            ViewBag.isSuccess = isSuccess;
            var vm = new CreateRoleViewModel();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(CreateUserWithRoleWithViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = _mapper.Map<ApplicationUser>(model);
            var EmailExist = await _userMgr.FindByEmailAsync(user.Email);
            var nameExist = await _userMgr.FindByNameAsync(user.UserName);
            if (EmailExist != null || nameExist != null)
            {
                ViewBag.error = true;
                ModelState.AddModelError(string.Empty, "User with given Username/Email already exist.");
                model.RoleChoices = _roleMgr.Roles.Select(x => x.Name).ToList();
                return View(model);
            }
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var roleExist = await _roleMgr.RoleExistsAsync(model.Name);
            if (!roleExist)
            {
                var result = await _roleMgr.CreateAsync(new IdentityRole(model.Name));
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(CreateRole), new { isSuccess = true });
                }
                return RedirectToAction(nameof(GetAllRoles), new { error = true });

            }
            ViewBag.error = true;
            ModelState.AddModelError(string.Empty, "A role with this Name already exist");
            return View(model);

        }
        public async Task<IActionResult> EditUserRoles(string id, bool isSuccess = false, bool error = false)
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.error = error;

            var user = await _userMgr.FindByIdAsync(id);
            var vm = _mapper.Map<UpdateUseRolesViewModel>(user);

            var roles = _roleMgr.Roles.Select(x => x.Name);
            vm.RoleChoices = _roleMgr.Roles.Select(x => x.Name).ToList();
            vm.RolesString = string.Join(",", await _userMgr.GetRolesAsync(user));

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUserRoles(string id, UpdateUseRolesViewModel model)
        {

            var user = await _userMgr.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var DBroles = await _userMgr.GetRolesAsync(user);
            var roleRemoveResult = await _userMgr.RemoveFromRolesAsync(user, DBroles);
            if (!roleRemoveResult.Succeeded)
            {
                return RedirectToAction(nameof(EditUserRoles), new { error = true });
            }

            var addToRoleResult = await _userMgr.AddToRolesAsync(user, model.Roles);
            if (!roleRemoveResult.Succeeded)
            {
                return RedirectToAction(nameof(EditUserRoles), new { error = true });
            }
            return RedirectToAction(nameof(GetAllUsers), new { isSuccess = true });

        }

        [HttpGet]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var entity = await _userMgr.FindByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            var vm = _mapper.Map<UserWithRoles>(entity);
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var entity = await _roleMgr.FindByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            var vm = new RoleViewModel()
            {
                Id = entity.Id,
                Name = entity.Name
            };
            return View(vm);
        }

        [HttpPost, ActionName("DeleteUser")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUserConfirmed(string id)
        {
            var user = await _userMgr.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var deleted = await _userMgr.DeleteAsync(user);
            if (deleted.Succeeded)
            {
                return RedirectToAction(nameof(GetAllUsers), new { isSuccess = true });
            }
            return RedirectToAction(nameof(GetAllUsers), new { error = true });
        }

        [HttpPost, ActionName("DeleteRole")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRoleConfirmed(string id)
        {
            var entity = await _roleMgr.FindByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            var result = await _roleMgr.DeleteAsync(entity);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(GetAllRoles), new { isSuccess = true });
            }
            return RedirectToAction(nameof(GetAllRoles), new { error = true });

        }
    }
}
