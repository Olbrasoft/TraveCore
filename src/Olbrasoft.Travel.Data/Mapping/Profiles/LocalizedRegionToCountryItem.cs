using AutoMapper;
using Olbrasoft.Travel.Data.Geography;
using Olbrasoft.Travel.Data.Transfer.Objects;
using Olbrasoft.Travel.Data.Transfer.Objects.Geography;

namespace Olbrasoft.Travel.Data.Mapping.Profiles
{
    public class LocalizedRegionToCountryItem : Profile
    {
        public LocalizedRegionToCountryItem()
        {
            CreateMap<RegionTranslation,CountryItemDto>()
                .ForMember(d => d.Code, opt => opt.MapFrom(src => src.Region.ExpandingInformationAboutCountry.Code))
               ;

        }
    }
}