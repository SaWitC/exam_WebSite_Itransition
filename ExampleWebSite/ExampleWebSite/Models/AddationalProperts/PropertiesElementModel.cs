using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.Models.AddationalProperts
{
    public class PropertiesElementModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        [ForeignKey("ItemId")]
        public ItemModel Item { get; set; }
        public int ItemId { get; set; }
    }
}
