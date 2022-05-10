using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleWebSite.Data.Interfaces;
using ExampleWebSite.Models;
using ExampleWebSite.ViewModels;
using ExampleWebSite.ViewModels.Items;
using Korzh.EasyQuery.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ExampleWebSite.Data.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly ExamWebSiteDBContext _context;
        public ItemRepository(UserManager<User> userManager, ExamWebSiteDBContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        public async Task<EntityEntry<ItemModel>> CreateAsync(CreateItemViewModel model)
        {      
            model.Item.CollectionId = model.collectionId;
            var item =await  _context.Items.AddAsync(model.Item);
            await _context.SaveChangesAsync();
            return item;
        }
        public async Task Delete(ItemModel model)
        {
            _context.Items.Remove(model);
            await _context.SaveChangesAsync();
        }
        public ItemModel GetItemById(int id)=> _context.Items.FirstOrDefault(o=>o.Id ==id);
        //public async Task UpdateAsync(EditItemViewModel model)
        //{
        //    _context.Items.Update(model.);
        //    await _context.SaveChangesAsync();
        //}
        public async Task UpdateAsync(ItemModel model)
        {
            _context.Items.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ItemModel>> Find(FindItemsViewModel model)
        {
            if (model != null)
            {
                var items = _context.Items.AsQueryable();
                if (model.SearchString != null) {
                    var resitems =await items.FullTextSearchQuery(model.SearchString).Take(5).ToListAsync();
                }
            }
            return null;
        }
        public async Task<ItemModel> FindByTitleAsync(string title)=> await _context.Items.FirstOrDefaultAsync(o=>o.Title ==title);
        //public async Task<IEnumerable<ItemModel>> FindByCollectionIdAsync(int collectionId)=> await _context.Items.AsNoTracking().Where(o => o.CollectionId == collectionId).ToListAsync();
        public async Task<IEnumerable<ItemModel>> TakeItemByTag_SkipAsync(string tagTitle, int skip, int Size, string UserName=null)//later change
        {
            //select Items.Title
            //from Items inner join ItemTagsrelationships
            //on(Items.Id = ItemTagsrelationships.ItemId)
            //inner join Tags on(Tags.Id= ItemTagsrelationships.TagId)
            //where Tags.Title = '123'

            var x = from it in _context.Items
                    join itta in _context.ItemTagsrelationships
                    on it.Id equals itta.ItemId
                    join ta in _context.Tags
                    on itta.TagId equals ta.Id
                    where ta.Title == tagTitle
                    select it;
            if (!string.IsNullOrEmpty(UserName))
            {
                string userId = _context.Users.FirstOrDefault(o=>o.UserName==UserName).Id;
                if (userId != null)
                    return CheckstatusIsLiked(await x.Skip(skip).Take(Size).ToListAsync(),userId);
            }
            return await x.Skip(skip).Take(Size).ToListAsync();
        }
        public IEnumerable<ItemModel> TakeItemBy_collection(int collectionId, int skip, int pageSize, string UserName = null)
        {
            var Items= _context.Items.Skip(skip).Take(pageSize).Where(o => o.CollectionId == collectionId).ToList();

            if (!string.IsNullOrEmpty(UserName))
            {
                string userId = _context.Users.FirstOrDefault(o => o.UserName == UserName).Id;
                if (userId != null)
                    return CheckstatusIsLiked(Items, userId);
            }
            return Items;
        }
        private IEnumerable<ItemModel> CheckstatusIsLiked(IEnumerable<ItemModel> items,string userId)
        {
            //SQL
            // select Items.Title
            //from Items inner join Likes
            //on(Items.Id = Likes.ItemId)
            //where Likes.UserId = 'UserId'

            var x = from s in items.AsQueryable() join l in _context.Likes on s.Id equals l.ItemId where l.UserId == userId && l.IsLiked == true select s.Id;

            foreach (var item in items)
            {
                foreach (var likedId in x.ToList())
                {
                    if (item.Id == likedId) item.IsLiked = true;
                }
            }
            return items;
        }
    }
}
