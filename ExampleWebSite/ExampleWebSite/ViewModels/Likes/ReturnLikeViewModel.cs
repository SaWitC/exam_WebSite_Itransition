using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.ViewModels.Likes
{
    public class ReturnLikeViewModel
    {
        public bool Status { get; set; }
        public int Count { get; set; }
        public string Message { get; set; } = "";
    }
}
