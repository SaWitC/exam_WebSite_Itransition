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
        public Task AddRangeAsync(IEnumerable<PropertiesModel> model);
    }
}
