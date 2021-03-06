﻿using NUnit.Framework;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations;
using Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.EntityTypesConfigurations.Property
{
    [TestFixture]
    internal class AttributeConfigurationTest
    {
        [Test]
        public void Instance_Is_CreatorConfiguration_Of_Attribute()
        {
            //Arrange
            var type = typeof(TravelTypeConfiguration<Attribute>);

            //Act
            var configuration = new AttributeConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}