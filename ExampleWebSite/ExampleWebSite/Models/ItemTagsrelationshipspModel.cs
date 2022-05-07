using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.Models
{
    public class ItemTagsrelationshipspModel
    {
        [Key]
        public int Id { get; set; }
        //public IEnumerable<TagModel> Tags { get; set; }
        [ForeignKey("ItemId")]
        public ItemModel Item { get; set; }
        public int ItemId { get; set; }
        public TagModel Tag { get; set; }
        public int TagId { get; set; }
    }
}
