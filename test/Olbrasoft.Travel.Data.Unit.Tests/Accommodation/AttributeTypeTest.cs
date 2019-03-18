using NUnit.Framework;
using System.Collections.Generic;
using Olbrasoft.Travel.Data.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Accommodation
{
    public class AttributeTypeTest
    {
        [Test]
        public void Attributes()
        {
            //Arrange
            ICollection<Attribute> attributes = new List<Attribute>();

            //Act
            var type = new AttributeType
            {
                Attributes = attributes
            };

            //Assert
            Assert.AreSame(attributes, type.Attributes);
        }
    }
}