using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.ViewModels.Comments
{
    public class CreateCommentViewModel
    {
        [Required(ErrorMessage = "Required")]
        [MaxLength(500, ErrorMessage = "CommentMessageMaxLen500"), MinLength(20, ErrorMessage = "CommentMessageMinLenght20")]
        public string Message { get; set;}
    }
}
