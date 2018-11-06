using NUnit.Framework;
using Olbrasoft.Pagination;
using Olbrasoft.Travel.Data.Transfer.Object;
using System.Linq;

namespace Olbrasoft.Travel.Data.Unit.Tests.Transfer.Object
{
    [TestFixture]
    internal class AccommodationItemPhotoMergerTest
    {
        [Test]
        public void Instance_Implement_Interface_IAccommodationItemPhotoMerger()
        {
            //Arrange
            var type = typeof(IAccommodationItemPhotoMerge);

            //Act
            var merger = new AccommodationItemPhotoMerge();

            //Assert
            Assert.IsInstanceOf(type, merger);
        }

        [Test]
        public void Merge()
        {
            //Arrange
            var merger = Merger();
            var accommodationItems = new ResultWithTotalCount<AccommodationItem>()
            {
                Result = new[]
                {
                    new AccommodationItem
                    {
                        Id = 1
                    },
                }
            };
        

        var accommodationPhotos = new[]
            {

                new AccommodationPhoto
                {
                    AccommodationId = 1,
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

        private static AccommodationItemPhotoMerge Merger()
        {
            return new AccommodationItemPhotoMerge();
        }
    }
}