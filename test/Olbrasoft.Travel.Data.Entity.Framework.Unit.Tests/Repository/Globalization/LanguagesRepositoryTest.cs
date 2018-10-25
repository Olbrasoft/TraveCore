using Moq;
using NUnit.Framework;
using Olbrasoft.Travel.Data.Entity.Framework.Repository;
using Olbrasoft.Travel.Data.Entity.Framework.Repository.Globalization;
using Olbrasoft.Travel.Data.Entity.Globalization;
using Olbrasoft.Travel.Data.Repository.Globalization;

namespace Olbrasoft.Travel.Data.Entity.Framework.Unit.Tests.Repository.Globalization
{
    [TestFixture]
    internal class LanguagesRepositoryTest
    {
        [Test]
        public void Instance_Is_DboRepository_Of_Language()
        {
            //Arrange
            var type = typeof(BaseRepository<Language>);

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
            var type = typeof(GlobalizationRepository<Language>);

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
            var dboContextMock = new Mock<GlobalizationDatabaseContext>();
            //var dbSet = GetQueryableMockDbSet(new List<Language>()
            //{
            //    new Language()
            //    {
            //        EanLanguageCode = "",
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