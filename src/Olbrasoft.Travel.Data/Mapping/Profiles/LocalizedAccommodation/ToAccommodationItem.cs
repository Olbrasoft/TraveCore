using AutoMapper;
using Olbrasoft.Travel.Data.Base.Objects.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.Mapping.Profiles.LocalizedAccommodation
{
    public class ToAccommodationItem : Profile
    {
        public ToAccommodationItem()
        {
            CreateMap<PropertyTranslation, PropertyItem>()
                .ForMember(d => d.Address, opt => opt.MapFrom(src => src.Property.Address))
                .ForMember(d => d.StarRating, opt => opt.MapFrom(src => src.Property.StarRating))
              ;
        }
    }
}