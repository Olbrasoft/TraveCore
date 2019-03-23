using NUnit.Framework;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Unit.Tests.Transfer.Objects
{
    [TestFixture]
    internal class AccommodationPhotoTest
    {
        [Test]
        public void Create_And_Fill_Properties([Values(10)] int i, [Values("path")] string p, [Values("name")] string n, [Values("Extension")] string e)
        {
            //Arrange
            var photoOfAccommodation = new RealEstatePhoto
            {
                RealEstateId = i,
                Path = p,
                Name = n,
                Extension = e
            };

            //Act
            var accommodationId = photoOfAccommodation.RealEstateId;
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