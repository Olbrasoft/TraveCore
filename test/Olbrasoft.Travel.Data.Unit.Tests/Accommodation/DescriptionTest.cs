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
            ICollection<DescriptionTranslation> localizedDescriptionsOfAccommodations =
                new List<DescriptionTranslation>();

            //Act
            var type = new Description
            {
                DescriptionTranslations = localizedDescriptionsOfAccommodations
            };

            //Assert
            Assert.AreSame(localizedDescriptionsOfAccommodations, type.DescriptionTranslations);
        }
    }
}