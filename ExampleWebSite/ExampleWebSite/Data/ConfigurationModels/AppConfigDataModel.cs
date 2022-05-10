using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.Data.ConfigurationModels
{
    public class AppConfigDataModel
    {
        public string YandexToken { get; set; }
        public string CommentSize { get; set; } ="8";
        public string ItemSize { get; set; } = "4";
        public string CollectionSize { get; set; } = "5";
        public string UserSize { get; set; } = "10";

    }
}
