using System.Collections.Generic;
using NUnit.Framework;
using Olbrasoft.Travel.Data.Base.Objects.Accommodation;
using Olbrasoft.Travel.Data.Base.Objects.IO;

namespace Olbrasoft.Travel.Data.Unit.Tests.Base.Objects.IO
{
    public class PathToPhotoTest
    {
        [Test]
        public void MyTestMethod()
        {
            //Arrange
            var photos = new List<Photo>();

            //Act
            var path = new PathToPhoto
            {
                AccommodationPhotos = photos
            };


            //Assert
            Assert.AreSame(photos, path.AccommodationPhotos);
        }
    }
}