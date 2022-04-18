using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleWebSite.Models;
using ExampleWebSite.Data;
using ExampleWebSite.Models.AddationalProperts;

namespace ExampleWebSite.Data.Interfaces
{
    public interface IpropertiesModelRepository
    {
        public void AddRange(IEnumerable<PropertiesModel> model);
        public Task<IEnumerable<PropertiesModel>> GetByIdAsync(int collectionid);

        public Task AddRnageAsync(IEnumerable<PropertiesModel> model);
    }
}
