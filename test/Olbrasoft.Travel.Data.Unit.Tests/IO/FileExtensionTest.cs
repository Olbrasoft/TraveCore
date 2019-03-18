using System.Collections.Generic;
using NUnit.Framework;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.IO;

namespace Olbrasoft.Travel.Data.Unit.Tests.IO
{
    public class FileExtensionTest
    {
        [Test]
        public void AccommodationPhotos()
        {
            //Arrange
            var photos = new List<Photo>();

            //Act
            var extension = new FileExtension
            {
                PhotosOfAccommodations = photos
            };

            //Assert
            Assert.AreSame(photos, extension.PhotosOfAccommodations);
        }
    }
}