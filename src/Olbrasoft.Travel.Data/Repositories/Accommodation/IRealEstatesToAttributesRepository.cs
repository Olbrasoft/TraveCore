using System.Collections.Generic;
using Olbrasoft.Travel.Data.Accommodation;

namespace Olbrasoft.Travel.Data.Repositories.Accommodation
{
    public interface IRealEstatesToAttributesRepository : SharpRepository.Repository.ICompoundKeyRepository<RealEstateToAttribute, int, int, int>
    {
        void BulkSave(IEnumerable<RealEstateToAttribute> accommodationsToAttributes);
    }
}