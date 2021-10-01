using AutoMapper;
using IdentityServer.Areas.HeliosAdminUI.Models.ApiScopes;
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
    public class ApiScopesController : Controller
    {
        private readonly IApiScopeRepository _apiScopeRepository;
        private readonly IMapper _mapper;

        public ApiScopesController(IApiScopeRepository apiScopeRepository, IMapper mapper)
        {
            _apiScopeRepository = apiScopeRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> GetAll(bool isSuccess, bool error = false)
        {
            ViewBag.Error = error;
            ViewBag.isSuccess = isSuccess;

            var apiScopes = await _apiScopeRepository.GetAllAsync();
            var vmProp = _mapper.Map<List<ApiScopeViewModel>>(apiScopes);
            var vm = new ApiScopesListViewModel() { ApiScopes = vmProp };
            return View(vm);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create(bool isSuccess = false)
        {
            ViewBag.isSuccess = isSuccess;
            return View(new CreateApiScopeModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateApiScopeModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var entity = _mapper.Map<ApiScope>(model);
            var created = await _apiScopeRepository.AddAsync(entity);

            if (created)
            {
                return RedirectToAction(nameof(Create), new { isSuccess = true });
            }

            ModelState.AddModelError(string.Empty, "An error occured while adding your api scope. Please contact your administrator.");
            return View(model);

        }

        public async Task<IActionResult> Edit(int id)
        {
            var entity = await _apiScopeRepository.GetByIdAsync(id);
            if (!(entity != null))
            {
                return RedirectToAction(nameof(GetAll), new { Error = true });
            }
            var vm = _mapper.Map<UpdateApiScopeViewModel>(entity);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateApiScopeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.Id != id)
            {
                return RedirectToAction(nameof(GetAll), new { Error = true });
            }
            var entity = _mapper.Map<ApiScope>(model);
            var updated = await _apiScopeRepository.UpdateAsync(entity);
            if (!updated)
            {
                ModelState.AddModelError(string.Empty, "An error occured while updating your api scope. Please contact your administrator.");
                return View(model);
            }

            return RedirectToAction(nameof(GetAll), new { isSuccess = true });
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var entity = await _apiScopeRepository.GetByIdAsync(id.Value);
            if (entity == null)
            {
                return NotFound();
            }
            var vm = _mapper.Map<ApiScopeViewModel>(entity);
            return View(vm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entity = await _apiScopeRepository.GetByIdAsync(id);
            var deleted = await _apiScopeRepository.DeleteAsync(entity);
            if (!deleted)
            {
                return RedirectToAction(nameof(GetAll), new { Error = true });
            }
            return RedirectToAction(nameof(GetAll), new { isSuccess = true });
        }
    }
}
