﻿using NUnit.Framework;
using Olbrasoft.Travel.Data.Entity.Configuration.Geography;
using Olbrasoft.Travel.Data.Entity.Configuration.Property;
using Olbrasoft.Travel.Data.Entity.Property;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Unit.Tests.Property
{
    [TestFixture]
    internal class TypeOfDescriptionConfigurationTest
    {
        [Test]
        public void Instance_Is_NameConfiguration_Of_TypeOfDescription()
        {
            //Arrange
            var type = typeof(Configuration.Property.NameConfiguration<TypeOfDescription>);

            //Act
            var configuration = new TypeOfDescriptionConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}