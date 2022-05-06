using ExampleWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ExampleWebSite.Controllers.ItemController;

namespace ExampleWebSite.ViewModels.Items
{
    public class FindItemsViewModel
    {
        public IEnumerable<ThemaModel> Items { get; set; }
        public string SearchString { get; set; }
    }
}
