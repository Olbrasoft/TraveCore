﻿using NUnit.Framework;
using Olbrasoft.Travel.Expedia.Affiliate.Network.Data.Transfer.Object.Geography;

namespace Olbrasoft.Travel.Expedia.Affiliate.Network.Unit.Tests.Data.Transfer.Object.Geography
{
    [TestFixture]
    internal class CityNeighborhoodTest
    {
        [Test]
        public void Instance_Implement_Interface_IHaveRegionIdRegionName()
        {
            //Arrange
            var type = typeof(IHaveRegionIdRegionName);

            //Act
            var cityNeighborhood = new CityNeighborhood();

            //Assert
            Assert.IsInstanceOf(type, cityNeighborhood);
        }
    }
}