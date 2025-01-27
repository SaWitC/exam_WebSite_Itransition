﻿using ExampleWebSite.Data.Interfaces;
using ExampleWebSite.Models;
using ExampleWebSite.Models.ModelsForProcessing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.Data.Repositories
{
    public class TagRepository : ITagRepository
    {
        private static List<string> PerformTags(string TagsString)
        {
            if (string.IsNullOrEmpty(TagsString)) return null;
            else
            {
                var arr = TagsString.Split(',');
                List<string> list = new List<string>();
                foreach (var item in arr)
                {
                    if (!string.IsNullOrEmpty(item.Trim()))
                        list.Add(item.Trim().Replace(" ", ""));
                }
                return list;
            }
        }
        private bool check(string Tag)
        {
            var tag = _context.Tags.FirstOrDefault(o => o.Title == Tag);
            if (tag != null) return true;
            else return false;
        }

        private readonly ExamWebSiteDBContext _context;
        public TagRepository(ExamWebSiteDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TagModel>> CreateTagsAsync(string TagsString)
        {
            var TagsToReturn = new List<TagModel>();
            var tags = PerformTags(TagsString);
            foreach (var item in tags)
            {
                if (!check(item))
                {
                    await _context.Tags.AddAsync(new TagModel {Title=item});
                    await _context.SaveChangesAsync();
                    TagsToReturn.Add( await _context.Tags.FirstOrDefaultAsync(o=>o.Title==item));
                }
                else 
                    TagsToReturn.Add(await _context.Tags.FirstOrDefaultAsync(o => o.Title == item));
            }
            return TagsToReturn;
        }
        public IEnumerable<TagModel> GetTagsBySearchString(string SearchString, int Quantity)
        {
            return _context.Tags.AsQueryable().Where(o => o.Title.StartsWith(SearchString)).Take(Quantity);
        }
        public IEnumerable<TagModel> GetTagsByItemId(int itemId)
        {
            //            select Tags.Title
            //from Tags inner join ItemTagsrelationships
            //on(Tags.Id = ItemTagsrelationships.TagId)
            //where ItemTagsrelationships.ItemId = 5
            var tags = from s in _context.Tags
                       join sa in _context.ItemTagsrelationships on s.Id equals sa.TagId
                       where sa.TagId == itemId
                       select s;
            return tags.ToList();
        }

        public async Task<IEnumerable<TagPopylarModel>> GetBestPopularTags()
        {

            //Select count(ItemTagsrelationships.ItemId),tagId
            //from ItemTagsrelationships
            //group by ItemTagsrelationships.TagId

            //var Tags =

            return await _context.ItemTagsrelationships.GroupBy(o => o.TagId)
                .Select(o => new TagPopylarModel
                {
                    TagId = o.Key,
                    count = o.Count(),
                    Title = _context.Tags.FirstOrDefault(p => p.Id == o.Key).Title
                }).OrderByDescending(o => o.count).Take(10).ToListAsync();
        }
    }
}
