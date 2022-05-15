using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleWebSite.Data.Interfaces;
using ExampleWebSite.Models;
using ExampleWebSite.Models.ModelsForProcessing;
using Microsoft.AspNetCore.Mvc;

namespace ExampleWebSite.Controllers
{
    public class TagController: Microsoft.AspNetCore.Mvc.Controller
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
        [ResponseCache(Duration =3000,Location =ResponseCacheLocation.Any)]
        public async Task<IActionResult> GetBestPopylarTags()
        {
            var model = await _tag.GetBestPopularTags();
            return View(model);
        }
        public async Task<IEnumerable<TagPopylarModel>> GetBestPopylarTags2()
        {
            var model = await _tag.GetBestPopularTags();
            return model;
        }
    }
}
