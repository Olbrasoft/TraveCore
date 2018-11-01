using AutoMapper;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data.Mapping.LocalizedAccommodation
{
    public class ToAccommodationDetail : Profile
    {
        public ToAccommodationDetail()
        {
            CreateMap<Entity.Globalization.LocalizedAccommodation, AccommodationDetail>()
                .ForMember(d => d.Address, opt => opt.MapFrom(src => src.Accommodation.Address))
                .ForMember(d => d.StarRating, opt => opt.MapFrom(src => src.Accommodation.StarRating))
                .ForMember(d => d.Latitude, opt => opt.MapFrom(src => src.Accommodation.CenterCoordinates.X))
                .ForMember(d => d.Longitude, opt => opt.MapFrom(src => src.Accommodation.CenterCoordinates.Y))
                ;
        }
    }
}