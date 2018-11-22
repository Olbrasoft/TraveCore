using AutoMapper;
using Olbrasoft.Travel.Data.Entity.Globalization;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data.Mapping
{
    public class LocalizedRegionToCountryItem : Profile
    {
        public LocalizedRegionToCountryItem()
        {
            CreateMap<LocalizedRegion,CountryItem>()
                .ForMember(d => d.Code, opt => opt.MapFrom(src => src.Region.AdditionalCountryProperties.Code))
               ;

        }
    }
}