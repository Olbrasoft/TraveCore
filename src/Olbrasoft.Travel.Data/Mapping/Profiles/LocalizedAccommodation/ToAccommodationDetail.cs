﻿using AutoMapper;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.Mapping.Profiles.LocalizedAccommodation
{
    public class ToAccommodationDetail : Profile
    {
        public ToAccommodationDetail()
        {
            CreateMap<LocalizedRealEstate, PropertyDetail>()
                .ForMember(d => d.Address, opt => opt.MapFrom(src => src.RealEstate.Address))
                .ForMember(d => d.StarRating, opt => opt.MapFrom(src => src.RealEstate.StarRating))
                .ForMember(d => d.Latitude, opt => opt.MapFrom(src => src.RealEstate.CenterCoordinates.Y))
                .ForMember(d => d.Longitude, opt => opt.MapFrom(src => src.RealEstate.CenterCoordinates.X))
                ;
        }
    }
}