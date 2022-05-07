using ExampleWebSite.Models.AddationalProperts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.Models
{
    public class ItemModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name = "ItemTitle")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name ="TagsName")]
        public int CollectionId { get; set; }
        [ForeignKey("CollectionId")]
        public CollectionModel Collection { get; set; }
        public IEnumerable<ItemTagsrelationshipspModel> Tags { get; set; }
        public IEnumerable<PropertiesElementModel> Additionalproperties { get; set; }
    }
}
