using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleWebSite.Models;
using ExampleWebSite.Models.AddationalProperts;

namespace ExampleWebSite.ViewModels.Items
{
    public class ItemDetailsViewModel
    {
        public ItemModel Item { get; set; }
        public IEnumerable<PropertiesElementModel> Properties { get; set; }
        public IQueryable<CommentModel> comments { get; set; }
        public IEnumerable<TagModel> Tags { get; set; } = null;

        public string AvtorName { get; set; }

    }
}
