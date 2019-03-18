using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.EntityTypesConfigurations.SomeNamespace;
using System;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.EntityTypesConfigurations
{
    public class SomeTravelTypeConfiguration : TravelTypeConfiguration<SomeEntityObject>
    {
        public SomeTravelTypeConfiguration()
        {
        }

        public SomeTravelTypeConfiguration(string schema, string table) : base(schema, table)
        {
        }

        public string SchemaName => Schema;
        public string TableName => Table;

        public override void Configuration(EntityTypeBuilder<SomeEntityObject> builder)
        {
            throw new NotImplementedException();
        }
    }
}