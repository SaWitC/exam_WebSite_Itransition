using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleWebSite.Models;

namespace ExampleWebSite.ViewModels
{
    public class CreateCollectionViewModel
    {
        public CollectionModel collection { get; set; }
        public string ThemaTitle { get; set; }

       // public int PropertiesNum { get; set; }
        public IEnumerable<string> PropertiesNumTitles { get; set; }
        public IEnumerable<string> PropertiesStrTitles { get; set; }
        public IEnumerable<string> PropertiesDateTitles { get; set; }


        // public int PropertiesStr { get; set; }
        // public int PropertiesDate { get; set; }

    }
}
