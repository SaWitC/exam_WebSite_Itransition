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
            if (Item != null && Tags != null)
            {
                List<ItemTagsrelationshipspModel> items = new List<ItemTagsrelationshipspModel>();
                foreach (var x in Tags)
                {
                    items.Add(new ItemTagsrelationshipspModel { Item = Item, Tag = x });
                }
                _context.ItemTagsrelationships.AddRange(items);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<ItemTagsrelationshipspModel>> GetRelationshipsByItemIdAsync(int Id)
        {
            //_context.ItemTagsrelationships.AsQueryable().Where(o => o.ItemId == Id).Select(o => new List<int>(o.TagId));
            return await _context.ItemTagsrelationships.AsQueryable().Where(o => o.ItemId == Id).ToListAsync();
        }
        public IEnumerable<TagModel> GetTagsByItemId(int itemId)
        {
            //SQL
            //            select Tags.Title
            //from Tags inner join ItemTagsrelationships
            //on(Tags.Id = ItemTagsrelationships.TagId)
            //where ItemTagsrelationships.ItemId = itemid

             var tags = from s in _context.Tags
                       join sa in _context.ItemTagsrelationships on s.Id equals sa.TagId
                       where sa.ItemId ==itemId
                       select s;
            return tags;
        }

        public IEnumerable<string> GetTagsTitlesByItemId(int itemId)
        {
            var tags = from s in _context.Tags
                       join sa in _context.ItemTagsrelationships on s.Id equals sa.TagId
                       where sa.ItemId == itemId
                       select s.Title;
            return tags;
        }
        public async Task RemoveOldRelationshipByItemIdAsync(int ItemId)
        {
            var relationship = await _context.ItemTagsrelationships.Where(o => o.ItemId == ItemId).ToListAsync();
            _context.ItemTagsrelationships.RemoveRange(relationship);
            await _context.SaveChangesAsync();
        }
    }
}
