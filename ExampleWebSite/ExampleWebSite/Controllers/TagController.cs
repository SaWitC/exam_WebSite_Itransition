using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleWebSite.Data.Interfaces;
using ExampleWebSite.Models;

namespace ExampleWebSite.Controllers
{
    public class TagController
    {
        private readonly ITagRepository _tag;
        public TagController(ITagRepository tag)
        {
            _tag = tag;
        }
        public IEnumerable<TagModel> GetTags(string SearchString)
        {
            return _tag.GetTagsBySearchString(SearchString, 5);
        }
    }
}
