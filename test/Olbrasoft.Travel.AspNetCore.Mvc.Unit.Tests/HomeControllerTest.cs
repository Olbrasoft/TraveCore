using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Olbrasoft.Travel.AspNetCore.Mvc.Controllers;
using Olbrasoft.Travel.Business;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;

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
            var regionsMock = new Mock<IRegions>();
            var localizerMock =new Mock<IStringLocalizer<HomeController>>();

            return new HomeController(regionsMock.Object,localizerMock.Object);
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
    }
}