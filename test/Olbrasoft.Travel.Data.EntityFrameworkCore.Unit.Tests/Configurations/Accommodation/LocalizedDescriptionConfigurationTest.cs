﻿using NUnit.Framework;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.Configurations.Accommodation
{
    [TestFixture]
    internal class LocalizedDescriptionConfigurationTest
    {
        [Test]
        public void Instance_Is_PropertyConfiguration_Of_Description()
        {
            //Arrange
            var type = typeof(TravelTypeConfiguration<LocalizedDescription>);

            //Act
            var configuration = new LocalizedDescriptionConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}