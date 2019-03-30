using NUnit.Framework;
using Olbrasoft.Travel.Data.Transfer.Objects;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Transfer.Objects.Accommodation
{
    [TestFixture]
    internal class PropertyPhotoDtoTest
    {
        [Test]
        public void Instance_Is_PhotoDto()
        {
            //Arrange
            var type = typeof(PhotoDto);

            //Act
            var photo = new PropertyPhotoDto();

            //Assert
            Assert.IsInstanceOf(type, photo);
        }

        [Test]
        public void Create_And_Fill_Properties([Values(10)] int i, [Values("path")] string p, [Values("name")] string n, [Values("Extension")] string e)
        {
            //Arrange
            var photoOfAccommodation = new PropertyPhotoDto
            {
                PropertyId = i,
                Path = p,
                Name = n,
                Extension = e
            };

            //Act
            var accommodationId = photoOfAccommodation.PropertyId;
            var path = photoOfAccommodation.Path;
            var name = photoOfAccommodation.Name;
            var extension = photoOfAccommodation.Extension;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.IsTrue(accommodationId == i);
                Assert.IsTrue(path == p);
                Assert.IsTrue(name == n);
                Assert.IsTrue(extension == e);
            });
        }
    }
}