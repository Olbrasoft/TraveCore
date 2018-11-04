using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Data.Query;
using Olbrasoft.Travel.Data.Entity.Property;
using Olbrasoft.Travel.Data.Query;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data.Entity.Framework.Query.Handler
{
    public class Rooms : AsyncHandlerWithDependentSource<GetRooms, TypeOfRoom, IEnumerable<Room>>
    {
        public Rooms(IHavePropertyQueryable<TypeOfRoom> ownerQueryable, IProjection projector) : base(ownerQueryable, projector)
        {
        }

        public override async Task<IEnumerable<Room>> HandleAsync(GetRooms query, CancellationToken cancellationToken)
        {
            var projection = ProjectionToRooms(query, Source, Projector);
            return await projection.ToArrayAsync(cancellationToken);
        }

        protected IQueryable<Room> ProjectionToRooms(GetRooms query, IQueryable<TypeOfRoom> typeOfRooms, IProjection projector)
        {
            var localizedTypesOfRooms = Source.SelectMany(p => p.LocalizedTypesOfRooms)
                .Where(p => p.LanguageId == query.LanguageId);

            localizedTypesOfRooms = localizedTypesOfRooms.Include(p => p.TypeOfRoom)
                .Where(p => p.TypeOfRoom.AccommodationId == query.AccommodationId);

            return projector.ProjectTo<Room>(localizedTypesOfRooms);
        }
    }
}