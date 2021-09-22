using AutoMapper;
using IdentityServer.Areas.HeliosAdminUI.Models.Clients;
using IdentityServer.Areas.HeliosAdminUI.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
