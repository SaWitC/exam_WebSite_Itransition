using System;
using System.Collections.Generic;
using System.Text;
using ExampleWebSite.Data.Interfaces;
using Moq;
using ExampleWebSite.Test.TestData;
using ExampleWebSite.Controllers;
using Xunit;
using System.Threading.Tasks;
using ExampleWebSite.Models;
using ExampleWebSite.Data;
using Microsoft.AspNetCore.Mvc;

namespace ExampleWebSite.Test.Controllers.Tests
{
    public class ItemController_Test
    {
        [Fact]
        public void DetailsReturnsItemModel()
        {
            //arrange

            var ItemMock = new Mock<IItemRepository>();//
            var CollectionMock = new Mock<ICollectionRepository>();////
            var PropertiesElementMock = new Mock<IpropertiesElementsRepository>();///
            var PropertiesModelMock = new Mock<IpropertiesModelRepository>();/////
            var CommentMock = new Mock<ICommentRepository>();//////
            var ContextMock = new Mock<ExamWebSiteDBContext>();////////

            ItemMock.Setup(r=>r.GetItemById(1)).Returns(TestData_forControllers.ReturnItemModel);

            //mock.Setup(repo => repo.TakeAll()).Returns(TestData_forControllers.ReturnTestThemes());
            var controller = new ItemController(ItemMock.Object, PropertiesElementMock.Object,CollectionMock.Object,PropertiesModelMock.Object,CommentMock.Object,ContextMock.Object);
            //act

            var result = controller.Details(1,0);
            //var model = result.Resul

            //assert
            Assert.IsType<ViewResult>(result);
           // var model = Assert.IsAssignableFrom<IEnumerable<ThemaModel>>(result.Result);
        }
    }
}
