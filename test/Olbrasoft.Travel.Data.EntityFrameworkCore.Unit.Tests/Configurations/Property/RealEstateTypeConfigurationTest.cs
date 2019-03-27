﻿using NUnit.Framework;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.Configurations.Property
{
    [TestFixture]
    internal class RealEstateTypeConfigurationTest
    {
        [Test]
        public void Instance_Is_TravelTypeConfiguration_Of_RealEstateType()
        {
            //Arrange
            var type = typeof(TravelTypeConfiguration<RealEstateCategory>);

            //Act
            var configuration = new RealEstateCategoryConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}