using System.Data.Common;
using System.Threading.Tasks;

namespace Olbrasoft.Data.Entity.Framework.Bulk.Integration.Tests
{
    public static class DbDataReaderExtensions
    {
        public static T Field<T>(this DbDataReader reader, string columnName)
        {
            var columnIndex = reader.GetOrdinal(columnName);
            return reader.GetFieldValue<T>(columnIndex);
        }

        public static async Task<T> FieldAsync<T>(this DbDataReader reader, string columnName)
        {
            var columnIndex = reader.GetOrdinal(columnName);
            return await reader.GetFieldValueAsync<T>(columnIndex);
        }
    }
}
