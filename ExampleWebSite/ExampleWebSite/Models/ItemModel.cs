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
        //[MaxLength(40,ErrorMessage = "MaxLenghtItemTitle40"),MinLength(3,ErrorMessage = "MinLenghtTitle3")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name ="TagsName")]
        public string Tags { get; set; }
        public int CollectionId { get; set; }
        [ForeignKey("CollectionId")]
        //[Required(ErrorMessage = "Required")]
        public CollectionModel Collection { get; set; }

        //additional property
        public IEnumerable<PropertiesElementModel> Additionalproperties { get; set; }
    }
}
