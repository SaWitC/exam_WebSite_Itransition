using ExampleWebSite.Models.AddationalProperts;
using ExampleWebSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.Data.Interfaces
{
    public interface IpropertiseRepository
    {
        // public Task Create(CreatePropertiesViewModel model, int collectionId);
        public Task Create(PropertiesModel model, int collectionId);

        public Task Delete(PropertiesModel model);

        public Task Edit(PropertiesModel model);
    }
}
