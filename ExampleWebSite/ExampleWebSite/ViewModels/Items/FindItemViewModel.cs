using ExampleWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.ViewModels.Items
{
    public class FindItemViewModel
    {
        public string TagString { get; set; }
        public IEnumerable<ItemModel> items {get;set;}
    }
}
