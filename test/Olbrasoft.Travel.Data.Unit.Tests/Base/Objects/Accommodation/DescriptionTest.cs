using System.Collections.Generic;
using NUnit.Framework;
using Olbrasoft.Travel.Data.Base.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Base.Objects.Accommodation
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