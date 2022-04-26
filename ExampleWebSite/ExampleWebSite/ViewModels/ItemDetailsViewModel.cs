using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleWebSite.Models;

namespace ExampleWebSite.ViewModels
{
    public class ItemDetailsViewModel
    {
        public ItemModel Item { get; set; }
        public IQueryable<CommentModel> comments { get; set; }
    }
}
