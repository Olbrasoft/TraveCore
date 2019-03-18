using NUnit.Framework;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.Configurations
{
    public class TravelTypeConfigurationTest
    {
        [Test]
        public void Instance_Is_TravelTypeConfiguration()
        {
            //Arrange
            var type = typeof(TravelTypeConfiguration<SomeEntityObject>);

            //Act
            var configuration = new SomeTravelTypeConfiguration("", "");

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }

        [Test]
        public void Name()
        {
            //Arrange
            const string schema = "SomeSchemaName";

            //Act
            var configuration = new SomeTravelTypeConfiguration(schema, "");

            //Assert
            Assert.AreEqual(schema, configuration.SchemaName);
        }

        [Test]
        public void Table()
        {
            //Arrange
            const string table = "SomeTableName";

            //Act
            var con = new SomeTravelTypeConfiguration("", table);

            //Assert
            Assert.AreEqual(table, con.TableName);
        }

        [Test]
        public void BuildTable()
        {
            //Arrange
            const string table = nameof(SomeEntityObject) + "s";

            //Act
            var result = TravelTypeConfiguration<SomeEntityObject>.BuildTable();

            //Assert
            Assert.AreEqual(table, result);
        }

        [Test]
        public void BuildSchema()
        {
            //Arrange
            const string schema = nameof(SomeNamespace);

            //Act
            var result = TravelTypeConfiguration<SomeEntityObject>.BuildSchema();

            //Assert
            Assert.AreEqual(schema, result);
        }

        [Test]
        public void DefaultConstructor()
        {
            //Arrange
            const string schema = nameof(SomeNamespace);
            const string table = nameof(SomeEntityObject) + "s";

            //Act
            var configuration = new SomeTravelTypeConfiguration();

            //Assert
            Assert.Multiple(() =>
                {
                    Assert.AreEqual(schema, configuration.SchemaName);
                    Assert.AreEqual(table, configuration.TableName);
                }
            );
        }
    }
}