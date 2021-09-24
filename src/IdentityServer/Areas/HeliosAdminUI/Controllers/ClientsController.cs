using AutoMapper;
using IdentityServer.Areas.HeliosAdminUI.Models.Clients;
using IdentityServer.Areas.HeliosAdminUI.Services.Contracts;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities = IdentityServer4.EntityFramework.Entities;
using Is4Mapper = IdentityServer4.EntityFramework.Mappers; 

namespace IdentityServer.Areas.HeliosAdminUI.Controllers
{
    [Area("HeliosAdminUI")]
    public class ClientsController : Controller
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientsController(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        // GET: ClientsController
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

        // GET: ClientsController/Create
        public ActionResult Create()
        {
            var vm = new CreateClientViewModel();
            return View(vm);
        }

        // POST: ClientsController/Create
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

            ModelState.AddModelError(string.Empty, "An error occured while adding your api scope. Please contact your administrator.");
            return View(model);
        }

        // GET: ClientsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClientsController/Edit/5
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

        // GET: ClientsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientsController/Delete/5
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
