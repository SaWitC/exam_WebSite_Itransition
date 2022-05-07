using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.Models
{
    public class TagModel
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        //public IEnumerable<ItemModel> Items { get; set; }
    }
}
