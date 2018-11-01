using AutoMapper;
using Olbrasoft.Travel.Data.Entity.Property;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data.Mapping
{
    public class PhotoOfAccommodationToTypeOfRoomToPhotoToRoom : Profile
    {
        public PhotoOfAccommodationToTypeOfRoomToPhotoToRoom()
        {
            CreateMap<PhotoOfAccommodationToTypeOfRoom, PhotoToRoom>()
                .ForMember(d => d.PhotoId, opt => opt.MapFrom(src => src.PhotoOfAccommodation.Id))
                .ForMember(d => d.RoomId, opt => opt.MapFrom(src => src.TypeOfRoom.Id))
                ;
        }
    }
}