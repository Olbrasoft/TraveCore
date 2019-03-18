using System.Linq;
using AutoMapper;
using Olbrasoft.Travel.Data.Accommodation;
using Attribute = Olbrasoft.Travel.Data.Transfer.Objects.Attribute;

namespace Olbrasoft.Travel.Data.Mapping.Profiles
{
    public class AccommodationToAttributeToAttribute : Profile
    {
        public AccommodationToAttributeToAttribute()
        {
            CreateMap<RealEstateToAttribute, Attribute>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.AttributeId))
                .ForMember(d => d.TypId, opt => opt.MapFrom(src => src.Attribute.TypeId))
                .ForMember(d => d.SubTypeId, opt => opt.MapFrom(src => src.Attribute.SubtypeId))
                .ForMember(d => d.Text, opt => opt.MapFrom(src => src.Text))
                .ForMember(d => d.Description, opt => opt.MapFrom(src => src.Attribute.LocalizedAttributes.FirstOrDefault().Description))
                .ForMember(d => d.Ban, opt => opt.MapFrom(src => src.Attribute.Ban))
                ;
        }
    }
}