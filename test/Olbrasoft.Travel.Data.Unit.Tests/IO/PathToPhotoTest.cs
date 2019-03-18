using System.Collections.Generic;
using NUnit.Framework;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.IO;

namespace Olbrasoft.Travel.Data.Unit.Tests.IO
{
    public class PathToPhotoTest
    {
        [NUnit.Framework.Test]
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