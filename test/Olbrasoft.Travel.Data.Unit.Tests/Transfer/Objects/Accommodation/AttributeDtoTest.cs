using NUnit.Framework;
using Olbrasoft.Travel.Data.Base;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Transfer.Objects.Accommodation
{
    [TestFixture]
    internal class AttributeDtoTest
    {
        [Test]
        public void Create_And_Fill_Properties()
        {
            //Arrange
            var attribute = new AttributeDto
            {
                TypId = int.MinValue,
                SubTypeId = int.MaxValue,
                Description = string.Empty,
                Text = string.Empty,
                Ban=true
            };

            //Act
            var typId = attribute.TypId;
            var subTypeId = attribute.SubTypeId;
            var description = attribute.Description;
            var text = attribute.Text;
            var ban = attribute.Ban;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.IsTrue(typId == int.MinValue);
                Assert.IsTrue(int.MaxValue == subTypeId);
                Assert.IsTrue(description == string.Empty);
                Assert.IsTrue(text == string.Empty);
                Assert.IsTrue(ban);
            });
        }

        [Test]
        public void Instance_Implement_Interface_IHaveId()
        {
            //Arrange
            var type = typeof(IHaveId<int>);

            //Act
            var attribute = new AttributeDto();

            //Assert
            Assert.IsInstanceOf(type,attribute);
        }



    }
}