using AutoMapper;
using Olbrasoft.Travel.Data.Base.Objects.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.Mapping.Profiles
{
    public class DescriptionToAccommodationDescription : Profile
    {
        public DescriptionToAccommodationDescription()
        {
            CreateMap<DescriptionTranslation, DescriptionDto>();
        }
    }
}