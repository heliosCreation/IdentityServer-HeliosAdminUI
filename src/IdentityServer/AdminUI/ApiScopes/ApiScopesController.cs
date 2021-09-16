using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.AdminUI.ApiScopes
{
    public class ApiScopesController : Controller
    {
        // GET: ApiScopesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ApiScopesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ApiScopesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApiScopesController/Create
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

        // GET: ApiScopesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ApiScopesController/Edit/5
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

        // GET: ApiScopesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ApiScopesController/Delete/5
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
