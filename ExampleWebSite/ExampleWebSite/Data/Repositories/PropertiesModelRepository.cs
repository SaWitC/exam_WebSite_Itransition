using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleWebSite.Data;
using ExampleWebSite.Data.Interfaces;
using ExampleWebSite.Models.AddationalProperts;
using Microsoft.EntityFrameworkCore;

namespace ExampleWebSite.Data.Repositories
{
    public class PropertiesModelRepository : IpropertiesModelRepository
    {
        private readonly ExamWebSiteDBContext _context;

        public PropertiesModelRepository(ExamWebSiteDBContext context)
        {
            _context = context;
        }
        public void AddRange(IEnumerable<PropertiesModel> model)
        {
            _context.Properties.AddRange(model);
            _context.SaveChanges();
        }
        public async Task AddRnageAsync(IEnumerable<PropertiesModel> model)
        {
            _context.Properties.AddRange(model);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<PropertiesModel>> GetByIdAsync(int collectionid)
        {
            return await _context.Properties.Where(o => o.CollectionId == collectionid).ToListAsync();
        }

    }
}
