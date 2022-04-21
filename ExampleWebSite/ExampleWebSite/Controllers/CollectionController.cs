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
using Microsoft.AspNetCore.Authorization;
using ExampleWebSite.Components.YandexDisk;

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
                var collection = await _collection.FindByIdAsync((int)id);

                if(collection!=null)
                {
                    CollectionDetailsViewModel detailsModel = new CollectionDetailsViewModel();
                    var link = await CollectionImage.GetImageLinkAsync("AQAAAABgW19JAAfYg2ZC-Ml1M0I4vHLmlumOb_c", $"collection_{collection.Id}_", $"logo_{collection.Id}");
                    detailsModel.ImageUrl = link.Href;

                    detailsModel.collection = collection;
                    detailsModel.collection.Items = await _item.FindByCollectionIdAsync((int)id);

                    return View(detailsModel);
                }
                return NotFound();    
            }
            else
                return NotFound();  
        }

        //create -----------------------------------------------------------------------------
        [Authorize]
        [HttpGet]
        public ActionResult Create(CollectionModel model)
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateCollectionViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.collection.Thema = await _Themes.FindByTitleAsync(model.ThemaTitle);
                    model.collection.AvtorName = User.Identity.Name;
                    await _collection.CreateAsync(model);
                    //propertiesElements 
                    Generate generate = new Generate(_collection, _propertiesModel);

                    await generate.GeneratePropertiesAsync(model.collection.Title, model.PropertiesNumTitles, "number");
                    await generate.GeneratePropertiesAsync(model.collection.Title, model.PropertiesStrTitles, "string");
                    await generate.GeneratePropertiesAsync(model.collection.Title, model.PropertiesDateTitles, "date");
                    //yandex disk
                    var Collection = await _collection.FindByTitleAsync(model.collection.Title);

                    await CollectionImage.UploadImageAsync("AQAAAABgW19JAAfYg2ZC-Ml1M0I4vHLmlumOb_c",$"collection_{Collection.Id}_",model.ImageFile,$"logo_{Collection.Id}");

                    return RedirectToAction(nameof(Index), "Home");
                }
                else
                {
                    return View(model);
                }
            }
            catch
            {
                return RedirectToAction("Privacy", "Home");
            }
        }
        
        //edit -------------------------------------------------------------------------
        [HttpGet]
        public async Task<ActionResult> Edit(int? collectionid)
        {
            if (collectionid != null)
            {    
                EditCollectionViewModel collectionViewModel = new EditCollectionViewModel();
                var oldModel = await _collection.FindByIdAsync((int)collectionid);

                collectionViewModel.Title = oldModel.Title;
                collectionViewModel.ShortDesc = oldModel.ShortDesc;
                collectionViewModel.Collectionid = (int)collectionid;

                return View(collectionViewModel);
            }
            else return NotFound();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditCollectionViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var thema = await _Themes.FindByTitleAsync(model.ThemaTitle);
                    if (thema != null)
                    {
                        await CollectionImage.UploadImageAsync("AQAAAABgW19JAAfYg2ZC-Ml1M0I4vHLmlumOb_c", $"collection_{model.Collectionid}_", model.ImageFile, $"logo_{model.Collectionid}");

                        var collection = await _collection.FindByIdAsync(model.Collectionid);
                        collection.Title = model.Title;
                        collection.ShortDesc = model.ShortDesc;
                        collection.Thema = thema;

                        await _collection.UpdateAsync(collection);
                        return RedirectToAction("MyCollection", "Collection");
                    }
                    else return NotFound();
                }
                else return View(model);
            }
            catch
            {
                return RedirectToAction("index", "home");
            }
        }

        //delete -------------------------------------------------------------
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
        //MyCollection --------------------------------------------------------
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> MyCollection()
        {
            var collections = await _collection.FindByAvtorIdAsync(User.Identity.Name);
            return View(collections);
        }

        public async Task<IActionResult> FindCollection()
        {
            return View();
        }
    }
}
