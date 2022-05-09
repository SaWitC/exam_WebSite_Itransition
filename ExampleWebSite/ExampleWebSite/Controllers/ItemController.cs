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

        //private readonly IThemeRepository _Themes;
        private readonly IItemRepository _item;
        //private readonly UserManager<User> _userManager;

        private int CommentCount =2;

        public ItemController(
            ITagRepository tag,
            IItemTagsrelationshipRepository item_Tags_Relationship,
            IItemRepository item,
            IpropertiesElementsRepository properties,
            ICollectionRepository collection,
            IpropertiesModelRepository propertiesModel,
            ICommentRepository comment,
            ExamWebSiteDBContext context)
        {
            _context = context;

            _tag = tag;
            _item_Tags_Relationship = item_Tags_Relationship;
            _comment = comment;
            _collection = collection;
            _propertiesElements= properties;
            _item = item;
            _propertiesModel = propertiesModel;
        }
        // detatils =============================================================
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
                itemViewModel.comments = _comment.TakeCommentsByBlogId_Skip(0, CommentCount, (int)id);
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
            var CommentToSkip = page * CommentCount;

            return new ItemDetailsViewModel() { comments = _comment.TakeCommentsByBlogId_Skip(CommentToSkip, CommentCount, itemId) };
        }


        //Create ================================================================================
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
        //Edit ======================================================================
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

        [HttpPost]
        public async Task<ActionResult> Edit(EditItemViewModel model)
        {
            try
            {
                //model..Collection = await _collection.FindByIdAsync(model.collectionId);
               

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
        
        //Delete ====================================================================
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
        public async Task<ActionResult> DeleteConfirmed(int id)//edit
        {
            var item = _item.GetItemById((int)id);
            await _item.Delete(item);
            return RedirectToAction("index","home");
        }

        //Find =======================================================================
       // [HttpPost]
        //public IActionResult Find(FindItemsViewModel model,string SearchString)
        //{
        //    if (!string.IsNullOrEmpty(SearchString))
        //    {
        //        var items = _context.Themes.AsQueryable();

        //        model.Items = items.FullTextSearchQuery(SearchString);
        //        return View(model);
        //    }
        //    //if (!string.IsNullOrEmpty(Tag))
        //    //{

        //    //}

        //    return View(model);
        //}

        //[HttpGet]
        //public IActionResult Find(string SearchString)
        //{
        //    //var options = new FullTextSearchOptions
        //    //{
        //    //    Depth = 2,
        //    //    Filter = (propinfo) =>
        //    //    {
        //    //        //if (propinfo.DeclaringType == (typeof(ItemModel){
        //    //        //    return propinfo.PropertyType == typeof(Cus)
        //    //        //}
        //    //        if (propinfo.PropertyType == typeof(string))
        //    //        {

        //    //        }

        //    //    }
        //    //};

        //    FindItemsViewModel mode = new FindItemsViewModel();
        //    var items =_context.Items;
        //    if (!string.IsNullOrEmpty(SearchString))
        //    {
        //        var arr = new test[4]
        //        {
        //            new test{value="first" },
        //            new test{value="second" },
        //            new test{value="threed" },
        //            new test{value="fourth" },

        //        };
        //        var arr2 =arr.AsQueryable().FullTextSearchQuery("f");


        //        //List<ItemModel> items = new List<ItemModel>();
        //        //mode.Items= items.FullTextSearchQuery<ItemModel>(SearchString);
        //        //mode.Items = _context.Items.Where(i => (i.Title != null && i.Title.ToLower().Contains("t") | i.Tags != null && i.Tags.ToLower().Contains("t"))).ToList();

               
        //    }
        //    else
        //    {
        //        mode.Items = _context.Items.ToList();
        //    }
        //    return View(mode);
        //}
        [HttpGet]
        public async Task<IActionResult> Find (string SearchString, string TagString)
        {

            FindItemsViewModel mode = new FindItemsViewModel();
            if (!string.IsNullOrEmpty(TagString))
            {
                mode.Items = await _item.TakeItemByTag_SkipAsync(TagString, 0, 5);
                return View(mode);
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                mode.Items = _context.Items.AsQueryable().FullTextSearchQuery(SearchString).Take(5);
                mode.SearchString = SearchString;
                return View(mode);
            }
            mode.Items = _context.Items.AsQueryable();
        
            return View(mode);
        }

        //[HttpPost]
        //public async Task<IActionResult> Find(string SearchString,string TagString)
        //{
        //    FindItemsViewModel mode = new FindItemsViewModel();
        //    if (!string.IsNullOrEmpty(TagString))
        //    {  
        //        mode.Items= await _item.TakeItemByTag_SkipAsync(TagString, 0, 5);
        //        return View(mode);
        //    }
        //    //var items = _context.Items.ToList();
        //    if (!string.IsNullOrEmpty(SearchString))
        //    {
        //        //test t = new test { value = "first", v2=23 };
        //        //test t2 = new test { value = "second",v2=11 };
        //        //test t3 = new test { value = "222222",v2=45 };
        //        //test t4 = new test { value = "4444f",v2=99 };

        //        //List<test> arr = new List<test>();
        //        //arr.Add(t);
        //        //arr.Add(t2);
        //        //arr.Add(t3);
        //        //arr.Add(t4);

        //        // var arr2 = arr.AsQueryable().FullTextSearchQuery(SearchString);
        //        //mode.stt = arr2.ToList();

        //        var items = _context.Themes.AsQueryable().FullTextSearchQuery(SearchString);

        //        //var items = _context.Themes
        //        //    .Where(x => EF.Functions.FreeText(x.Title,SearchString));

        //        //var items = _context.Themes.Where(c => EF.Functions.FreeText(EF.Property<string>(c, c.Title), SearchString)).ToList();
        //        //mode.Items = items;
        //        // var list = items.ToPagedList(_eqManager.Chunk.Page, 15);
        //        return View(mode);

        //    }
        //    else
        //    {
        //        //mode.Items = _context.Themes.AsQueryable();
        //    }
        //    return View(mode);
        //}
        //public async Task<IEnumerable<string>> GetTags(string SearchString)
        //{
        //    return await _item.GetTags(SearchString);
        //}


    }
}
