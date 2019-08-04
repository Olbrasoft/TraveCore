using Microsoft.EntityFrameworkCore;
using Olbrasoft.Travel.Data.Queries.Accommodation;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Mapping;
using Room = Olbrasoft.Travel.Data.Base.Objects.Accommodation.Room;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers.Accommodation
{
    public class RoomsByPropertyIdAndLanguageIdQueryHandler : TravelQueryHandler<RoomsByPropertyIdAndLanguageIdQuery,  IEnumerable<Transfer.Objects.Accommodation.RoomDto>,Room>
    {
        public override async Task<IEnumerable<Transfer.Objects.Accommodation.RoomDto>> HandleAsync(RoomsByPropertyIdAndLanguageIdQuery query, CancellationToken token)
        {
            var projection = ProjectionToRooms(Entities(), query);
            return await projection.ToArrayAsync(token);
        }

        protected IQueryable<Transfer.Objects.Accommodation.RoomDto> ProjectionToRooms(IQueryable<Room> typeOfRooms, RoomsByPropertyIdAndLanguageIdQuery byPropertyIdAndLanguageIdQuery)
        {
            var localizedTypesOfRooms =typeOfRooms.SelectMany(p => p.LocalizedRooms)
                .Where(p => p.LanguageId == byPropertyIdAndLanguageIdQuery.LanguageId);

            localizedTypesOfRooms = localizedTypesOfRooms.Include(p => p.Type)
                .Where(p => p.Type.PropertyId == byPropertyIdAndLanguageIdQuery.PropertyId);

            return ProjectTo<Transfer.Objects.Accommodation.RoomDto>(localizedTypesOfRooms);
        }


        public RoomsByPropertyIdAndLanguageIdQueryHandler(IProjection projector, TravelDbContext context) : base(projector, context)
        {
        }
    }
}