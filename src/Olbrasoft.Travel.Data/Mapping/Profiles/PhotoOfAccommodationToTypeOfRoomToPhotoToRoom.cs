using AutoMapper;
using PhotoToRoom = Olbrasoft.Travel.Data.Accommodation.PhotoToRoom;

namespace Olbrasoft.Travel.Data.Mapping.Profiles
{
    public class PhotoOfAccommodationToTypeOfRoomToPhotoToRoom : Profile
    {
        public PhotoOfAccommodationToTypeOfRoomToPhotoToRoom()
        {
            CreateMap<PhotoToRoom, Transfer.Objects.PhotoToRoom>()
                .ForMember(d => d.PhotoId, opt => opt.MapFrom(src => src.Photo.Id))
                .ForMember(d => d.RoomId, opt => opt.MapFrom(src => src.Room.Id))
                ;
        }
    }
}