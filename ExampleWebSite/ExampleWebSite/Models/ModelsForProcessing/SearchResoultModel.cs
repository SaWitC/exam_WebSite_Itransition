using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.Models.ModelsForProcessing
{
    public class SearchResoultModel
    {
        public string Title { get; set; }
        public bool InProperties { get; set; }
        public bool InComments { get; set; }
        public string Type { get; set; }
        public int id { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is SearchResoultModel test) if (Type == test.Type && id == test.id) return true;
            return false;
        }
        public override int GetHashCode() => Type.GetHashCode();
    }
}
