using AutoMapper;
using NUnit.Framework;
using Olbrasoft.Travel.Data.Mapping;

namespace Olbrasoft.Travel.Data.Unit.Tests.Mapping
{
    [TestFixture]
    public class MapperConfigurationProviderTest
    {
        [Test]
        public void Instance_Is_MapperConfiguration()
        {
            //Arrange
            var type = typeof(MapperConfiguration);

            //Act
            var provider = new MapperConfigurationProvider();

            //Assert
            Assert.IsInstanceOf(type, provider);
        }
    }
}