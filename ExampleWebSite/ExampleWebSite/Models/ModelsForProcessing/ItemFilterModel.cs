using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.Models.ModelsForProcessing
{
    public class ItemFilterModel
    {   [Display(Name="TitleName")]
        [MaxLength(100, ErrorMessage = "MaxLenghtTitle100")]
        public string Title { get; set; } 
        [Display(Name ="From")]
        public DateTime DateFrom { get; set; }
        [Display(Name ="To")]
        public DateTime DateTo { get; set; }
    }
}
