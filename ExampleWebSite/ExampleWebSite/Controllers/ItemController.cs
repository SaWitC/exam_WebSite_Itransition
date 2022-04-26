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

namespace ExampleWebSite.Controllers
{
    public class ItemController : Controller
    {
        private readonly ICommentRepository _comment;
        private readonly ICollectionRepository _collection;
        private readonly IpropertiesElementsRepository _properties;
        private readonly IpropertiesModelRepository _propertiesModel;
        private readonly IThemeRepository _Themes;
        private readonly IItemRepository _item;
        private readonly UserManager<User> _userManager;

        private int CommentCount =2;

        public ItemController(UserManager<User> userManager, IItemRepository item, IpropertiesElementsRepository properties, ICollectionRepository collection, IThemeRepository theme, IpropertiesModelRepository propertiesModel, ICommentRepository comment)
        {
            _comment = comment;
            _collection = collection;
            _properties = properties;
            _item = item;
            _userManager = userManager;
            _Themes = theme;
            _propertiesModel = propertiesModel;
        }
        // GET: ItemController/Details/5
        [HttpGet]
        public ActionResult Details(int? id,int? p)
        {
            int page = p ?? 0;
            var isAjax = Request.Headers["X-Requested-With"] == "XMLHttpRequest";
            if (isAjax)
            {
                return PartialView("_WriteMoreComments", GetComments((int)id, page));
            }

            var itemViewModel = new ItemDetailsViewModel();
            itemViewModel.Item = _item.GetItemById((int)id);
            itemViewModel.comments = _comment.TakeCommentsByBlogId_Skip(0,CommentCount,(int)id);
            return View(itemViewModel);
        }


        // GET: ItemController/Create
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

        // POST: ItemController/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateItemViewModel model)
        {
            //try
            //{
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
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: ItemController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ItemController/Edit/5
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

        // GET: ItemController/Delete/5
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

        public PartialViewResult _WriteMoreComments()
        {
            return PartialView();
        }

        private ItemDetailsViewModel GetComments(int itemId,int page = 1)
        {
            var CommentToSkip = page * CommentCount;

            return new ItemDetailsViewModel() { comments = _comment.TakeCommentsByBlogId_Skip(CommentToSkip, CommentCount, itemId) };
        }
    }
}
