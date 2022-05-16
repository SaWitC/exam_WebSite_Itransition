using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ExampleWebSite.Models.AddationalProperts;
using Microsoft.AspNetCore.Http;

namespace ExampleWebSite.Models
{
    public class CollectionModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name = "TitleName")]
        [MaxLength(100,ErrorMessage = "MaxLenghtTitle100"),MinLength(3,ErrorMessage = "MinLenghtTitle3")]
        public string Title { get; set; }
        [MinLength(100,ErrorMessage = "ShortDeskMinLenght100"),MaxLength(1000,ErrorMessage = "ShortDeskMaxLenght1000")]
        [Required(ErrorMessage = "Required")]
        [Display(Name = "ShortDeskName")]
        public string ShortDesc { get; set; }
        [ForeignKey("ThemaId")]
        public ThemaModel Thema { get; set; }
        public int ThemaId { get; set; }
        public string Image { get; set; }
        public IEnumerable<ItemModel> Items { get; set; }
        public string AvtorName { get;set; }
        public IEnumerable<PropertiesModel> OptionalPropertiesTemplate { get; set; }
        public string ImageLink { get; set; }
        public int ItemCount { get; set; } = 0;
    }
}
