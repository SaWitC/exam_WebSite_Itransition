using ExampleWebSite.Models;
using ExampleWebSite.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.Data.Interfaces
{
    public interface ICollectionRepository
    {
       // public IActionResult Details(int? id);
        public Task CreateAsync(CreateCollectionViewModel model);
        public Task CreateAsync(CollectionModel collection);
        public Task DeleteAsyncById(int Id);
        public Task DeleteAsync(CollectionModel collection);
        public IQueryable<CollectionMinViewModel> TakeCollectionMin_Skip(int skip, int pageSize);
        public IQueryable<CollectionMinViewModel> TakeCollectionMinByAvtor_Skip(int skip, int pageSize,string AvtorName);
        public Task UpdateAsync(CollectionModel model);
        public Task<IEnumerable<CollectionModel>> TakeAllAsync();
        public Task<CollectionModel> FindByTitleAsync(string title);
        public Task<CollectionModel> FindByIdAsync(int id);
        public Task<IEnumerable<CollectionModel>> FindByAvtorIdAsync(string avtorName);

        public Task<IEnumerable<CollectionModel>> TakeCollection_SkipAsync(int skip,int pageSize);
            



    }
}
