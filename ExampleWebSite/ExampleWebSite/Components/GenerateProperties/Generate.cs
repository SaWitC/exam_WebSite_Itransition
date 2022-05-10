using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleWebSite.Data.Interfaces;
using ExampleWebSite.Models.AddationalProperts;

namespace ExampleWebSite.Components.GenerateProperties
{
    public class Generate
    {
        private readonly ICollectionRepository _collection;
        private readonly IpropertiesModelRepository _propertiesModel;

        public Generate(ICollectionRepository collection, IpropertiesModelRepository properties)
        {
            _collection = collection;
            _propertiesModel = properties;
        }
        public async Task GeneratePropertiesAsync(int collectionId,IEnumerable<string> PropertiesTitles,string Datatype)
        {
            var collection = await _collection.FindByIdAsync(collectionId);
            if (collection != null && PropertiesTitles != null && PropertiesTitles.Count() > 0)
            {
                List<PropertiesModel> elements = new List<PropertiesModel>();
                foreach (var item in PropertiesTitles)
                {
                    elements.Add(new PropertiesModel { Collection = collection, Title = item, Type = Datatype });
                }
                _propertiesModel.AddRange(elements);
            }
        }
    }
}
