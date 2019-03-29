using AutoMapper;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.Mapping.Profiles
{
    public class LocalizedTypesOfRoomsToRooms : Profile
    {

        public LocalizedTypesOfRoomsToRooms()
        {
            CreateMap<RoomTranslation, RoomDto>();
        }
    }
}