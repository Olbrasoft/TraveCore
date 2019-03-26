using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Olbrasoft.Travel.Data.Unit.Tests")]

namespace Olbrasoft.Travel.Data
{
    internal interface ICanHaveSuggestionType
    {
        int? SuggestionTypeId { get; }
        SuggestionType SuggestionType { get; }
    }
}