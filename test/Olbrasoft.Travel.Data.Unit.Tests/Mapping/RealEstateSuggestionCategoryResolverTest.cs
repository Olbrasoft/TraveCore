using AutoMapper;
using NUnit.Framework;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Mapping;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Unit.Tests.Mapping
{
    public class RealEstateSuggestionCategoryResolverTest
    {
        [Test]
        public void Instance_Implement_Interface_Of_PhotoToRoom_Comma_PhotoToRoomDto_Comma_String_Comma_String()
        {
            //Arrange
            var type = typeof(IMemberValueResolver<LocalizedRealEstate, Data.Transfer.Objects.SuggestionDto, string, string>);

            //Act
            var resolver = Resolver();

            //Assert
            Assert.IsInstanceOf(type, resolver);
        }

        private static RealEstateSuggestionCategoryResolver Resolver()
        {
            var resolver = new RealEstateSuggestionCategoryResolver();
            return resolver;
        }

        [Test]
        public void Resolve_Return_AwesomeCategory()
        {
            //Arrange
            var resolver = Resolver();

            //Act
            var result = resolver.Resolve(null, null, string.Empty, string.Empty, null);

            //Assert
            Assert.AreEqual("Properties", result);
        }
    }
}