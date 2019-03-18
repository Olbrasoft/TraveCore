using AutoMapper;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Mapping.Profiles
{
    public class PhotoOfAccommodationToRoomPhoto : Profile
    {
        public PhotoOfAccommodationToRoomPhoto()
        {
            CreateMap<Photo, RoomPhoto>()
                .ForMember(d => d.PhotosToRooms, opt => opt.MapFrom(src => src.ToTypesOfRooms))
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.FileName))
                .ForMember(d => d.Path, opt => opt.MapFrom(src => src.PathToPhoto.Path))
                .ForMember(d => d.Extension, opt => opt.MapFrom(src => src.FileExtension.Extension))
                ;
        }
    }
}