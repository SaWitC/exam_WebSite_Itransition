using ExampleWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.Data.Interfaces
{
    public interface ITagRepository
    {
        //public IEnumerable<TagModel> GetTagByItemId(int Id);
        //public Task<IEnumerable<TagModel>> GetTagsByItemIdAsync(int Id);
        public IEnumerable<TagModel> GetTagsBySearchString(string SearchString, int Quantity);
        public Task<IEnumerable<TagModel>> CreateTagsAsync(string TagsString);
        public IEnumerable<TagModel> GetTagsByItemId(int id);

    }
}
