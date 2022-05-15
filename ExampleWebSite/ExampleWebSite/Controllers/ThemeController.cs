using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleWebSite.Models;
using ExampleWebSite.Data.Interfaces;

namespace ExampleWebSite.Controllers
{
    public class ThemeController : Controller
    {
        private readonly IThemeRepository _theme;
        public ThemeController(IThemeRepository theme)
        {
            _theme = theme;
        }
        [ResponseCache(Duration =30000,Location =ResponseCacheLocation.Any)]
        public async Task<IEnumerable<ThemaModel>> GetThemes()
        {
            return await _theme.TakeAllAsync();
        }
    }
}
