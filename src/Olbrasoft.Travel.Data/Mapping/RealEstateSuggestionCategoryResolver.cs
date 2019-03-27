using AutoMapper;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Mapping
{
    public class RealEstateSuggestionCategoryResolver : IMemberValueResolver<LocalizedRealEstate, Transfer.Objects.SuggestionDto, string, string>
    {
        public string Resolve(LocalizedRealEstate source, Transfer.Objects.SuggestionDto destination, string sourceMember, string destMember,
            ResolutionContext context)
        {
            return "Properties";
        }
    }
}