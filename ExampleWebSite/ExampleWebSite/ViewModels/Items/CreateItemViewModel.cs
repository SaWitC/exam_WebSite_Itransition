using ExampleWebSite.Models;
using ExampleWebSite.Models.AddationalProperts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.ViewModels.Items
{
    public class CreateItemViewModel
    {
        [Required]
        public ItemModel Item { get; set; }
        public IEnumerable<PropertiesModel> TypicalElements { get; set; }
        public List<PropertiesElementModel> Properties { get; set; }
        [MaxLength(40,ErrorMessage = "TagsMaxLenght40")]
        public string Tags { get; set; }
        public int collectionId { get; set; }
    }
}
