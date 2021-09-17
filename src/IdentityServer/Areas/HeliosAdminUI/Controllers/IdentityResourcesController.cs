using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Areas.HeliosAdminUI.Controllers
{
    public class IdentityResourcesController : Controller
    {
        // GET: IdentityResourcesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: IdentityResourcesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: IdentityResourcesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IdentityResourcesController/Create
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

        // GET: IdentityResourcesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: IdentityResourcesController/Edit/5
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

        // GET: IdentityResourcesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: IdentityResourcesController/Delete/5
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
