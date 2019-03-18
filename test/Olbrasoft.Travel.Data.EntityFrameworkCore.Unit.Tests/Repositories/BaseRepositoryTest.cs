using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Repositories;
using Olbrasoft.Travel.Data.Repositories;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.Repositories
{
    [TestFixture]
    public class BaseRepositoryTest
    {
        [Test]
        public void Instance_Is_BaseRepository_Of_SomeEntityWithTwoKeys_Comma_Integer_Comma_Integer()
        {
            //Arrange
            var type = typeof(TravelRepository<SomeEntityWithTwoKeys, int, int>);

            //Act
            var repository = TwoKeysRepository();

            //Assert
            Assert.IsInstanceOf(type, repository);
        }

        [Test]
        public void Instance_Implement_Interface_IBaseRepository_Of_SomeEntityWithTwoKeys_Integer_Comma_Integer()
        {
            //Arrange
            var type = typeof(ITravelRepository<SomeEntityWithTwoKeys, int, int>);

            //Act
            var repository = TwoKeysRepository();

            //Assert
            Assert.IsInstanceOf(type, repository);
        }

        private static SomeTwoKeysRepository TwoKeysRepository()
        {
            var contextMock = new Mock<DbContext>();

            var repository = new SomeTwoKeysRepository(contextMock.Object);
            return repository;
        }

        [Test]
        public void Instance_Is_EfCoreRepository_Of_SomeEntityWithTwoKeys_Comma_Integer_Comma_Integer()
        {
            //Arrange
            var type = typeof(SharpRepository.EfCoreRepository.EfCoreRepository<SomeEntityWithTwoKeys, int, int>);

            //Act
            var repository = TwoKeysRepository();

            //Assert
            Assert.IsInstanceOf(type, repository);
        }

        [Test]
        public void Instance_Is_BaseRepository_Of_SomeEntity()
        {
            //Arrange
            var type = typeof(TravelRepository<SomeEntity>);

            //Act
            var repository = Repository();

            //Assert
            Assert.IsInstanceOf(type, repository);
        }

        private static SomeRepository Repository()
        {
            var options = new DbContextOptionsBuilder<SomeContext>().UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            var context = new SomeContext(options);
            var repository = new SomeRepository(context);

            return repository;
        }

        [Test]
        public void Add()
        {
            //Arrange
            var entity = new SomeEntity();
            var repository = Repository();

            //Act
            repository.Add(entity);

            //Assert
            Assert.IsTrue(repository.Exists());
        }

        [Test]
        public void Find()
        {
            //Arrange
            var entities = new[]
            {
                new SomeEntity {Id = 11},
                new SomeEntity {Id = 12}
            };
            var repository = Repository();
            repository.Add(entities);

            //Act
            var entity = repository.Find(p => p.Id == 12);

            //Assert
            Assert.IsNotNull(entity);
        }
    }

    internal class SomeContext : DbContext
    {
        public DbSet<SomeEntity> SomeEntities { get; set; }

        public SomeContext(DbContextOptions options)
            : base(options)
        {
        }
    }

    internal class SomeRepository : TravelRepository<SomeEntity>
    {
        public SomeRepository(DbContext context) : base(context)
        {
        }
    }

    public class SomeEntity
    {
        public int Id { get; set; }
    }

    /// <summary>
    /// some entity with two keys
    /// </summary>
    public class SomeEntityWithTwoKeys
    {
    }

    public class SomeTwoKeysRepository : TravelRepository<SomeEntityWithTwoKeys, int, int>
    {
        public SomeTwoKeysRepository(DbContext context) : base(context)
        {
        }

        public override void BulkSave(IEnumerable<SomeEntityWithTwoKeys> entities, params Expression<Func<SomeEntityWithTwoKeys, object>>[] ignorePropertiesWhenUpdating)
        {
            throw new NotImplementedException();
        }

        public override void ClearCache()
        {
            throw new NotImplementedException();
        }
    }
}