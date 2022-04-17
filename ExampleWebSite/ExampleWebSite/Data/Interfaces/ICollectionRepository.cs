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
        public Task Create(CreateCollectionViewModel model);

        public Task Delete(int Id);
        
    }
}
