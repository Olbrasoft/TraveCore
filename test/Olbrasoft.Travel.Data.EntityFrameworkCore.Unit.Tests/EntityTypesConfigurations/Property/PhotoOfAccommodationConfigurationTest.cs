using NUnit.Framework;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations;
using Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.EntityTypesConfigurations.Property
{
    [TestFixture]
    internal class PhotoOfAccommodationConfigurationTest
    {
        [Test]
        public void Instance_Is_CreatorConfiguration_Of_PhotoOfAccommodation()
        {
            //Arrange
            var type = typeof(TravelTypeConfiguration<Photo>);

            //Act
            var configuration = new PhotoConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }

        //[Test]
        //public void Instance_Is_PropertyConfiguration_Of_PhotoOfAccommodation()
        //{
        //    //Arrange
        //    var type = typeof(AccommodationTypeConfiguration<Photo>);

        //    //Act
        //    var configuration = new PhotoConfiguration();

        //    //Assert
        //    Assert.IsInstanceOf(type, configuration);
        //}
    }
}