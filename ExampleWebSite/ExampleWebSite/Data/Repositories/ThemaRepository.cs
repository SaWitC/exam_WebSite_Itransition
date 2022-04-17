using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleWebSite.Models;
using ExampleWebSite.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExampleWebSite.Data.Repositories
{
    public class ThemaRepository : IThemeRepository
    {
        private readonly ExamWebSiteDBContext _context;
        public ThemaRepository(ExamWebSiteDBContext context)
        {
            _context = context;
        }
        //find
        public ThemaModel FindById(int id) => _context.Themes.FirstOrDefault(o=>o.Id==id);
        public async Task<ThemaModel> FindByIdASync(int id) => await _context.Themes.FirstOrDefaultAsync(o=>o.Id==id);
        public ThemaModel FindByTitle(string title) => _context.Themes.FirstOrDefault(o => o.Title == title);
        public Task<ThemaModel> FindByTitleAsync(string title) => _context.Themes.FirstOrDefaultAsync(o => o.Title == title);
        // take all
        public IEnumerable<ThemaModel> TakeAll() =>_context.Themes.ToList();
        public async Task<IEnumerable<ThemaModel>> TakeAllAsync() =>await _context.Themes.ToListAsync();


    }
}
