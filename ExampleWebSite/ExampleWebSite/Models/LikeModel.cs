using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.Models
{
    public class LikeModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("UserId")]
        public string User { get; set; }
        public string UserId { get; set; }
        [ForeignKey("ItemId")]
        public ItemsModel Item { get; set; }
        public int ItemId { get; set; }
        public bool IsLiked { get; set; }
    }
}
