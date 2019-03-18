using NUnit.Framework;
using Olbrasoft.Travel.Data.Repositories;

namespace Olbrasoft.Travel.Providers.Expedia.Import.Unit.Tests
{
    [TestFixture]
    public class ConsoleLoggerTest
    {
        [Test]
        public void Instance_Implement_Interface_ILoggingImports()
        {
            //Arrange
            var type = typeof(ILoggingImports);

            //Act
            var logger = new ConsoleLogger();

            //Assert
            Assert.IsInstanceOf(type, logger);
        }
    }
}