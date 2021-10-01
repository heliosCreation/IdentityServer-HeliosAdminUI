using AutoMapper;
using IdentityServer.Areas.HeliosAdminUI.Helpers;
using IdentityServer.Areas.HeliosAdminUI.Models.IdentityResources;
using IdentityServer.Areas.HeliosAdminUI.Services.Contracts;
using IdentityServer4.EntityFramework.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityServer.Areas.HeliosAdminUI.Controllers
{
    [Area("HeliosAdminUI")]
    [Authorize(Roles = "IsAdmin")]
    public class IdentityResourcesController : Controller
    {
        private readonly IIdentityResourceRepository _identityResourceRepository;
        private readonly IMapper _mapper;

        public IdentityResourcesController(IIdentityResourceRepository identityResourceRepository, IMapper mapper)
        {
            _identityResourceRepository = identityResourceRepository;
            _mapper = mapper;
        }
        // GET: IdentityResourcesController
        public ActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetAll(bool isSuccess = false)
        {
            ViewBag.isSuccess = isSuccess;
            var entities = await _identityResourceRepository.GetAllAsync();
            var vmProp = _mapper.Map<List<IdentityResourceViewModel>>(entities);
            var vm = new IdentityResourceListViewModel() { IdentityResourcesList = vmProp };
            return View(vm);
        }

        // GET: IdentityResourcesController/Create
        public ActionResult Create(bool isSuccess = false)
        {
            ViewBag.isSuccess = isSuccess;
            var vm = new CreateIdentityResourceViewModel();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateIdentityResourceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var entity = _mapper.Map<IdentityResource>(model);
            var created = await _identityResourceRepository.AddAsync(entity);
            if (created)
            {
                return RedirectToAction(nameof(Create), new { isSuccess = true });
            }
            ModelState.AddModelError(string.Empty, "An error occured while adding your api scope. Please contact your administrator.");
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var entity = await _identityResourceRepository.GetByIdAsync(id);
            if (!(entity != null))
            {
                return RedirectToAction(nameof(GetAll), new { Error = true });
            }
            var vm = _mapper.Map<UpdateIdentityResourceViewModel>(entity);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateIdentityResourceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.Id != id)
            {
                return RedirectToAction(nameof(GetAll), new { Error = true });
            }
            model.UserClaims = IdentityResourceClaimsHelper.CreateClaims(model.UserClaimsString, model.Id);
            var entity = _mapper.Map<IdentityResource>(model);
            var updated = await _identityResourceRepository.UpdateAsync(entity);
            if (!updated)
            {
                ModelState.AddModelError(string.Empty, "An error occured while updating your api scope. Please contact your administrator.");
                return View(model);
            }

            return RedirectToAction(nameof(GetAll), new { isSuccess = true });
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await _identityResourceRepository.GetByIdAsync(id.Value);
            if (entity == null)
            {
                return NotFound();
            }
            var vm = _mapper.Map<IdentityResourceViewModel>(entity);
            return View(vm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entity = await _identityResourceRepository.GetByIdAsync(id);
            var deleted = await _identityResourceRepository.DeleteAsync(entity);
            if (!deleted)
            {
                return RedirectToAction(nameof(GetAll), new { Error = true });
            }
            return RedirectToAction(nameof(GetAll), new { isSuccess = true });
        }
    }
}
