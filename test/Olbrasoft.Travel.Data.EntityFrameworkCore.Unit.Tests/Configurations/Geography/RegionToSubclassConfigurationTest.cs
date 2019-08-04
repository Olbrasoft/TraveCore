using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Olbrasoft.Travel.Data.Base.Objects.Geography;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Geography;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.Configurations.Geography
{
    [TestFixture]
    public class RegionToSubclassConfigurationTest
    {
        [Test]
        public void Instance_Is_EntityTypeConfiguration()
        {
            //Arrange
            var type = typeof(IEntityTypeConfiguration<RegionToSubclass>);

            //Act
            var configuration = new RegionToSubclassConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}