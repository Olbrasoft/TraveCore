using NUnit.Framework;


namespace Olbrasoft.Extensions.Unit.Tests
{
    [TestFixture]
    internal class EnumExtensionsTest
    {

        [Test]
        public void GetDescription()
        {
            //Arrange
            const string description = "Description of SomeEnumItem";

            //Act
            var result = SomeEnum.SomeEnumItem.GetDescription();


            //Assert
            Assert.IsTrue(result==description);
        }
            


    }
}