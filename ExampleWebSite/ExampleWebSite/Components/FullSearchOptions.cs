using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Korzh.EasyQuery;
using Korzh;
using Korzh.EasyQuery.Linq;
using ExampleWebSite.Models;
using ExampleWebSite.Models.AddationalProperts;

namespace ExampleWebSite.Components
{
    public class FullSearchOptions
    {
        public static readonly FullTextSearchOptions fullTextSearchItemsOptions = new FullTextSearchOptions
        {
            Depth = 2,
            Filter = (propInfo) =>
            {
                if (propInfo.DeclaringType == typeof(ItemModel))
                {
                    return propInfo.PropertyType == typeof(string);
                }
                else if (propInfo.PropertyType == typeof(string))
                {
                    if (propInfo.DeclaringType == typeof(CommentModel))
                    {
                        return propInfo.Name == "Message" || propInfo.Name == "AvtorName";
                    }
                    else if (propInfo.DeclaringType == typeof(PropertiesElementModel))
                    {
                        return propInfo.Name == "Value";
                    }
                }
                return false;
            }
        };
        public static readonly FullTextSearchOptions fullTextSearchCollectionOptions = new FullTextSearchOptions 
        {

            Depth = 2,
            Filter = (propInfo) =>
            {
                if (propInfo.DeclaringType == typeof(CollectionModel))
                {
                    return propInfo.PropertyType == typeof(string);
                }

                return false;
            }
        };
    }
}
