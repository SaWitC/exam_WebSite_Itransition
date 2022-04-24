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
        [Required(ErrorMessage = "Required")]
        [Display(Name = "TitleName")]
        [MaxLength(100, ErrorMessage = "MaxLenghtTitle100"), MinLength(3, ErrorMessage = "MinLenghtTitle3")]
        public string Title { get; set; }
        [MinLength(100, ErrorMessage = "ShortDeskMinLenght100"), MaxLength(1000, ErrorMessage = "ShortDeskMaxLenght1000")]
        [Display(Name = "ShortDeskName")]
        [Required(ErrorMessage = "Required")]
        public string ShortDesc { get; set; }
        [Required(ErrorMessage = "ReqiredThema")]
        [Display(Name = "ThemaTitle")]
        public string ThemaTitle { get; set; }

        public IFormFile ImageFile { get; set; }

    }
}
