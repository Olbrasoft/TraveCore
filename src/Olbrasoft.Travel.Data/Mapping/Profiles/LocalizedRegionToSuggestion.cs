﻿using AutoMapper;
using Olbrasoft.Travel.Data.Geography;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Mapping.Profiles
{
    public class LocalizedRegionToSuggestion : Profile
    {
        public LocalizedRegionToSuggestion()
        {
            CreateMap<LocalizedRegion, Transfer.Objects.SuggestionDto>()
                .ForMember(d => d.Label, opt => opt.MapFrom(src => src.Name))
                .ForMember(d => d.Category, opt => opt.MapFrom(src => src.Region.Subtype.Name))
                ;
        }
    }
}