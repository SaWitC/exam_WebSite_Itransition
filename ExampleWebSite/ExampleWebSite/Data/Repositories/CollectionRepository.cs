using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleWebSite.Data.Interfaces;
using ExampleWebSite.Models;
using ExampleWebSite.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
   

namespace ExampleWebSite.Data.Repositories
{
    public class CollectionRepository : ICollectionRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly ExamWebSiteDBContext _context;
        public CollectionRepository(UserManager<User> userManager,ExamWebSiteDBContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task CreateAsync(CreateCollectionViewModel model)
        { 
            _context.Collections.Add(model.collection);
            await _context.SaveChangesAsync();
        }
        public async Task CreateAsync(CollectionModel collection)
        {
            _context.Collections.Add(collection);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            CollectionModel collection =await _context.Collections.FirstOrDefaultAsync(o => o.Id == Id);
            _context.Collections.Remove(collection);
        }

        public async Task<IEnumerable<CollectionModel>> TakeAllAsync()
        {
            return await _context.Collections.ToListAsync();
        }
        public async Task<CollectionModel> FindByTitleAsync(string title) => await _context.Collections.FirstOrDefaultAsync(o=>o.Title==title);

        public async Task<CollectionModel> FindByIdAsync(int id)=> await _context.Collections.FirstOrDefaultAsync(o => o.Id == id);

        public async Task<IEnumerable<CollectionModel>> FindByAvtorIdAsync(string avtorName) => await _context.Collections.Where(o=>o.AvtorName== avtorName).ToListAsync();

        public async Task DeleteAsyncById(int Id)
        {
            var collection = _context.Collections.FirstOrDefaultAsync(o => o.Id == Id);
            _context.Remove(collection);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CollectionModel model)
        {
            _context.Collections.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CollectionModel>> TakeCollection_SkipAsync(int skip,int pageSize)
        {
            return await _context.Collections.OrderBy(t => t.Id).Skip(skip).
                Take(pageSize).ToListAsync();
        }

        public async Task DeleteAsync(CollectionModel collection)
        {
            _context.Collections.Remove(collection);
            await _context.SaveChangesAsync();
        }

        public IQueryable<CollectionMinViewModel> TakeCollectionMin_Skip(int skip, int pageSize)
        {
            IQueryable<CollectionMinViewModel> collections = _context.Collections.AsNoTracking()
            //.Include(o => o.Thema)
            .OrderBy(o => o.Id)
            .Skip(skip)
            .Take(pageSize)
            .Select(x => new CollectionMinViewModel {Id=x.Id,Title=x.Title,AvtorName=x.AvtorName,ShortDesc=x.ShortDesc,Thema =x.Thema.Title});

            return collections;
        }
        public IQueryable<CollectionMinViewModel> TakeCollectionMinByAvtor_Skip(int skip, int pageSize, string AvtorName)
        {
            IQueryable<CollectionMinViewModel> collections = _context.Collections.AsNoTracking()
            //.Include(o => o.Thema)
            .OrderBy(o => o.Id)
            .Skip(skip)
            .Take(pageSize)
            .Where(o=>o.AvtorName ==AvtorName)
            .Select(x => new CollectionMinViewModel { Id = x.Id, Title = x.Title, AvtorName = x.AvtorName, ShortDesc = x.ShortDesc, Thema = x.Thema.Title });

            return collections;
        }

    }
}
