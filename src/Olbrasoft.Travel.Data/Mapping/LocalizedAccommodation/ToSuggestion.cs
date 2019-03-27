using AutoMapper;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Mapping.LocalizedAccommodation
{
    public class ToSuggestion : Profile
    {
        public ToSuggestion()
        {
            CreateMap<LocalizedRealEstate, Transfer.Objects.SuggestionDto>()
                .ForMember(d => d.Label, opt => opt.MapFrom(src => src.Name))
                .ForMember(d => d.Category, opt => opt.MapFrom(src => "Properties"))
                ;
        }
    }
}