using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleWebSite.Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using ExampleWebSite.Models;
using ExampleWebSite.ViewModels;
using ExampleWebSite.Models.AddationalProperts;
using ExampleWebSite.Components.GenerateProperties;

namespace ExampleWebSite.Controllers
{
    public class CollectionController : Controller
    {
        private readonly ICollectionRepository _collection;
        private readonly IpropertiesElementsRepository _properties;
        private readonly IpropertiesModelRepository _propertiesModel;
        private readonly IThemeRepository _Themes;
        private readonly IItemRepository _item;
        private readonly UserManager<User> _userManager;

        public CollectionController(UserManager<User> userManager, IItemRepository item, IpropertiesElementsRepository properties, ICollectionRepository collection,IThemeRepository theme, IpropertiesModelRepository propertiesModel)
        {
            _collection = collection;
            _properties = properties;
            _item = item;
            _userManager = userManager;
            _Themes = theme;
            _propertiesModel = propertiesModel;
        }
        // GET: CollectionController
        public async Task<ActionResult> Index()
        {
            return View(await _collection.TakeAllAsync());
        }

        // GET: CollectionController/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id != null)
            {
                //var Items = await _item.FindByCollectionIdAsync((int)id);
                var collection = await _collection.FindByIdAsync((int)id);

                if(collection!=null)
                {
                    CollectionDetailsViewModel detailsModel = new CollectionDetailsViewModel();
                    detailsModel.collection = collection;
                   // detailsModel.items = Items;
                    return View(detailsModel);
                }
                return NotFound();    
            }
            else
                return NotFound();  
        }

        // GET: CollectionController/Create
        public ActionResult Create(CollectionModel model)
        {
            return View();
            //return RedirectToAction("Error");
        }

        // POST: CollectionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateCollectionViewModel model)
        {
            //try
            //{
                if (ModelState.IsValid)
                {
                    model.collection.Thema = await _Themes.FindByTitleAsync(model.ThemaTitle);
                    await _collection.CreateAsync(model);
                    //var collection = await _collection.FindByTitleAsync(model.collection.Title);

                    Generate generate = new Generate(_collection, _propertiesModel);

                    await generate.GeneratePropertiesAsync(model.collection.Title, model.PropertiesNumTitles, "number");

                    await generate.GeneratePropertiesAsync(model.collection.Title, model.PropertiesStrTitles, "string");

                    await generate.GeneratePropertiesAsync(model.collection.Title, model.PropertiesDateTitles, "date");

                    return RedirectToAction(nameof(Index), "Home");
                }
                else
                {
                    return View(model);
                }

            //}
            //catch
            //{
            //    return RedirectToAction("Privacy", "Home");
            //}
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
