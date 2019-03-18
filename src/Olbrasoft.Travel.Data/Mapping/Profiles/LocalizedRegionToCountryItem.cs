using AutoMapper;
using Olbrasoft.Travel.Data.Geography;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Mapping.Profiles
{
    public class LocalizedRegionToCountryItem : Profile
    {
        public LocalizedRegionToCountryItem()
        {
            CreateMap<LocalizedRegion,CountryItem>()
                .ForMember(d => d.Code, opt => opt.MapFrom(src => src.Region.ExpandingInformationAboutCountry.Code))
               ;

        }
    }
}