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
using Microsoft.Extensions.Options;
using ExampleWebSite.Data.ConfigurationModels;
using ExampleWebSite.ViewModels.Collections;
using ExampleWebSite.Models.ModelsForProcessing;

namespace ExampleWebSite.Controllers
{
    public class CollectionController : Controller
    {
        private readonly ICollectionRepository _collection;
        private readonly IpropertiesElementsRepository _properties;
        private readonly IpropertiesModelRepository _propertiesModel;
        private readonly IThemeRepository _Themes;
        private readonly IItemRepository _item;
        private readonly IOptions<AppConfigDataModel> _options;

        private static int CollectionSize;
        private static int ItemSize;
        private static string YandexToken;

        public CollectionController(UserManager<User> userManager,
            IItemRepository item, 
            IpropertiesElementsRepository properties, 
            ICollectionRepository collection,
            IThemeRepository theme,
            IpropertiesModelRepository propertiesModel,
            IOptions<AppConfigDataModel> options)
        {   
            _options = options;
            _collection = collection;
            _properties = properties;
            _item = item;
            _Themes = theme;
            _propertiesModel = propertiesModel;

            CollectionSize = int.Parse(_options.Value.CollectionSize);
            ItemSize = int.Parse(_options.Value.ItemSize);
            YandexToken = _options.Value.YandexToken;
        }

        public IActionResult Index()
        {
            try
            {
                CollectionDetailsViewModel model = _collection.GetCollectionWithMaxItims();
                model.items = GetItemsMinByCollections(model.collection.Id, 0).items;
                return View(model);
                //return View(model);
            }
            catch
            {
                return View(null);
            }
        }
        public ActionResult Collections(int? id=0)
        {
            int page = id ?? 0;
            var isAjax = Request.Headers["X-Requested-With"] == "XMLHttpRequest";
            if (isAjax)
            {
                return PartialView("_writeMoreCollections",GetCollections(page));
            }
            return View(GetCollections(page));
        }

        public async Task<ActionResult> Details(int? id,int? p,ItemFilterModel model)
        {
            if (id != null)
            {
                int page = p ?? 0;
                var isAjax = Request.Headers["X-Requested-With"] == "XMLHttpRequest";
                if (isAjax && id != null)
                {
                    if (model.Title != "" || model.Sort != null || model.DateTo != null || model.DateFrom != null)
                    {
                        var result = await FilterItemByCollectionId(model, (int)id, page);
                        result.AvtorName = _collection.GetAvtorNameByCollectionId((int)id);
                        return PartialView("_writeMoreItems", result);
                    }
                    else
                    {
                        var result = GetItemsMinByCollections((int)id, page);
                        result.AvtorName = _collection.GetAvtorNameByCollectionId((int)id);
                        return PartialView("_writeMoreItems", result);
                    }
                }

                var collection = await _collection.FindByIdAsync((int)id);

                if (collection!=null)
                {
                    CollectionDetailsViewModel detailsModel = new CollectionDetailsViewModel
                    {
                        ImageUrl = await CollectionImage.GetImageLinkAsync(YandexToken, $"collection_{collection.Id}_", $"logo_{collection.Id}"),

                        collection = collection
                    };
                    detailsModel.Filter = model; 
                    detailsModel.items = await _item.FilterAsync(model,(int)id,page,ItemSize);
                    detailsModel.AvtorName = collection.AvtorName;

                    return View(detailsModel);
                }
                return NotFound();    
            }
            else
                return NotFound();  
        }

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

                    var CollectionEntry =await _collection.CreateAsync(model);
                    var collectionId = CollectionEntry.Entity.Id;
                    //propertiesElements 
                    Generate generate = new Generate(_collection, _propertiesModel);

                    await generate.GeneratePropertiesAsync(collectionId, model.PropertiesNumTitles, "number");
                    await generate.GeneratePropertiesAsync(collectionId, model.PropertiesStrTitles, "string");
                    await generate.GeneratePropertiesAsync(collectionId, model.PropertiesDateTitles, "date");
                    await generate.GeneratePropertiesAsync(collectionId, model.PropertiesBoolTitles, "bool");
                    await generate.GeneratePropertiesAsync(collectionId, model.PropertieSmallStringTitles, "smallstr");

                    //yandex disk
                    var Collection = await _collection.FindByIdAsync(collectionId);

                    if (model.ImageFile != null)
                    {
                        await CollectionImage.UploadImageAsync(YandexToken, $"collection_{Collection.Id}_", model.ImageFile, $"logo_{Collection.Id}");
                        Collection.ImageLink = await CollectionImage.GetImageLinkAsync(YandexToken, $"collection_{Collection.Id}_", $"logo_{Collection.Id}");
                    }
                    await _collection.UpdateAsync(Collection);

                    return RedirectToAction(nameof(Index), "Collection");
                }
                else
                    return View(model);
            }
            catch
            {
                return RedirectToAction("Privacy", "Home");
            }
        }

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
                            await CollectionImage.UploadImageAsync(YandexToken, $"collection_{model.Collectionid}_", model.ImageFile, $"logo_{model.Collectionid}");

                        var collection = await _collection.FindByIdAsync(model.Collectionid);
                        collection.Title = model.Title;
                        collection.ShortDesc = model.ShortDesc;
                        collection.Thema = thema;

                        if (model.ImageFile != null)
                        {
                            await CollectionImage.UploadImageAsync(YandexToken, $"collection_{collection.Id}_", model.ImageFile, $"logo_{collection.Id}");
                            collection.ImageLink = await CollectionImage.GetImageLinkAsync(YandexToken, $"collection_{collection.Id}_", $"logo_{collection.Id}");
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
                return RedirectToAction("Index", "Collection");
            }
        }

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
           
            await CollectionImage.DeleteImageAsync(YandexToken, $"collection_{collection.Id}_");
            await _collection.DeleteAsync(collection);
            return RedirectToAction("Index", "Collection");
        }

        [HttpGet]
        [Authorize]
        public IActionResult MyCollection(int?id )
        {
            int page = id ?? 0;
            var isAjax = Request.Headers["X-Requested-With"] == "XMLHttpRequest";
            if (isAjax)
                return PartialView("_writeMoreCollections", GetCollectionsToAvtor(page));
            return View(GetCollectionsToAvtor(page));
        }
        
        public IEnumerable<CollectionMinViewModel> GetCollections(int page=1)
        {
            var CollectionsToSkip = page * CollectionSize;
            var collectionList= _collection.TakeCollectionMin_Skip(CollectionsToSkip, CollectionSize);
            return collectionList;
        }
        public IEnumerable<CollectionMinViewModel> GetCollectionsToAvtor(int page = 1)
        {
            var CollectionsToSkip = page * CollectionSize;
            var collectionList = _collection.TakeCollectionMinByAvtor_Skip(CollectionsToSkip, CollectionSize, User.Identity.Name);
            return collectionList;
        }

        public CollectionDetailsViewModel GetItemsMinByCollections(int collectionId,int page = 1)
        {
            CollectionDetailsViewModel model = new CollectionDetailsViewModel();
            var ItemToSkip = page * ItemSize;
            var ItemList = _item.TakeItemBy_collection(collectionId, ItemToSkip, ItemSize,User.Identity.Name);
            model.items = ItemList;
            return model;
        }
        public async Task<CollectionDetailsViewModel> FilterItemByCollectionId(ItemFilterModel FilterModel,int id,int page)
        {
            CollectionDetailsViewModel model = new CollectionDetailsViewModel();
            var ItemList = await _item.FilterAsync(FilterModel,id,page,ItemSize);
            model.items = ItemList;
            return model;
        }
    }
}
