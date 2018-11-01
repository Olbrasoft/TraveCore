using AutoMapper;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data.Mapping.LocalizedAccommodation
{
    public class ToAccommodationItem : Profile
    {
        public ToAccommodationItem()
        {
            CreateMap<Entity.Globalization.LocalizedAccommodation, AccommodationItem>()
                .ForMember(d => d.Address, opt => opt.MapFrom(src => src.Accommodation.Address))
                .ForMember(d => d.StarRating, opt => opt.MapFrom(src => src.Accommodation.StarRating))
              ;
        }
    }
}