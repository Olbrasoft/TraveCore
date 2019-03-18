using AutoMapper;
using Olbrasoft.Travel.Data.Geography;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Mapping.Profiles
{
    public class LocalizedRegionToSuggestion : Profile
    {
        public LocalizedRegionToSuggestion()
        {
            CreateMap<LocalizedRegion, Suggestion>()
                .ForMember(d => d.Label, opt => opt.MapFrom(src => src.Name))
                ;
        }
    }
}