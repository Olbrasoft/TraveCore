using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Olbrasoft.Data.Entity.Framework.Bulk.Integration.Tests
{
    public class EfCoreBulkTestAsync
    {
        protected int EntitiesNumber => 1000;

        private static readonly Func<TestContext, int> ItemsCountQuery = EF.CompileQuery<TestContext, int>(ctx => ctx.Items.Count());
        private static readonly Func<TestContext, Item> LastItemQuery = EF.CompileQuery<TestContext, Item>(ctx => ctx.Items.LastOrDefault());
        private static readonly Func<TestContext, IEnumerable<Item>> AllItemsQuery = EF.CompileQuery<TestContext, IEnumerable<Item>>(ctx => ctx.Items.AsNoTracking());

        [Theory]
        [InlineData(true, false)]
        //[InlineData(false)] // for speed comparison with Regular EF CUD operations
        public async Task OperationsTestAsync(bool isBulkOperation, bool insertTo2Tables = false)
        {
            // Test can be run individually by commenting others and running each separately in order one after another

            //using (var context = new TestContext(ContextUtil.GetOptions()))
            //{
            //    context.Database.ExecuteSqlCommand("Delete * From Item");
            //}

            await RunInsertAsync(isBulkOperation, insertTo2Tables);
            //await RunInsertOrUpdateAsync(isBulkOperation);
            //await RunUpdateAsync(isBulkOperation);
            //await RunReadAsync(isBulkOperation);
            //await RunDeleteAsync(isBulkOperation);
        }

        private async Task RunInsertAsync(bool isBulkOperation, bool insertTo2Tables)
        {
            using (var context = new TestContext(ContextUtil.GetOptions()))
            {
                var entities = new List<Item>();
                var subEntities = new List<ItemHistory>();
                for (int i = 1; i < EntitiesNumber; i++)
                {
                    entities.Add(new Item
                    {
                        ItemId = i,
                        Name = "name " + i,
                        Description = "info " + Guid.NewGuid().ToString().Substring(0, 3),
                        Quantity = i % 10,
                        Price = i / (i % 5 + 1),
                        TimeUpdated = DateTime.Now,
                    });
                }
                if (isBulkOperation)
                {
                    if (insertTo2Tables)
                    {
                        using (var transaction = await context.Database.BeginTransactionAsync())
                        {
                            await context.BulkInsertAsync(entities, new BulkConfig { PreserveInsertOrder = true, SetOutputIdentity = true, BatchSize = 4000 });

                            foreach (var entity in entities)
                            {
                                subEntities.Add(new ItemHistory
                                {
                                    ItemHistoryId = SeqGuid.Create(),
                                    ItemId = entity.ItemId,
                                    Remark = "some more info"
                                });
                            }
                            await context.BulkInsertAsync(subEntities);

                            transaction.Commit();
                        }
                    }
                    else
                    {
                        await context.BulkInsertAsync(entities);
                    }
                }
                else
                {
                    await context.Items.AddRangeAsync(entities);
                    await context.SaveChangesAsync();
                }
            }
            using (var context = new TestContext(ContextUtil.GetOptions()))
            {
                int entitiesCount = ItemsCountQuery(context);
                Item lastEntity = LastItemQuery(context);

                Assert.Equal(EntitiesNumber - 1, entitiesCount);
                Assert.NotNull(lastEntity);
                Assert.Equal("name " + (EntitiesNumber - 1), lastEntity.Name);
            }
        }

        private async Task RunInsertOrUpdateAsync(bool isBulkOperation)
        {
            using (var context = new TestContext(ContextUtil.GetOptions()))
            {
                var entities = new List<Item>();
                var dateTimeNow = DateTime.Now;
                for (int i = 2; i <= EntitiesNumber; i += 2)
                {
                    entities.Add(new Item
                    {
                        ItemId = i,
                        Name = "name InsertOrUpdate " + i,
                        Description = "info",
                        Quantity = i,
                        Price = i / (i % 5 + 1),
                        TimeUpdated = dateTimeNow
                    });
                }
                if (isBulkOperation)
                {
                    var bulkConfig = new BulkConfig() { SetOutputIdentity = true, CalculateStats = true };
                    await context.BulkInsertOrUpdateAsync(entities, bulkConfig);
                }
                else
                {
                    await context.Items.AddRangeAsync(entities);
                    await context.SaveChangesAsync();
                }
            }
            using (var context = new TestContext(ContextUtil.GetOptions()))
            {
                int entitiesCount = ItemsCountQuery(context);
                Item lastEntity = LastItemQuery(context);

                Assert.Equal(EntitiesNumber, entitiesCount);
                Assert.NotNull(lastEntity);
                Assert.Equal("name InsertOrUpdate " + EntitiesNumber, lastEntity.Name);
            }
        }

        private async Task RunUpdateAsync(bool isBulkOperation)
        {
            using (var context = new TestContext(ContextUtil.GetOptions()))
            {
                int counter = 1;
                var entities = AllItemsQuery(context).ToList();
                foreach (var entity in entities)
                {
                    entity.Description = "Desc Update " + counter++;
                    entity.TimeUpdated = DateTime.Now;
                }
                if (isBulkOperation)
                {
                    await context.BulkUpdateAsync(entities);
                }
                else
                {
                    context.Items.UpdateRange(entities);
                    await context.SaveChangesAsync();
                }
            }
            using (var context = new TestContext(ContextUtil.GetOptions()))
            {
                int entitiesCount = ItemsCountQuery(context);
                Item lastEntity = LastItemQuery(context);

                Assert.Equal(EntitiesNumber, entitiesCount);
                Assert.NotNull(lastEntity);
                Assert.Equal("Desc Update " + EntitiesNumber, lastEntity.Description);
            }
        }

        private async Task RunReadAsync(bool isBulkOperation)
        {
            using (var context = new TestContext(ContextUtil.GetOptions()))
            {
                var entities = new List<Item>();

                for (int i = 1; i < EntitiesNumber; i++)
                {
                    var entity = new Item
                    {
                        Name = "name " + i,
                    };
                    entities.Add(entity);
                }

                await context.BulkReadAsync(
                    entities,
                    new BulkConfig
                    {
                        UseTempDB = false,
                        UpdateByProperties = new List<string> { nameof(Item.Name) }
                    }
                );

                Assert.Equal(1, entities[0].ItemId);
                Assert.Equal(0, entities[1].ItemId);
                Assert.Equal(3, entities[2].ItemId);
                Assert.Equal(0, entities[3].ItemId);
            }
        }

        private async Task RunDeleteAsync(bool isBulkOperation)
        {
            using (var context = new TestContext(ContextUtil.GetOptions()))
            {
                var entities = AllItemsQuery(context).ToList();
                // ItemHistories will also be deleted because of Relationship - ItemId (Delete Rule: Cascade)
                if (isBulkOperation)
                {
                    await context.BulkDeleteAsync(entities);
                }
                else
                {
                    context.Items.RemoveRange(entities);
                    await context.SaveChangesAsync();
                }
            }
            using (var context = new TestContext(ContextUtil.GetOptions()))
            {
                int entitiesCount = ItemsCountQuery(context);
                Item lastEntity = LastItemQuery(context);

                Assert.Equal(0, entitiesCount);
                Assert.Null(lastEntity);
            }

            using (var context = new TestContext(ContextUtil.GetOptions()))
            {
                // Resets AutoIncrement
                context.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('dbo.[" + nameof(Item) + "]', RESEED, 0);");
                //context.Database.ExecuteSqlCommand($"TRUNCATE TABLE {nameof(Item)};"); // can NOT work when there is ForeignKey - ItemHistoryId
            }
        }
    }
}
