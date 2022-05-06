using ExampleWebSite.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.ViewModels.Collections.Admin
{
    public class AdminCreateCollectionViewModel
    {
        public CollectionModel collection { get; set; }
        [Display(Name = "ThemaTitle")]
        [Required(ErrorMessage = "ReqiredThema")]
        public string ThemaTitle { get; set; }
        public IEnumerable<string> PropertiesNumTitles { get; set; }
        public IEnumerable<string> PropertiesStrTitles { get; set; }
        public IEnumerable<string> PropertiesDateTitles { get; set; }
        public IEnumerable<string> PropertiesBoolTitles { get; set; }
        public IFormFile ImageFile { get; set; }
        public string AvtorName { get; set; } = null;
    }
}
