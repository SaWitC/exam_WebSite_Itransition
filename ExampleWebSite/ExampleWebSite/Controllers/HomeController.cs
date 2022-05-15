using ExampleWebSite.Data.Interfaces;
using ExampleWebSite.Models;
using ExampleWebSite.ViewModels;
using ExampleWebSite.ViewModels.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICollectionRepository _collection;
        public HomeController(ILogger<HomeController> logger,ICollectionRepository collection)
        {
            _logger = logger;
            _collection = collection;
        }

        public IActionResult Index()
        {
            try
            {
                CollectionDetailsViewModel model = _collection.GetCollectionWithMaxItims();
                return View(model);
            }
            catch
            {
                return View(null);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ToMessage(ToMessageViewModel MessageModel)
        {
            return View(MessageModel);
        }
    }
}
