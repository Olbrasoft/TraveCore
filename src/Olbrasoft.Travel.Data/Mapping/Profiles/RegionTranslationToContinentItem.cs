using AutoMapper;
using Olbrasoft.Travel.Data.Base.Objects.Geography;
using Olbrasoft.Travel.Data.Transfer.Objects.Geography;

namespace Olbrasoft.Travel.Data.Mapping.Profiles
{
    class RegionTranslationToContinentItem : Profile
    {
        public RegionTranslationToContinentItem()
        {
            CreateMap<RegionTranslation, ContinentItem>();
        }
    }
}
