using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleWebSite.Data.Interfaces;
using ExampleWebSite.Models;
using ExampleWebSite.Models.ModelsForProcessing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace ExampleWebSite.Controllers
{
    public class TagController: Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ITagRepository _tag;
        private readonly IMemoryCache _cache;
        public TagController(ITagRepository tag,IMemoryCache cache)
        {
            _tag = tag;
            _cache = cache;
        }
        public IEnumerable<TagModel> GetTags(string SearchString)
        {
            return _tag.GetTagsBySearchString(SearchString, 5);
        }
        [ResponseCache(Duration =1000,Location =ResponseCacheLocation.Any)]
        public async Task<IEnumerable<TagPopylarModel>> GetBestPopylarTags()
        {
            var Model = _cache.Get("BestPopylarTags");
            if (Model == null)
            {
                var model = await _tag.GetBestPopularTags();
                _cache.Set("BestPopylarTags", model);
                return model;
            }
            return Model as IEnumerable<TagPopylarModel>;
        }

    }
}
