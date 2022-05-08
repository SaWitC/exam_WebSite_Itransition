using ExampleWebSite.Models;
using ExampleWebSite.Models.AddationalProperts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.ViewModels.Items
{
    public class EditItemViewModel
    {
        [Required]
        
        public string Title { get; set; }
        public int itemId { get; set; }
        public IEnumerable<PropertiesElementModel> Properties { get; set; }
        [MaxLength(40, ErrorMessage = "TagsMaxLenght40")]
        public string Tags { get; set; }
        public int collectionId { get; set; }
    }
}
