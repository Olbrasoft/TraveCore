using NUnit.Framework;
using Olbrasoft.Travel.Data.Entity.Geography;

namespace Olbrasoft.Travel.Data.Entity.Unit.Tests.Geography
{
    [TestFixture]
    internal class ExpandingInformationAboutRegionTest
    {
        [Test]
        public void Instance_Is_OwnerCreatorIdAndCreator()
        {
            //Arrange
            var type = typeof(OwnerCreatorIdAndCreator);

            //Act
            var someExpandingInformationAboutRegion = new SomeExpandingInformationAboutRegion();

            //Assert
            Assert.IsInstanceOf(type, someExpandingInformationAboutRegion);
        }

        [Test]
        public void Instance_Implement_Interface_IAdditionalRegionInfo()
        {
            //Arrange
            var type = typeof(IAdditionalRegionInfo);

            //Act
            var someExpandingInformationAboutRegion = new SomeExpandingInformationAboutRegion();

            //Assert
            Assert.IsInstanceOf(type, someExpandingInformationAboutRegion);
        }

        [Test]
        public void Code_Get_Set()
        {
            //Arrange
            const string code = "AF";
            var someExpandingInformationAboutRegion = new SomeExpandingInformationAboutRegion()
            {
                Code = code
            };

            //Act
            var result = someExpandingInformationAboutRegion.Code;

            //Assert
            Assert.IsTrue(result == code);
        }

        [Test]
        public void Region_Get_Set()
        {
            //Arrange
            var region = new Region();
            var someExpandingInformationAboutRegion = new SomeExpandingInformationAboutRegion()
            {
                Region = region
            };

            //Act
            var result = someExpandingInformationAboutRegion.Region;

            //Assert
            Assert.AreSame(result, region);
        }
    }

    internal class SomeExpandingInformationAboutRegion : ExpandingInformationAboutRegion
    {
    }
}