using System.Collections.Generic;
using NUnit.Framework;
using Olbrasoft.Travel.Data.Base.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Base.Objects.Accommodation
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