using AutoMapper;
using Olbrasoft.Travel.Data.Base.Objects.Geography;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Mapping.Profiles
{
    public class LocalizedRegionToSuggestion : Profile
    {
        public LocalizedRegionToSuggestion()
        {
            CreateMap<RegionTranslation, Transfer.Objects.SuggestionDto>()
                .ForMember(d => d.Label, opt => opt.MapFrom(src => src.Name));
        }
    }
}