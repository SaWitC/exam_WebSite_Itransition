using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.Models.AddationalProperts
{
    public class PropertiesModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public CollectionModel Collection { get; set; }
        public int CollectionId { get; set; }
        public ItemModel Item { get; set; }
        public int ItemId { get; set; }
    }
}
