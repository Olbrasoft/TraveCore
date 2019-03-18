using Olbrasoft.Travel.Data.Base;
using Olbrasoft.Travel.Data.Localization;
using Olbrasoft.Travel.Data.Repositories;
using Olbrasoft.Travel.Data.Repositories.Accommodation;
using Olbrasoft.Travel.Data.Repositories.Geography;
using Olbrasoft.Travel.Data.Repositories.Localization;
using Olbrasoft.Travel.Data.Repositories.Routing;

namespace Olbrasoft.Travel.Providers.Expedia.Import
{
    public interface IRepositoryFactory
    {
        INamesRepository<T> Names<T>() where T : CreationInfo<int>, IHaveName;

        IManyToManyRepository<T> ManyToMany<T>() where T : ManyToMany;

        IRegionSubtypesRepository TypesOfRegions();

        ILocalizedRepository<T> Localized<T>() where T : Localized;

        IRegionsRepository Regions();

        IAdditionalRegionsInfoRepository<T> AdditionalRegionsInfo<T>() where T : OwnerCreatorIdAndCreator, IAdditionalRegionInfo;

        IMappingToProvidersRepository<T> MappedProperties<T>() where T : CreationInfo<int>, IHaveExpediaId<int>;

        IDescriptionsRepository AccommodationDescriptions();

        IFilesExtensionsRepository FilesExtensions();

        IPathsToPhotosRepository PathsToPhotos();

        ILocalizedCaptionsRepository LocalizedCaptions();

        IPhotosRepository PhotosOfAccommodations();

        IRealEstatesToAttributesRepository AccommodationsToAttributes();

        IUsersRepository Users();

        ILanguagesRepository Languages();
    }
}