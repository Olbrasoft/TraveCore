using AutoMapper;
using System.Linq;
using Attribute = Olbrasoft.Travel.Data.Transfer.Object.Attribute;
using Olbrasoft.Travel.Data.Entity.Globalization;

namespace Olbrasoft.Travel.Data.Mapping
{
    public class AccommodationToAttributeToAttribute : Profile
    {
        public AccommodationToAttributeToAttribute()
        {
            CreateMap<AccommodationToAttribute, Attribute>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.AttributeId))
                .ForMember(d => d.TypId, opt => opt.MapFrom(src => src.Attribute.TypeOfAttributeId))
                .ForMember(d => d.SubTypeId, opt => opt.MapFrom(src => src.Attribute.SubTypeOfAttributeId))
                .ForMember(d => d.Text, opt => opt.MapFrom(src => src.Text))
                .ForMember(d => d.Description, opt => opt.MapFrom(src => src.Attribute.LocalizedAttributes.FirstOrDefault().Description))
                .ForMember(d => d.Ban, opt => opt.MapFrom(src => src.Attribute.Ban))
                ;
        }
    }
}