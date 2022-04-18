using ExampleWebSite.Models.AddationalProperts;
using ExampleWebSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.Data.Interfaces
{
    public interface IpropertiesElementsRepository
    {
        // public Task Create(CreatePropertiesViewModel model, int collectionId);
        public Task Create(PropertiesElementModel model, int collectionId);

        public Task Delete(PropertiesElementModel model);

        public Task Edit(PropertiesElementModel model);

    }
}
