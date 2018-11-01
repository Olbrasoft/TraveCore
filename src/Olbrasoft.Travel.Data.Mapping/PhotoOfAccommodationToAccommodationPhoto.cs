using AutoMapper;
using Olbrasoft.Travel.Data.Entity.Property;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data.Mapping
{
    public class PhotoOfAccommodationToAccommodationPhoto : Profile
    {
        public PhotoOfAccommodationToAccommodationPhoto()
        {
            CreateMap<PhotoOfAccommodation, AccommodationPhoto>()
                .ForMember(d => d.AccommodationId, opt => opt.MapFrom(src => src.AccommodationId))
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.FileName))
                .ForMember(d => d.Path, opt => opt.MapFrom(src => src.PathToPhoto.Path))
                .ForMember(d => d.Extension, opt => opt.MapFrom(src => src.FileExtension.Extension))
                ;
        }
    }
}