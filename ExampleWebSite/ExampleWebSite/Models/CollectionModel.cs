using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ExampleWebSite.Models.AddationalProperts;

namespace ExampleWebSite.Models
{
    public class CollectionModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string ShortDesc { get; set; }
        [ForeignKey("ThemaId")]
        public ThemaModel Thema { get; set; }
        public int ThemaId { get; set; }
        public string Image { get; set; }
        public IEnumerable<ItemModel> Items { get; set; }
        public string AvtorName { get;set; }
        //
        //public PropertiesModel model { get; set; }

        public IEnumerable<PropertiesModel> OptionalPropertiesTemplate { get; set; }

        //public IEnumerable<>
    }
}
