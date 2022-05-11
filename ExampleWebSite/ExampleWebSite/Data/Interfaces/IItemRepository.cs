using ExampleWebSite.Models;
using ExampleWebSite.Models.ModelsForProcessing;
using ExampleWebSite.ViewModels;
using ExampleWebSite.ViewModels.Items;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ExampleWebSite.Controllers.ItemController;

namespace ExampleWebSite.Data.Interfaces
{
    public interface IItemRepository
    {
        //public Task Create(int CollectionId, CreateItemViewModel model);
        public Task<EntityEntry<ItemModel>> CreateAsync(CreateItemViewModel model);
        public ItemModel GetItemById(int id);
        //public Task UpdateAsync(EditItemViewModel model);
        public Task UpdateAsync(ItemModel model);
        public Task Delete(ItemModel model);
        public IEnumerable<SearchResoultModel> Find(FindItemsByTextViewModel model);
        //public IEnumerable<SearchResoultModel> FindByTag(string TagString, int Size, int Page);

        //public Task<IEnumerable<ItemModel>> FindByCollectionIdAsync(int collectionId);
        //public Task<ItemModel> FindByTitleAsync(string title);
        public Task<IEnumerable<ItemModel>> TakeItemByTag_SkipAsync(string tagTitle, int skip,int Size,string UserName=null);
        public IEnumerable<ItemModel> TakeItemBy_collection(int collectionId,int skip,int pageSize, string UserName=null);

    }
}
