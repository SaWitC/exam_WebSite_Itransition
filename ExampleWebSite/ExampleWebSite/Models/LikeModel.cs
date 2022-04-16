using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.Models
{
    public class LikeModel
    {
        public string UserId { get; set; }
        public ItemsModel Item { get; set; }
        public int ItemId { get; set; }
        public bool IsLiked { get; set; }
    }
}
