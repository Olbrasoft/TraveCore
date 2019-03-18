using AutoMapper;
using Olbrasoft.Travel.Data.Accommodation;
using Room = Olbrasoft.Travel.Data.Transfer.Objects.Room;

namespace Olbrasoft.Travel.Data.Mapping.Profiles
{
    public class LocalizedTypesOfRoomsToRooms : Profile
    {

        public LocalizedTypesOfRoomsToRooms()
        {
            CreateMap<LocalizedRoom, Room>();
        }
    }
}