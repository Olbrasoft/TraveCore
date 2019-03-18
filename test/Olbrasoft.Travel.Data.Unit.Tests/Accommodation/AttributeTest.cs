using NUnit.Framework;
using Olbrasoft.Travel.Data.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Accommodation
{
    public class AttributeTest
    {
        [Test]
        public void TypeId()
        {
            //Arrange
            const int id = 1976;

            //Act
            var attribute = new Attribute
            {
                TypeId = id
            };

            //Assert
            Assert.AreEqual(id, attribute.TypeId);
        }

        [Test]
        public void SubtypeId()
        {
            const int id = 1976;

            //Act
            var attribute = new Attribute
            {
                SubtypeId = id
            };

            //Assert
            Assert.AreEqual(id, attribute.SubtypeId);
        }

        [Test]
        public void Subtype()
        {
            //Arrange
            var type = new AttributeSubtype();

            //Act
            var attribute = new Attribute
            {
                Subtype = type
            };

            //Assert
            Assert.AreSame(type, attribute.Subtype);
        }


    }
}