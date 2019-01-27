using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Olbrasoft.Travel.AspNetCore.Mvc.Components;
using System.Threading.Tasks;

namespace Olbrasoft.Travel.AspNetCore.Mvc.Unit.Tests.Components
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    internal class UICultureSelectorViewComponentTest
    {
        [Test]
        public void Instance_Is_ViewComponent()
        {
            //Arrange
            var type = typeof(ViewComponent);

            //Act
            var component = Component();

            //Assert
            Assert.IsInstanceOf(type, component);
        }

        private static UICultureSelectorViewComponent Component()
        {
            return new UICultureSelectorViewComponent();
        }

        [Test]
        public void InvokeAsync_Return_Task_Of_IViewComponentResult()
        {
            //Arrange
            var type = typeof(Task<IViewComponentResult>);
            var component = Component();

            //Act
            var result = component.InvokeAsync();

            //Assert
            Assert.IsInstanceOf(type, result);
        }
    }
}