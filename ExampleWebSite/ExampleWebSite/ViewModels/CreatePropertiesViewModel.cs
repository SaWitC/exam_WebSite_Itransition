using ExampleWebSite.Models.AddationalProperts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.ViewModels
{
    public class CreatePropertiesViewModel
    {
        public IEnumerable<PropertiesModel> properties { get; set; }
    }
}
