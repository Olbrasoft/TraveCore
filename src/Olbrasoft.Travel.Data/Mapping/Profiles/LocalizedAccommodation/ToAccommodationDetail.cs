using AutoMapper;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.Mapping.Profiles.LocalizedAccommodation
{
    public class ToAccommodationDetail : Profile
    {
        public ToAccommodationDetail()
        {
            CreateMap<PropertyTranslation, PropertyDetail>()
                .ForMember(d => d.Address, opt => opt.MapFrom(src => src.Property.Address))
                .ForMember(d => d.StarRating, opt => opt.MapFrom(src => src.Property.StarRating))
                .ForMember(d => d.Latitude, opt => opt.MapFrom(src => src.Property.CenterCoordinates.Y))
                .ForMember(d => d.Longitude, opt => opt.MapFrom(src => src.Property.CenterCoordinates.X))
                ;
        }
    }
}