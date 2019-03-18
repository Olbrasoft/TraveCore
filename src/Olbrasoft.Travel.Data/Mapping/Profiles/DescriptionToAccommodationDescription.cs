using AutoMapper;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Mapping.Profiles
{
    public class DescriptionToAccommodationDescription : Profile
    {
        public DescriptionToAccommodationDescription()
        {
            CreateMap<LocalizedDescription, AccommodationDescription>();
        }
    }
}