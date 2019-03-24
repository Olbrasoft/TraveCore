using AutoMapper;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Mapping
{
    public class RealEstateSuggestionCategoryResolver : IMemberValueResolver<LocalizedRealEstate, Suggestion, string, string>
    {
        public string Resolve(LocalizedRealEstate source, Suggestion destination, string sourceMember, string destMember,
            ResolutionContext context)
        {
            return "Properties";
        }
    }
}