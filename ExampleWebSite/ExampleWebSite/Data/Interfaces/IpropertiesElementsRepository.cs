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
        public Task AddRangeAsync(IEnumerable<PropertiesElementModel> model);

        public Task Delete(PropertiesElementModel model);

        public Task Edit(PropertiesElementModel model);
        public IEnumerable<PropertiesElementModel> GetPropertiesByItemId(int itemId);
        public Task<IEnumerable<PropertiesElementModel>> TakePropertiesByItemIdAsync(int itemId);

        public Task UpdateRangeAsync(IEnumerable<PropertiesElementModel> models);

    }
}
