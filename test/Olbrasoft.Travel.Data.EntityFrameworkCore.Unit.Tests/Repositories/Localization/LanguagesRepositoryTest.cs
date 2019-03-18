using Moq;
using NUnit.Framework;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Repositories;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Repositories.Localization;
using Olbrasoft.Travel.Data.Localization;
using Olbrasoft.Travel.Data.Repositories.Localization;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.Repositories.Localization
{
    [TestFixture]
    internal class LanguagesRepositoryTest
    {
        [Test]
        public void Instance_Is_DboRepository_Of_Language()
        {
            //Arrange
            var type = typeof(TravelRepository<Language>);

            //Act
            var repository = CreateRepository();

            //Assert
            Assert.IsInstanceOf(type, repository);
        }

        [Test]
        public void Instance_Implement_Interface_ILanguagesRepository()
        {
            //Arrange
            var type = typeof(ILanguagesRepository);

            //Act
            var repository = CreateRepository();

            //Assert
            Assert.IsInstanceOf(type, repository);
        }

        [Test]
        public void Instance_Is_GlobalizationRepository_Of_Language()
        {
            //Arrange
            var type = typeof(TravelRepository<Language>);

            //Act
            var repository = CreateRepository();

            //Assert
            Assert.IsInstanceOf(type, repository);
        }

        //[Test]
        //public void EanLanguageCodesToIds_Result_IReadOnlyDictionary_Of_String_Integer()
        //{
        //    //Arrange
        //    var type = typeof(IReadOnlyDictionary<string, int>);
        //    var repository = CreateRepository();

        //    //Act
        //    var result = repository.EanLanguageCodesToIds;

        //    //Assert
        //    Assert.IsInstanceOf(type,result);
        //}

        private static LanguagesRepository CreateRepository()
        {
            var dboContextMock = new Mock<TravelDbContext>();
            //var dbSet = GetQueryableMockDbSet(new List<Language>()
            //{
            //    new Language()
            //    {
            //        ExpediaCode = "",
            //        Id = 0
            //    }
            //});

            //dboContextMock.Setup(p => p.Languages).Returns(dbSet);

            var repository = new LanguagesRepository(dboContextMock.Object);
            return repository;
        }

        //private static DbSet<T> GetQueryableMockDbSet<T>(List<T> sourceList) where T : class
        //{
        //    if (sourceList == null) throw new ArgumentNullException(nameof(sourceList));
        //    var queryable = sourceList.AsQueryable();

        //    var dbSet = new Mock<DbSet<T>>();
        //    dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
        //    dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
        //    dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
        //    dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
        //    dbSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>(sourceList.Add);

        //    return dbSet.Object;
        //}
    }
}