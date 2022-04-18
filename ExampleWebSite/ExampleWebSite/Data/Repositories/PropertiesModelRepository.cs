using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleWebSite.Data;
using ExampleWebSite.Data.Interfaces;
using ExampleWebSite.Models.AddationalProperts;




namespace ExampleWebSite.Data.Repositories
{
    public class PropertiesModelRepository : IpropertiesModelRepository
    {
        private readonly ExamWebSiteDBContext _context;

        public PropertiesModelRepository(ExamWebSiteDBContext context)
        {
            _context = context;
        }
        public async Task AddRangeAsync(IEnumerable<PropertiesModel> model)
        {
            _context.Properties.AddRange(model);
            await _context.SaveChangesAsync();
        }
    }
}
