using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Moq;
using NUnit.Framework;
using Olbrasoft.Travel.AspNetCore.Mvc.Controllers;
using Olbrasoft.Travel.Business;
using System.Threading.Tasks;

namespace Olbrasoft.Travel.AspNetCore.Mvc.Unit.Tests
{
    [TestFixture]
    internal class HomeControllerTest
    {
        [Test]
        public void Inherits_From_Controller()
        {
            //Arrange
            var type = typeof(Controller);

            //Act
            var controller = Controller();

            //Assert
            Assert.IsInstanceOf(type, controller);
        }

        private static HomeController Controller()
        {
            var travelMock = new Mock<ITravel>();
            var localizerMock = new Mock<IStringLocalizer<HomeController>>();

            return new HomeController(travelMock.Object, localizerMock.Object);
        }

        [Test]
        public void Index_Return_Task_Of_IActionResult()
        {
            //Arrange
            var controller = Controller();
            var type = typeof(Task<IActionResult>);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOf(type, result);
        }

        [Test]
        public void Continent_Return_Task_Of_IActionResult()
        {
            //Arrange
            var controller = Controller();
            var type = typeof(Task<IActionResult>);

            //Act
            var result = controller.Continent(1);

            //Assert
            Assert.IsInstanceOf(type, result);
        }

        [Test]
        public void Suggestions_Return_Task_Of_JsonResult()
        {
            //Arrange
            var type = typeof(Task<JsonResult>);
            var controller = Controller();
            
            //Act
            var result = controller.Suggestions("Text");

            //Assert
            Assert.IsInstanceOf(type, result);
        }
    }
}