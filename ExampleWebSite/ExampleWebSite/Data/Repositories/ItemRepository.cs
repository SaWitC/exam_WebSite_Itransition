using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleWebSite.Data.Interfaces;
using ExampleWebSite.Models;
using ExampleWebSite.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task Create(CreateItemViewModel model)
        {
            model.Item.CollectionId = model.collectionId;
            _context.Items.Add(model.Item);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(ItemModel model)
        {
            _context.Items.Remove(model);
            await _context.SaveChangesAsync();
        }
        public ItemModel GetItemById(int id)=> _context.Items.FirstOrDefault(o=>o.Id ==id);
        public async Task Update(CreateItemViewModel model)
        {
            _context.Items.Update(model.Item);
            await _context.SaveChangesAsync();
        }
        public Task<IEnumerable<ItemModel>> Find(string SearschString, int themeId)
        {
            throw new NotImplementedException();
        }
        public async Task<ItemModel> FindByTitleAsync(string title)=> await _context.Items.FirstOrDefaultAsync(o=>o.Title ==title);
        public async Task<IEnumerable<ItemModel>> FindByCollectionIdAsync(int collectionId)=> await _context.Items.AsNoTracking().Where(o => o.CollectionId == collectionId).ToListAsync();
        public IEnumerable<ItemModel> TakeItemBy_collection(int collectionId, int skip, int pageSize)
        {
            return _context.Items.Skip(skip).Take(pageSize).Where(o => o.CollectionId == collectionId).ToList();
        }


    }
}
