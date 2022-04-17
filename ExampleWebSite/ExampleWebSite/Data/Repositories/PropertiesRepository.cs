using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleWebSite.Data.Interfaces;
using ExampleWebSite.Models.AddationalProperts;

namespace ExampleWebSite.Data.Repositories
{
    public class PropertiesRepository : IpropertiesRepository
    {
        private readonly ExamWebSiteDBContext _context;
        public PropertiesRepository(ExamWebSiteDBContext context)
        {
            _context = context;
        }
        public Task Create(PropertiesElementModel model, int collectionId)
        {
            //_context.Properties
            throw new NotImplementedException();

        }

        public Task Delete(PropertiesElementModel model)
        {
            throw new NotImplementedException();
        }

        public Task Edit(PropertiesElementModel model)
        {
            throw new NotImplementedException();
        }
    }
}
