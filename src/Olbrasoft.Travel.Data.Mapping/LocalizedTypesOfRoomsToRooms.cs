using AutoMapper;
using Olbrasoft.Travel.Data.Entity.Globalization;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data.Mapping
{
    public class LocalizedTypesOfRoomsToRooms : Profile
    {

        public LocalizedTypesOfRoomsToRooms()
        {
            CreateMap<LocalizedTypeOfRoom, Room>();
        }
    }
}