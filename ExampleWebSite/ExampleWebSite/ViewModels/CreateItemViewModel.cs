using ExampleWebSite.Models;
using ExampleWebSite.Models.AddationalProperts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.ViewModels
{
    public class CreateItemViewModel
    {
        [Required]
        public ItemModel Item { get; set; }
        public IEnumerable<PropertiesModel> TypicalElements { get; set; }

        public List<PropertiesElementModel> Properties { get; set; }
        public int collectionId { get; set; }
    }
}
