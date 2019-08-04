using System.Collections.Generic;
using NUnit.Framework;
using Olbrasoft.Travel.Data.Base.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Base.Objects.Accommodation
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