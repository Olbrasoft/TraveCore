﻿using AutoMapper;
using NUnit.Framework;
using Olbrasoft.Travel.Data.Mapping.Profiles;

namespace Olbrasoft.Travel.Data.Unit.Tests.Mapping.Profiles
{
    [TestFixture]
    internal class LocalizedRegionToCountryItemTest
    {
        [Test]
        public void Instance_Is_Profile()
        {
            //Arrange
            var type = typeof(Profile);

            //Act
            var profile = new LocalizedRegionToCountryItem();

            //Assert
            Assert.IsInstanceOf(type, profile);
        }
    }
}