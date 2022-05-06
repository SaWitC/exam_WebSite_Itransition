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
using ExampleWebSite.ViewModels.Collections.Admin;

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

        //page -settings
        private static readonly int PageSize = 4;

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
        public ActionResult Index(int? id=0)
        {
            int page = id ?? 0;
            var isAjax = Request.Headers["X-Requested-With"] == "XMLHttpRequest";
            if (isAjax)
            {
                return PartialView("_writeMoreCollections",GetCollections(page));
            }
            return View(GetCollections(page));
        }

        // GET: CollectionController/Details/5
        public async Task<ActionResult> Details(int? id,int? p)
        {
            int page = p ?? 0;
            var isAjax = Request.Headers["X-Requested-With"] == "XMLHttpRequest";
            if (isAjax&&id!=null)
            {
                var result = GetItemsMinByCollections((int)id, page);
                result.AvtorName = _collection.GetAvtorNameByCollectionId((int)id);
                return PartialView("_writeMoreItems",result);
            }

            if (id != null)
            {
                var collection = await _collection.FindByIdAsync((int)id);

                if (collection!=null)
                {
                    CollectionDetailsViewModel detailsModel = new CollectionDetailsViewModel
                    {
                        ImageUrl = await CollectionImage.GetImageLinkAsync("AQAAAABgW19JAAfYg2ZC-Ml1M0I4vHLmlumOb_c", $"collection_{collection.Id}_", $"logo_{collection.Id}"),

                        collection = collection
                    };
                    detailsModel.items = GetItemsMinByCollections(collection.Id, page).items;
                    detailsModel.AvtorName = collection.AvtorName;

                    return View(detailsModel);
                }
                return NotFound();    
            }
            else
                return NotFound();  
        }

        //create -----------------------------------------------------------------------------
        //[Authorize(Policy= "IsBanedPolicy")]
        [Authorize]
        [HttpGet]
        public ActionResult Create(string AvtorName)
        {
            return View(new CreateCollectionViewModel { AvtorName=AvtorName});
        }

        [HttpPost]
        //[Authorize(Policy = "IsBanedPolicy")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateCollectionViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.collection.Thema = await _Themes.FindByTitleAsync(model.ThemaTitle);

                    if (!User.IsInRole("admin"))
                        model.collection.AvtorName = User.Identity.Name;
                    else if (!string.IsNullOrEmpty(model.AvtorName))
                        model.collection.AvtorName = model.AvtorName;
                    else
                        model.collection.AvtorName = User.Identity.Name;

                    await _collection.CreateAsync(model);
                    //propertiesElements 
                    Generate generate = new Generate(_collection, _propertiesModel);

                    await generate.GeneratePropertiesAsync(model.collection.Title, model.PropertiesNumTitles, "number");
                    await generate.GeneratePropertiesAsync(model.collection.Title, model.PropertiesStrTitles, "string");
                    await generate.GeneratePropertiesAsync(model.collection.Title, model.PropertiesDateTitles, "date");
                    await generate.GeneratePropertiesAsync(model.collection.Title, model.PropertiesBoolTitles, "bool");

                    //yandex disk
                    var Collection = await _collection.FindByTitleAsync(model.collection.Title);

                    if (model.ImageFile != null)
                    {
                        await CollectionImage.UploadImageAsync("AQAAAABgW19JAAfYg2ZC-Ml1M0I4vHLmlumOb_c", $"collection_{Collection.Id}_", model.ImageFile, $"logo_{Collection.Id}");
                        Collection.ImageLink = await CollectionImage.GetImageLinkAsync("AQAAAABgW19JAAfYg2ZC-Ml1M0I4vHLmlumOb_c", $"collection_{Collection.Id}_", $"logo_{Collection.Id}");
                    }
                    await _collection.UpdateAsync(Collection);

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
        [Authorize]
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
        [Authorize]
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
                        if (model.ImageFile != null)
                            await CollectionImage.UploadImageAsync("AQAAAABgW19JAAfYg2ZC-Ml1M0I4vHLmlumOb_c", $"collection_{model.Collectionid}_", model.ImageFile, $"logo_{model.Collectionid}");

                        var collection = await _collection.FindByIdAsync(model.Collectionid);
                        collection.Title = model.Title;
                        collection.ShortDesc = model.ShortDesc;
                        collection.Thema = thema;

                        if (model.ImageFile != null)
                        {
                            await CollectionImage.UploadImageAsync("AQAAAABgW19JAAfYg2ZC-Ml1M0I4vHLmlumOb_c", $"collection_{collection.Id}_", model.ImageFile, $"logo_{collection.Id}");
                            collection.ImageLink = await CollectionImage.GetImageLinkAsync("AQAAAABgW19JAAfYg2ZC-Ml1M0I4vHLmlumOb_c", $"collection_{collection.Id}_", $"logo_{collection.Id}");
                        }
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
        [Authorize]
        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var collection = await _collection.FindByIdAsync((int)id);
                return View(collection);
            }

            return NotFound();

        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Authorize]
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)//edit
        {
            var collection = await _collection.FindByIdAsync(id);
           
            await CollectionImage.DeleteImageAsync("AQAAAABgW19JAAfYg2ZC-Ml1M0I4vHLmlumOb_c", $"collection_{collection.Id}_");
            await _collection.DeleteAsync(collection);
            return RedirectToAction("index", "home");
        }
        //MyCollection --------------------------------------------------------
        [HttpGet]
        [Authorize]
        public IActionResult MyCollection(int?id )
        {
            int page = id ?? 0;
            var isAjax = Request.Headers["X-Requested-With"] == "XMLHttpRequest";
            if (isAjax)
            {
                return PartialView("_writeMoreCollections", GetCollectionsToAvtor(page));
            }
            return View(GetCollectionsToAvtor(page));
        }
        
        public IEnumerable<CollectionMinViewModel> GetCollections(int page=1)
        {
            var CollectionsToSkip = page * PageSize;
            var collectionList= _collection.TakeCollectionMin_Skip(CollectionsToSkip, PageSize);
            return collectionList;
        }
        public IEnumerable<CollectionMinViewModel> GetCollectionsToAvtor(int page = 1)
        {
            var CollectionsToSkip = page * PageSize;
            var collectionList = _collection.TakeCollectionMinByAvtor_Skip(CollectionsToSkip, PageSize, User.Identity.Name);
            return collectionList;
        }

        public CollectionDetailsViewModel GetItemsMinByCollections(int collectionId,int page = 1)
        {
            CollectionDetailsViewModel model = new CollectionDetailsViewModel();
            var ItemToSkip = page * PageSize;
            var ItemList = _item.TakeItemBy_collection(collectionId, ItemToSkip, PageSize);
            model.items = ItemList;
            return model;
        }

        #region Admin
        #endregion
    }
}
