using ExampleWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleWebSite.Data.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace ExampleWebSite.Data.Repositories
{
    public class ItemTagsrelationshipRepository:IItemTagsrelationshipRepository
    {
        private readonly ExamWebSiteDBContext _context;       
        public ItemTagsrelationshipRepository(ExamWebSiteDBContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(ItemModel Item,IEnumerable<TagModel> Tags)
        {
            List<ItemTagsrelationshipspModel> items = new List<ItemTagsrelationshipspModel>();
            foreach (var x in Tags)
            {
                items.Add(new ItemTagsrelationshipspModel {Item=Item,Tag =x });
            }
            _context.ItemTagsrelationships.AddRange(items);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<ItemTagsrelationshipspModel>> GetRelationshipsByItemIdAsync(int Id)
        {
            //_context.ItemTagsrelationships.AsQueryable().Where(o => o.ItemId == Id).Select(o => new List<int>(o.TagId));
            return await _context.ItemTagsrelationships.AsQueryable().Where(o => o.ItemId == Id).ToListAsync();
        }
    }
}
