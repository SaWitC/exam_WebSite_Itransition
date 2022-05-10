using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleWebSite.Models;
using ExampleWebSite.Models.AddationalProperts;
using ExampleWebSite.ViewModels;
using ExampleWebSite.Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Korzh.EasyQuery.Linq;
using ExampleWebSite.ViewModels.Items;
using Microsoft.EntityFrameworkCore;

using ExampleWebSite.Data;
using Korzh.EasyQuery.Services;
using ExampleWebSite.Data.ConfigurationModels;
using Microsoft.Extensions.Options;

namespace ExampleWebSite.Controllers
{
    public class ItemController : Controller
    {
        private readonly ExamWebSiteDBContext _context;

        private readonly ITagRepository _tag;
        private readonly IItemTagsrelationshipRepository _item_Tags_Relationship;
        private readonly ICommentRepository _comment;
        private readonly ICollectionRepository _collection;
        private readonly IpropertiesElementsRepository _propertiesElements;
        private readonly IpropertiesModelRepository _propertiesModel;
        private readonly IItemRepository _item;
        IOptions<AppConfigDataModel> _options;

        private static int CommentSize;

        public ItemController(
            ITagRepository tag,
            IItemTagsrelationshipRepository item_Tags_Relationship,
            IItemRepository item,
            IpropertiesElementsRepository properties,
            ICollectionRepository collection,
            IpropertiesModelRepository propertiesModel,
            ICommentRepository comment,
            ExamWebSiteDBContext context,
            IOptions<AppConfigDataModel> options)
        {
            _tag = tag;
            _item_Tags_Relationship = item_Tags_Relationship;
            _comment = comment;
            _collection = collection;
            _propertiesElements= properties;
            _item = item;
            _propertiesModel = propertiesModel;
            _options = options;

            CommentSize = int.Parse(_options.Value.CommentSize);
        }

        [HttpGet]
        public ActionResult Details(int? id,int? p)
        {
            if (id != null)
            {
                int page = p ?? 0;
                var isAjax = Request.Headers["X-Requested-With"] == "XMLHttpRequest";
                if (isAjax)
                {
                    return PartialView("_WriteMoreComments", GetComments((int)id, page));
                }
                
                var itemViewModel = new ItemDetailsViewModel();
                itemViewModel.Tags = _item_Tags_Relationship.GetTagsByItemId((int)id);
                itemViewModel.Properties = _propertiesElements.GetPropertiesByItemId((int)id);
                itemViewModel.Item = _item.GetItemById((int)id);
                itemViewModel.comments = _comment.TakeCommentsByBlogId_Skip(0, CommentSize, (int)id);
                return View(itemViewModel);
            }
            else
                return NotFound();
        }
        public PartialViewResult _WriteMoreComments()
        {
            return PartialView();
        }
        private ItemDetailsViewModel GetComments(int itemId, int page = 1)
        {
            var CommentToSkip = page * CommentSize;

            return new ItemDetailsViewModel() { comments = _comment.TakeCommentsByBlogId_Skip(CommentToSkip, CommentSize, itemId) };
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> Create(int? collectionid)
        {
            if (collectionid != null)
            {
                CreateItemViewModel model = new CreateItemViewModel();
                model.TypicalElements = await _propertiesModel.GetByIdAsync((int)collectionid);
                model.collectionId = (int)collectionid;
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateItemViewModel model)
        {
            try
            {
                model.Item.Collection = await _collection.FindByIdAsync(model.collectionId);
                if (ModelState.IsValid)
                {
                    var Entity =await _item.CreateAsync(model);
                    var Item = _item.GetItemById(Entity.Entity.Id);
                    if (Item != null)
                    {
                        var tags =await _tag.CreateTagsAsync(model.Tags);
                        await _item_Tags_Relationship.CreateAsync(Item,tags);

                        if (model.Properties != null)
                        {
                            if (model.Properties.Count > 1)
                            {
                                var propertiesElements = new List<PropertiesElementModel>();
                                foreach (var x in model.Properties)
                                {
                                    x.Item = Item;
                                    propertiesElements.Add(x);
                                }
                                await _propertiesElements.AddRangeAsync(propertiesElements);
                            }
                        }
                    }
                    return RedirectToAction("Index", "Home");
            }
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> Edit(int? ItemId)
        {
            if (ItemId != null)
            {
                var item = _item.GetItemById((int)ItemId);
                if (item != null)
                {
                    EditItemViewModel model = new EditItemViewModel();
                    model.Properties = await _propertiesElements.TakePropertiesByItemIdAsync((int)ItemId);
                    model.collectionId = item.CollectionId;
                    var x =_item_Tags_Relationship.GetTagsTitlesByItemId(item.Id).ToArray();
                    model.Tags = string.Join(",",x);
                    model.Title = item.Title;
                    model.itemId = item.Id;

                    return View(model);
                }
            }
            return NotFound();
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Edit(EditItemViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var item = _item.GetItemById(model.itemId);

                    if (item != null)
                    {
                        item.Title = model.Title;
                        var tags = await _tag.CreateTagsAsync(model.Tags);
                        await _item_Tags_Relationship.RemoveOldRelationshipByItemIdAsync(item.Id);
                        await _item_Tags_Relationship.CreateAsync(item, tags);

                        await _item.UpdateAsync(item);

                        if (model.Properties != null && model.Properties.Count() > 1)
                        {
                            var properties = _propertiesElements.GetPropertiesByItemId(item.Id);
                            foreach (var oldProp in properties)
                            {
                                foreach (var Modelprop in model.Properties)
                                {
                                    if (oldProp.Title == Modelprop.Title)
                                    {
                                        oldProp.Value = Modelprop.Value; 
                                        continue;
                                    }
                                }
                            }
                            await _propertiesElements.UpdateRangeAsync(properties);
                        }
                    }
                    return RedirectToAction("Index", "Home");
                }
                return View(model);
            }
            catch
            {
                return View(model);
            }
        }
        [Authorize]
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                var item = _item.GetItemById((int)id);
                return View(item);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var item = _item.GetItemById((int)id);
            await _item.Delete(item);
            return RedirectToAction("index","home");
        }

        [HttpGet]
        public async Task<IActionResult> Find (string SearchString, string TagString)
        {
            FindItemsViewModel model = new FindItemsViewModel();
            if (!string.IsNullOrEmpty(SearchString))
            {
                var options = new FullTextSearchOptions
                {
                    Depth = 2,
                    Filter = (propInfo) =>
                    {
                        if (propInfo.DeclaringType == typeof(ItemModel))
                        {
                            return propInfo.PropertyType == typeof(string);
                        }
                        //else if (propInfo.PropertyType == typeof(string))
                        //{
                        //    if (propInfo.DeclaringType == typeof(Customer))
                        //    {
                        //        return propInfo.Name == "CompanyName" || propInfo.Name == "Country";
                        //    }
                        //    else if (propInfo.DeclaringType == typeof(Employee))
                        //    {
                        //        return propInfo.Name == "FirstName" || propInfo.Name == "LastName";
                        //    }
                        //}
                        return false;
                    }
                };

                var inteers =await _context.Items.FullTextSearchQuery(SearchString, options).ToListAsync();
                model.Items = inteers;
                model.SearchString = SearchString;
                return View(model);
            }
            model.Items = null;
        
            return View(model);
        }
    }
}
