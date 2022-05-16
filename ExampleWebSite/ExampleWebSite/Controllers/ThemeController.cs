using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleWebSite.Models;
using ExampleWebSite.Data.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace ExampleWebSite.Controllers
{
    public class ThemeController : Controller
    {
        private readonly IThemeRepository _theme;
        private readonly IMemoryCache _cache;
        public ThemeController(IThemeRepository theme,IMemoryCache cache)
        {
            _cache = cache;
            _theme = theme;
        }
        [ResponseCache(Duration =30000,Location =ResponseCacheLocation.Any)]
        public async Task<IEnumerable<ThemaModel>> GetThemes()
        {
            if (_cache.Get("Themes") != null)
                return _cache.Get("Themes") as IEnumerable<ThemaModel>;
            
            _cache.Set("Themes",await _theme.TakeAllAsync());
            return _cache.Get("Themes") as IEnumerable<ThemaModel>;
        }
    }
}
