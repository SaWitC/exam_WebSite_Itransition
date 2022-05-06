using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleWebSite.Data.Interfaces;
using ExampleWebSite.Models.AddationalProperts;

namespace ExampleWebSite.Data.Repositories
{
    public class PropertiesElementRepository : IpropertiesElementsRepository
    {
        private readonly ExamWebSiteDBContext _context;
        public PropertiesElementRepository(ExamWebSiteDBContext context)
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

        public async Task AddRangeAsync(IEnumerable<PropertiesElementModel> model)
        {
            await _context.PropertiesElement.AddRangeAsync(model);
            await _context.SaveChangesAsync();
        }

        public Task Edit(PropertiesElementModel model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PropertiesElementModel> GetPropertiesByItemId(int itemId)
        {
            return _context.PropertiesElement.Where(o => o.ItemId == itemId).ToList().OrderBy(o=>o.Type);
        }
    }
}
