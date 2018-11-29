using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Travel.Data.Entity.Property;
using Olbrasoft.Travel.Data.Query;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data.Entity.Framework.Query.Handler
{
    public class RoomsByAccommodationIdAndLanguageIdQueryHandler : TravelQueryHandler<IPropertyContext, RoomsByAccommodationIdAndLanguageIdQuery, IQueryable<TypeOfRoom>, IEnumerable<Room>>
    {
        public RoomsByAccommodationIdAndLanguageIdQueryHandler(IPropertyContext context, IProjection projector) : base(context, projector)
        {
        }

        protected override IQueryable<TypeOfRoom> GetSource()
        {
            return Context.TypesOfRooms;
        }

        public override async Task<IEnumerable<Room>> HandleAsync(RoomsByAccommodationIdAndLanguageIdQuery query, CancellationToken cancellationToken)
        {
            var projection = ProjectionToRooms(Source,query);
            return await projection.ToArrayAsync(cancellationToken);
        }

        protected IQueryable<Room> ProjectionToRooms(IQueryable<TypeOfRoom> typeOfRooms,RoomsByAccommodationIdAndLanguageIdQuery byAccommodationIdAndLanguageIdQuery)
        {
            var localizedTypesOfRooms = Source.SelectMany(p => p.LocalizedTypesOfRooms)
                .Where(p => p.LanguageId == byAccommodationIdAndLanguageIdQuery.LanguageId);

            localizedTypesOfRooms = localizedTypesOfRooms.Include(p => p.TypeOfRoom)
                .Where(p => p.TypeOfRoom.AccommodationId == byAccommodationIdAndLanguageIdQuery.AccommodationId);

            return ProjectTo<Room>(localizedTypesOfRooms);
        }
    }
}