using Olbrasoft.Data.Queries;

namespace Olbrasoft.Data.Unit.Tests
{
    public interface IAnotherQuery : IQuery
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}