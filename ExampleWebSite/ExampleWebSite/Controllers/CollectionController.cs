using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleWebSite.Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using ExampleWebSite.Models;

namespace ExampleWebSite.Controllers
{
    public class CollectionController : Controller
    {
        private readonly ICollectionRepository _collection;
        private readonly IpropertiesRepository _properties;
        private readonly IItemRepository _item;
        private readonly UserManager<User> _userManager;

        public CollectionController(UserManager<User> userManager, IItemRepository item, IpropertiesRepository properties, ICollectionRepository collection)
        {
            _collection = collection;
            _properties = properties;
            _item = item;
            _userManager = userManager;
        }
        // GET: CollectionController
        public async Task<ActionResult> Index()
        {
            return View(await _collection.TakeAllAsync());
        }

        // GET: CollectionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CollectionController/Create
        public ActionResult Create(CollectionModel model)
        {
            return View();
        }

        // POST: CollectionController/Create
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

        // GET: CollectionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CollectionController/Edit/5
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

        // GET: CollectionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CollectionController/Delete/5
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
