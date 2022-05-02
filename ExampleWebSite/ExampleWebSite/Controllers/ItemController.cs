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

using ExampleWebSite.Data;
using Korzh.EasyQuery.Services;

namespace ExampleWebSite.Controllers
{
    public class ItemController : Controller
    {
        private readonly ExamWebSiteDBContext _context;

        private readonly ICommentRepository _comment;
        private readonly ICollectionRepository _collection;
        private readonly IpropertiesElementsRepository _properties;
        private readonly IpropertiesModelRepository _propertiesModel;

        //private readonly IThemeRepository _Themes;
        private readonly IItemRepository _item;
        //private readonly UserManager<User> _userManager;

        private int CommentCount =2;

        public ItemController(IItemRepository item, IpropertiesElementsRepository properties, ICollectionRepository collection, IpropertiesModelRepository propertiesModel, ICommentRepository comment,ExamWebSiteDBContext context)
        {
            _context = context;

            _comment = comment;
            _collection = collection;
            _properties = properties;
            _item = item;
            //_userManager = userManager;
            //_Themes = theme;
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
                itemViewModel.Properties = _properties.GetPropertiesByItemId((int)id);
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
                    await _item.Create(model);
                    var item = await _item.FindByTitleAsync(model.Item.Title);
                    if (model.Properties != null)
                    {
                        if (model.Properties.Count > 1)
                        {
                            var propertiesElements = new List<PropertiesElementModel>();
                            foreach (var x in model.Properties)
                            {
                                x.Item = item;
                                propertiesElements.Add(x);
                            }

                            await _properties.AddRangeAsync(propertiesElements);
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
        public ActionResult Edit(int id)
        {
            return View();
        }

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
        public IActionResult Find ()
        {     
            FindItemsViewModel mode = new FindItemsViewModel();
            mode.Items = _context.Themes.AsQueryable();
        
            return View(mode);
        }

        [HttpPost]
        public IActionResult Find(string SearchString)
        {
            FindItemsViewModel mode = new FindItemsViewModel();
            //var items = _context.Items.ToList();
            if (!string.IsNullOrEmpty(SearchString))
            {
                //test t = new test { value = "first", v2=23 };
                //test t2 = new test { value = "second",v2=11 };
                //test t3 = new test { value = "222222",v2=45 };
                //test t4 = new test { value = "4444f",v2=99 };



                //List<test> arr = new List<test>();
                //arr.Add(t);
                //arr.Add(t2);
                //arr.Add(t3);
                //arr.Add(t4);

                // var arr2 = arr.AsQueryable().FullTextSearchQuery(SearchString);
                //mode.stt = arr2.ToList();

                var items = _context.Themes.AsQueryable().Where(t =>  t.Title != null && t.Title.ToLower().Contains("b") || t.Description != null && t.Description.ToLower().Contains("b")).AsQueryable();
                mode.Items = items;
                // var list = items.ToPagedList(_eqManager.Chunk.Page, 15);
                return View(mode);

            }
            else
            {
                mode.Items = _context.Themes.AsQueryable();
            }
            return View(mode);
        }
    }
}
