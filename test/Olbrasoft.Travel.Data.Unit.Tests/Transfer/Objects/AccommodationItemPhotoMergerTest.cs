using System.Linq;
using NUnit.Framework;
using Olbrasoft.Pagination;
using Olbrasoft.Travel.Data.Transfer;
using Olbrasoft.Travel.Data.Transfer.Objects;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Transfer.Objects
{
    [TestFixture]
    internal class AccommodationItemPhotoMergerTest
    {
        [Test]
        public void Instance_Implement_Interface_IAccommodationItemPhotoMerger()
        {
            //Arrange
            var type = typeof(IPropertyItemPhotoMerge);

            //Act
            var merger = new PropertyItemPhotoMerge();

            //Assert
            Assert.IsInstanceOf(type, merger);
        }

        [Test]
        public void Merge()
        {
            //Arrange
            var merger = Merger();
            var accommodationItems = new ResultWithTotalCount<PropertyItem>()
            {
                Result = new[]
                {
                    new PropertyItem
                    {
                        Id = 1
                    },
                }
            };
        

        var accommodationPhotos = new[]
            {

                new PropertyPhotoDto
                {
                    PropertyId = 1,
                    Path = "Path",
                    Name = "Name",
                    Extension = "Extension"
                },
            };

            //Act
            var merge = merger.Merge(accommodationItems, accommodationPhotos);
            var result = merge.Result.FirstOrDefault()?.Photo;

            //Assert
            Assert.IsTrue(result != null && result == "https://i.travelapi.com/hotels/Path/Name_l.Extension");
        }

        private static PropertyItemPhotoMerge Merger()
        {
            return new PropertyItemPhotoMerge();
        }
    }
}