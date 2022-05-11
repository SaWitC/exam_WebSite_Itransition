using ExampleWebSite.Models;
using ExampleWebSite.Models.ModelsForProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ExampleWebSite.Controllers.ItemController;

namespace ExampleWebSite.ViewModels.Items
{
    public class FindItemsByTextViewModel
    {
        public string SearchString { get; set; }
        public IEnumerable<SearchResoultModel> SearchResoultModels { get; set; }

    }
}
