using System.Runtime.CompilerServices;
using Olbrasoft.Travel.Data.Suggestion;

[assembly: InternalsVisibleTo("Olbrasoft.Travel.Data.Unit.Tests")]

namespace Olbrasoft.Travel.Data
{
    internal interface IHaveSuggestionCategory
    {
        SuggestionCategory SuggestionCategory { get; }
    }
}