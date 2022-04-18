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
    }
}
