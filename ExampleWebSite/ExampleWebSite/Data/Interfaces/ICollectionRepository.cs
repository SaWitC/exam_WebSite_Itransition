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
        public Task Delete(int Id);
        public Task<IEnumerable<CollectionModel>> TakeAllAsync();
        public Task<CollectionModel> FindByTitleAsync(string title);
        public Task<CollectionModel> FindByIdAsync(int id);



    }
}
