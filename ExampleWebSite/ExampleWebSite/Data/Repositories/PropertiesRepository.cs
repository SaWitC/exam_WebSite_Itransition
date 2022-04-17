using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleWebSite.Data.Interfaces;
using ExampleWebSite.Models.AddationalProperts;

namespace ExampleWebSite.Data.Repositories
{
    public class PropertiesRepository : IpropertiseRepository
    {
        public Task Create(PropertiesModel model, int collectionId)
        {
            throw new NotImplementedException();
        }

        public Task Delete(PropertiesModel model)
        {
            throw new NotImplementedException();
        }

        public Task Edit(PropertiesModel model)
        {
            throw new NotImplementedException();
        }
    }
}
