﻿using AutoMapper;
using NUnit.Framework;
using Olbrasoft.Travel.Data.Mapping.Profiles;

namespace Olbrasoft.Travel.Data.Unit.Tests.Mapping.Profiles
{
    public class LocalizedRegionToSuggestionTest
    {
        [Test]
        public void Instance_Is_Profile()
        {
            //Arrange
            var type = typeof(Profile);

            //Act
            var profile = new LocalizedRegionToSuggestion();

            //Assert
            Assert.IsInstanceOf(type, profile);
        }
    }
}