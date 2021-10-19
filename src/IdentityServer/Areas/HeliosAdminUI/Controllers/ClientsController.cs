using AutoMapper;
using IdentityServer.Areas.HeliosAdminUI.Models.Clients;
using IdentityServer.Areas.HeliosAdminUI.Services.Contracts;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Is4Mapper = IdentityServer4.EntityFramework.Mappers;

namespace IdentityServer.Areas.HeliosAdminUI.Controllers
{
    [Area("HeliosAdminUI")]
    [Authorize(Roles = "IsAdmin")]
    public class ClientsController : Controller
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientsController(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        public ActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetAll(bool isSuccess, bool error = false)
        {
            ViewBag.Error = error;
            ViewBag.isSuccess = isSuccess;

            var clients = await _clientRepository.GetAllAsync();
            var vm = _mapper.Map<List<ClientViewModel>>(clients);
            return View(vm);
        }

        public async Task<IActionResult> Details(int id)
        {
            var entity = await _clientRepository.GetByIdAsync(id);
            var vm = _mapper.Map<ClientViewModel>(entity);
            return View(vm);
        }

        public ActionResult Create(bool isSuccess)
        {
            ViewBag.isSuccess = isSuccess;

            var vm = new CreateClientViewModel();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateClientViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var modelEntity = _mapper.Map<Client>(model);
            var entity = Is4Mapper.ClientMappers.ToEntity(modelEntity);
            var created = await _clientRepository.AddAsync(entity);

            if (created)
            {
                return RedirectToAction(nameof(Create), new { isSuccess = true });
            }

            ModelState.AddModelError(string.Empty, "An error occured while adding your Client. Please contact your administrator.");
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var entity = await _clientRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            var vm = _mapper.Map<UpdateClientViewModel>(entity);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateClientViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var modelEntity = _mapper.Map<Client>(model);
            var entity = Is4Mapper.ClientMappers.ToEntity(modelEntity);
            var updated = await _clientRepository.UpdateAsync(model.Id, entity);

            if (updated)
            {
                return RedirectToAction(nameof(GetAll), new { isSuccess = true });
            }

            ModelState.AddModelError(string.Empty, "An error occured while adding your Client. Please contact your administrator.");
            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var entity = await _clientRepository.GetByIdAsync(id.Value);
            if (entity == null)
            {
                return NotFound();
            }
            var vm = _mapper.Map<ClientViewModel>(entity);
            return View(vm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entity = await _clientRepository.GetByIdAsync(id);
            var deleted = await _clientRepository.DeleteAsync(entity);
            if (!deleted)
            {
                return RedirectToAction(nameof(GetAll), new { Error = true });
            }
            return RedirectToAction(nameof(GetAll), new { isSuccess = true });
        }
    }
}
