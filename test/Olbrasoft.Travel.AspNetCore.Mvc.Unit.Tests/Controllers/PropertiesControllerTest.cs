using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Olbrasoft.Travel.AspNetCore.Mvc.Controllers;
using Olbrasoft.Travel.Business;

namespace Olbrasoft.Travel.AspNetCore.Mvc.Unit.Tests.Controllers
{
    public class PropertiesControllerTest
    {
        [Test]
        public void Instance_Is_Controller()
        {
            //Arrange
            var type = typeof(Controller);

            //Act
            var controller = Create();

            //Assert
            Assert.IsInstanceOf(type, controller);
        }

        private static PropertiesController Create()
        {
            var propertyServiceMock = new Mock<IProperties>();
            var controller = new PropertiesController(propertyServiceMock.Object);
            return controller;
        }

        [Test]
        public void ByRegion()
        {
            //Arrange
            var type = typeof(Task<IActionResult>);
            var controller = Create();


            //Act
            var result = controller.ByRegion(1);

            //Assert
            Assert.IsInstanceOf(type,result);
        }

    }
}