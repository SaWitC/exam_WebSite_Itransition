using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.Models
{
    public class CommentModel
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "Required")]
        //[MaxLength(500,ErrorMessage = "CommentMessageMaxLen500"),MinLength(20,ErrorMessage = "CommentMessageMinLenght20")]
        public string Message { get; set; }
        public string AvtorName { get; set; }
        public string AvtorId { get; set; }
        [ForeignKey("AvtorId")]
        public User Avtor{get;set;}
        [ForeignKey("ItemId")]
        public ItemModel Item { get; set; }
        public int ItemId { get; set; }
    }
}
