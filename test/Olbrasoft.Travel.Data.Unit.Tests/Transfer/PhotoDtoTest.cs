using NUnit.Framework;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Unit.Tests.Transfer
{
    public class PhotoDtoTest
    {
        [Test]
        public void Is_Abstract()
        {
            //Arrange
            var type = typeof(PhotoDto);

            //Act
            var result = type.IsAbstract;

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void AwesomePhotoDto_Is_PhotoDto()
        {
            //Arrange
            var type = typeof(PhotoDto);

            //Act
            var photo = CreatePhoto();

            //Assert
            Assert.IsInstanceOf(type, photo);
        }

        private static AwesomePhotoDto CreatePhoto()
        {
            var photo = new AwesomePhotoDto();
            return photo;
        }

        [Test]
        public void Path()
        {
            //Arrange
            const string path = "Awesome/Path";
            PhotoDto photo = CreatePhoto();

            //Act
            photo.Path = path;

            //Assert
            Assert.AreEqual(path, photo.Path);
        }

        [Test]
        public void Name()
        {
            //Arrange
            const string name = "Awesome name";
            PhotoDto photo = new AwesomePhotoDto();

            //Act
            photo.Name = name;

            //Assert
            Assert.AreEqual(name, photo.Name);
        }
    }

    public class AwesomePhotoDto : PhotoDto
    {
    }
}