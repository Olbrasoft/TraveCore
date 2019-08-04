using Olbrasoft.Travel.Data.Base;
using Olbrasoft.Travel.Data.Base.Objects.Localization;
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

        ITranslationsRepository<T> Localized<T>() where T : Translation;

        IRegionsRepository Regions();

        IAdditionalRegionsInfoRepository<T> AdditionalRegionsInfo<T>() where T : OwnerCreatorInfoAndCreator, IAdditionalRegionInfo;

        IMappingToProvidersRepository<T> MappedProperties<T>() where T : CreationInfo<int>, IHaveExpediaId<int>;

        IDescriptionsRepository AccommodationDescriptions();

        IFilesExtensionsRepository FilesExtensions();

        IPathsToPhotosRepository PathsToPhotos();

        ICaptionsTranslationsRepository LocalizedCaptions();

        IPhotosRepository PhotosOfAccommodations();

        IPropertiesToAttributesRepository AccommodationsToAttributes();

        IUsersRepository Users();

        ILanguagesRepository Languages();
    }
}