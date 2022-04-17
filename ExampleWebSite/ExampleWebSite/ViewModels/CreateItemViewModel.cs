using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ExampleWebSite.Models;

namespace ExampleWebSite.ViewModels
{
    public class CreateItemViewModel
    {
        [Required]
        public ItemModel Item { get; set; }
        [Required]
        public int CollectionId { get; set; }
    }
}
