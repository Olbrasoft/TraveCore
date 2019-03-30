using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Travel.Data.Queries.Accommodation;
using Room = Olbrasoft.Travel.Data.Accommodation.Room;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers.Accommodation
{
    public class RoomsByAccommodationIdAndLanguageIdQueryHandler : TravelQueryHandler< RoomsByPropertyIdAndLanguageIdQuery, Room, IEnumerable<Transfer.Objects.Accommodation.RoomDto>>
    {
    
        public override async Task<IEnumerable<Transfer.Objects.Accommodation.RoomDto>> HandleAsync(RoomsByPropertyIdAndLanguageIdQuery query, CancellationToken cancellationToken)
        {
            var projection = ProjectionToRooms(Source,query);
            return await projection.ToArrayAsync(cancellationToken);
        }

        protected IQueryable<Transfer.Objects.Accommodation.RoomDto> ProjectionToRooms(IQueryable<Room> typeOfRooms,RoomsByPropertyIdAndLanguageIdQuery byPropertyIdAndLanguageIdQuery)
        {
            var localizedTypesOfRooms = Source.SelectMany(p => p.LocalizedRooms)
                .Where(p => p.LanguageId == byPropertyIdAndLanguageIdQuery.LanguageId);

            localizedTypesOfRooms = localizedTypesOfRooms.Include(p => p.Type)
                .Where(p => p.Type.PropertyId == byPropertyIdAndLanguageIdQuery.PropertyId);

            return ProjectTo<Transfer.Objects.Accommodation.RoomDto>(localizedTypesOfRooms);
        }

        public RoomsByAccommodationIdAndLanguageIdQueryHandler(TravelDbContext context, IProjection projector) : base(context, projector)
        {
        }
    }
}