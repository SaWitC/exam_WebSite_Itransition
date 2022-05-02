using AutoFixture;
using ExampleWebSite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleWebSite.Test.TestData
{
    public static class TestData_forControllers
    {
        public static IEnumerable<ThemaModel> ReturnTestThemes()
        {
            return new List<ThemaModel> { new ThemaModel { Id = 1, Title = "first", Description = "First theme", IsActiv = true } ,
            new ThemaModel { Id = 2, Title = "second", Description = "second theme", IsActiv = true }};
        }

        public static ItemModel ReturnItemModel()
        {
            var item = new Fixture().Create<ItemModel>();
            return item;
        }
    }
}
