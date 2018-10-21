﻿using NUnit.Framework;

namespace Olbrasoft.TravelCore.Expedia.Affiliate.Network.Unit.Tests
{
    [TestFixture]
    internal class ParserFactoryTest
    {
        [Test]
        public void Instance_Implement_Interface_IParserFactory()
        {
            //Arrange
            var type = typeof(IParserFactory);

            //Act
            var factory = new ParserFactory();

            //Assert
            Assert.IsInstanceOf(type, factory);
        }
    }
}