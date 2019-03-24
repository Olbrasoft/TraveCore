using AutoMapper;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Mapping.Profiles
{
    public class PhotoToRoomToPhotoToRoomDto : Profile
    {
        public PhotoToRoomToPhotoToRoomDto()
        {
            CreateMap<PhotoToRoom, PhotoToRoomDto>()
                .ForMember(d => d.PhotoId, opt => opt.MapFrom(src => src.Photo.Id))
                .ForMember(d => d.RoomId, opt => opt.MapFrom(src => src.Room.Id))
                ;
        }
    }
}