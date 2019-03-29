using NUnit.Framework;
using System.Collections.Generic;
using Olbrasoft.Travel.Data.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Accommodation
{
    public class CaptionTest
    {
        [Test]
        public void MyTestMethod()
        {
            //Arrange
            ICollection<CaptionTranslation> localizedCaptions = new[] { new CaptionTranslation() };

            //Act
            var caption = new Caption
            {
                LocalizedCaptions = localizedCaptions
            };

            //Assert
            Assert.AreSame(localizedCaptions, caption.LocalizedCaptions);
        }
    }
}