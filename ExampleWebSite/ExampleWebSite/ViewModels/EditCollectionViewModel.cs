using ExampleWebSite.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.ViewModels
{
    public class EditCollectionViewModel
    {
        [Required]
        public int Collectionid { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string ShortDesc { get; set; }
        [Required]
        public string ThemaTitle { get; set; }

        public IFormFile ImageFile { get; set; }

    }
}
