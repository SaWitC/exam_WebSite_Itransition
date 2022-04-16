using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.Models
{
    public class CollectionModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDesc { get; set; }
        public ThemaModel Thema { get; set; }
        public int ThemaId { get; set; }
        public string Image { get; set; }
        public IEnumerable<ItemsModel> Items { get; set; }
    }
}
