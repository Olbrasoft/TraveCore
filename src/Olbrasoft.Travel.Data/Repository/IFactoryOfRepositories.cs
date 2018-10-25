using Olbrasoft.Travel.Data.Entity;
using Olbrasoft.Travel.Data.Repository.Geography;
using Olbrasoft.Travel.Data.Repository.Globalization;
using Olbrasoft.Travel.Data.Repository.Property;
using Olbrasoft.Travel.Data.Repository.Routing;

namespace Olbrasoft.Travel.Data.Repository
{
    public interface IFactoryOfRepositories
    {
        IOfName<T> BaseNames<T>() where T : CreationInfo<int>, IHaveName;

        IOfManyToMany<T> ManyToMany<T>() where T : ManyToMany;

        Property.IManyToManyRepository<T> PropertyManyToMany<T>() where T : ManyToMany;

        Geography.IManyToManyRepository<T> GeographyManyToMany<T>() where T : ManyToMany;

        Geography.INamesRepository<T> GeographyNamesRepository<T>() where T : class, IHaveName;

        Property.INamesRepository<T> PropertyNamesRepository<T>() where T : class, IHaveName;

        IOfLocalized<T> OfLocalized<T>() where T : Localized;

        IRegionsRepository Regions();

        IAdditionalRegionsInfoRepository<T> AdditionalRegionsInfo<T>() where T : OwnerCreatorIdAndCreator, IAdditionalRegionInfo;

        IRegionsToTypesRepository RegionsToTypes();

        IMappedPropertiesRepository<T> MappedProperties<T>() where T : CreationInfo<int>, IHaveEanId<int>;

        IDescriptionsOfAccommodationsRepository DescriptionsOfAccommodations();

        IFilesExtensionsRepository FilesExtensions();

        IPathsToPhotosRepository PathsToPhotos();

        IOfLocalizedCaptions LocalizedCaptions();

        IPhotosOfAccommodationsRepository PhotosOfAccommodations();

        IAccommodationsToAttributesRepository AccommodationsToAttributes();

        IUsersRepository Users();

        ILanguagesRepository Languages();
    }
}