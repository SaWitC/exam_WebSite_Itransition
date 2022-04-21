using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleWebSite.Models;
using ExampleWebSite.Data;


namespace ExampleWebSite.ViewModels
{
    public class CollectionDetailsViewModel
    {
        public CollectionModel collection { get; set; }
        public IEnumerable<ItemModel> items { get; set; }

        public string ImageUrl { get; set; }
    }
}
