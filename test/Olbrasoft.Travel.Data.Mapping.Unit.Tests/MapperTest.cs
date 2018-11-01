using AutoMapper;
using NUnit.Framework;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Data.Mapping.AutoMapper;

namespace Olbrasoft.Travel.Data.Mapping.Unit.Tests
{
    [TestFixture]
    internal class MapperTest
    {
        [Test]
        public void Instance_Implement_Interface_IMap()
        {
            //Arrange
            var type = typeof(IProjection);
            IConfigurationProvider provider = new MapperConfiguration(cfg => cfg.AddProfile<PhotoOfAccommodationToAccommodationPhoto>());
            //Act

            var mapper = new Projector(provider);

            //Assert
            Assert.IsInstanceOf(type, mapper);
        }

        //[Test]
        //public void Map([Values(10)] int i, [Values("path")] string p, [Values("name")] string n,
        //    [Values("Extension")] string e)
        //{
        //    //Arrange

        //    var photos = new[]
        //    {
        //        new PhotoOfAccommodation
        //        {
        //            AccommodationId = i,
        //            PathToPhoto = new PathToPhoto { Path = p},
        //            FileName = n,
        //            FileExtension = new FileExtension {Extension = e}
        //        }
        //    };

        //    IConfigurationProvider provider = new MapperConfiguration(cfg => cfg.AddProfile<PhotoOfAccommodationToAccommodationPhoto>());
        //    var mapper = new Projector(provider);

        //    //Act
        //    var result = mapper.ProjectTo<IEnumerable<AccommodationPhoto>>(photos.AsQueryable());

        //    //Assert
        //    Assert.IsInstanceOf<IEnumerable<AccommodationPhoto>>(result);
        //}
    }
}