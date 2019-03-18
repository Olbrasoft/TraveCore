using NUnit.Framework;
using System.Collections.Generic;
using Olbrasoft.Travel.Data.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Accommodation
{
    public class DescriptionTest
    {
        [Test]
        public void LocalizedPropertyDescriptions()
        {
            //Arrange
            ICollection<LocalizedDescription> localizedDescriptionsOfAccommodations =
                new List<LocalizedDescription>();

            //Act
            var type = new Description
            {
                LocalizedDescriptions = localizedDescriptionsOfAccommodations
            };

            //Assert
            Assert.AreSame(localizedDescriptionsOfAccommodations, type.LocalizedDescriptions);
        }
    }
}