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

namespace ExampleWebSite.Test.Controllers.Tests
{
    public class ThemeController_Test
    {
        [Fact]
        public async Task GetThemesReturnsThemes()
        {
            //arrange

            var mock = new Mock<IThemeRepository>();
            mock.Setup(repo => repo.TakeAll()).Returns(TestData_forControllers.ReturnTestThemes());
            var controller = new ThemeController(mock.Object);
            //act

            var result = await controller.GetThemes();
            //var model = result.Resul

            //assert
           // await Assert.IsType<Task<IEnumerable<ThemaModel>>>(result);
            //var model = Assert.IsAssignableFrom<IEnumerable<ThemaModel>>(result);
            //Assert.Equal(result,TestData_forControllers.ReturnTestThemes());

            var viewResult = Assert.IsType<IEnumerable<ThemaModel>>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<ThemaModel>>(viewResult);
            //Assert.Equal(2, model.Count());

        }
    }
}
