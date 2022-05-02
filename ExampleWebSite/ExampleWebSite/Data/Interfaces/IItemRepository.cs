using ExampleWebSite.Models;
using ExampleWebSite.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.Data.Interfaces
{
    public interface IItemRepository
    {
        //public Task Create(int CollectionId, CreateItemViewModel model);
        public Task Create(CreateItemViewModel model);
        public ItemModel GetItemById(int id);
        public Task Update(CreateItemViewModel model);
        public Task Delete(ItemModel model);
        public Task<IEnumerable<ItemModel>> Find(string SearschString, int themeId);
        public Task<IEnumerable<ItemModel>> FindByCollectionIdAsync(int collectionId);
        public Task<ItemModel> FindByTitleAsync(string title);

    }
}
