using AutoMapper;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Mapping.Profiles.LocalizedAccommodation
{
    public class ToAccommodationItem : Profile
    {
        public ToAccommodationItem()
        {
            CreateMap<LocalizedRealEstate, RealEstateItem>()
                .ForMember(d => d.Address, opt => opt.MapFrom(src => src.RealEstate.Address))
                .ForMember(d => d.StarRating, opt => opt.MapFrom(src => src.RealEstate.StarRating))
              ;
        }
    }
}