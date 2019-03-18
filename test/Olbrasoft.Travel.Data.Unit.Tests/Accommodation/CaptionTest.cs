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
            ICollection<LocalizedCaption> localizedCaptions = new[] { new LocalizedCaption() };

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