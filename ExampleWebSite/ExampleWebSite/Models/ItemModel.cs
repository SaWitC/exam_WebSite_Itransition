﻿using ExampleWebSite.Models.AddationalProperts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.Models
{
    public class ItemModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Tags { get; set; }

        //additional property
        public IEnumerable<PropertiesModel> Additionalproperties { get; set; }
    }
}
