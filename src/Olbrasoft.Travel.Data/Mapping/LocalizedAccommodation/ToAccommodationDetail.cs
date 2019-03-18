using AutoMapper;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Mapping.LocalizedAccommodation
{
    public class ToAccommodationDetail : Profile
    {
        public ToAccommodationDetail()
        {
            CreateMap<LocalizedRealEstate, AccommodationDetail>()
                .ForMember(d => d.Address, opt => opt.MapFrom(src => src.RealEstate.Address))
                .ForMember(d => d.StarRating, opt => opt.MapFrom(src => src.RealEstate.StarRating))
                .ForMember(d => d.Latitude, opt => opt.MapFrom(src => src.RealEstate.CenterCoordinates.Y))
                .ForMember(d => d.Longitude, opt => opt.MapFrom(src => src.RealEstate.CenterCoordinates.X))
                ;
        }
    }
}