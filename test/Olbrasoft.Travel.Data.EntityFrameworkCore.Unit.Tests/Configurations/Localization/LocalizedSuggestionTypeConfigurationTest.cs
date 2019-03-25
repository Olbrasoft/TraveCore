using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Localization;
using Olbrasoft.Travel.Data.Localization;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.Configurations.Localization
{
    public class LocalizedSuggestionTypeConfigurationTest
    {
        [Test]
        public void Instance_Is_TravelTypeConfiguration_Of_LocalizedSuggestionType()
        {
            //Arrange
            var type = typeof(TravelTypeConfiguration<LocalizedSuggestionType>);

            //Act
            var configuration = new LocalizedSuggestionTypeConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}