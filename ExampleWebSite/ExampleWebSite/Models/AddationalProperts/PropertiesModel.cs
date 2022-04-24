using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ExampleWebSite.Models.AddationalProperts;

namespace ExampleWebSite.Models.AddationalProperts
{
    public class PropertiesModel
    {
        public int Id { get; set; }
        //public IEnumerable<PropertiesElementModel> PropertiesElements { get; set; }
        public CollectionModel Collection { get; set; }
        public int CollectionId { get; set; }
        //public ItemModel Item { get; set; }
        //public int ItemId { get; set; }

        [Display]
        [Required(ErrorMessage = "Required")]
        [MinLength(3,ErrorMessage = "PropertiesElemTitleMinLenght3"),MaxLength(30,ErrorMessage = "PropertiesElemTitleMaxLenght30")]
        public string Title { get; set; }

        public string Type { get; set; }
    }
}
