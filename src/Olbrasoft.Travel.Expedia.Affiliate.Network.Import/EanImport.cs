using System;
using System.Net;
using Castle.Core.Logging;
using Castle.DynamicProxy;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Olbrasoft.Travel.Data.Entity.Framework;
using Olbrasoft.Travel.Data.Entity.Framework.Repository.Geography;
using Olbrasoft.Travel.Data.Entity.Framework.Repository.Globalization;
using Olbrasoft.Travel.Data.Entity.Globalization;
using Olbrasoft.Travel.Data.Entity.Identity;
using Olbrasoft.Travel.Data.Repository;
using Olbrasoft.Travel.Data.Repository.Geography;
using Olbrasoft.Travel.Data.Repository.Globalization;
using Olbrasoft.Travel.Data.Repository.Property;


namespace Olbrasoft.Travel.Expedia.Affiliate.Network.Import
{
    internal class EanImport
    {
        public static ILogger Logger = new ConsoleLogger();
        //public static int UserId;

        // ReSharper disable once UnusedParameter.Local
        private static void Main(string[] args)
        {
            var user = new User
            {
                UserName = "EanImport"
            };

            var container = BuildContainer();

            WriteContent(container);

            var usersRepository = container.Resolve<IFactoryOfRepositories>().Users();
            user = usersRepository.AddIfNotExist(user);



            //Write($"Id to a user with a UserName {user.UserName} is {user.Id}.");

            //// var url = "https://www.ian.com/affiliatecenter/include/V2/ParentRegionList.zip";

            ////// DownloadFile(url, runningStatus, importsFacade, import);

            ////// todo Extract

            container.Register(Component.For<User>().Instance(user));

            var languagesRepository = container.Resolve<ILanguagesRepository>();

            var defaultLanguage = languagesRepository.Get(1033);

            if (defaultLanguage == null)
            {
                defaultLanguage = new Language
                {
                    Id = 1033,
                    EanLanguageCode = "en_US",
                    CreatorId = user.Id
                };
                languagesRepository.Add(defaultLanguage);
            }

            container.Register(
                Component.For<SharedProperties>()
                    .ImplementedBy<SharedProperties>()
                    .DependsOn(Dependency.OnValue("creatorId", user.Id), Dependency.OnValue("defaultLanguageId", defaultLanguage.Id))
            );

            using (var regionsImporter = container.Resolve<IImporter>(nameof(RegionsImporter)))
            {
                regionsImporter.Import(@"D:\Ean\ParentRegionList.txt");
            }

            //using (var countriesImporter = container.Resolve<IImporter>(nameof(CountriesImporter)))
            //{
            //    countriesImporter.Import(@"D:\Ean\CountryList.txt");
            //}

            //using (var neighborhoodsImporter = container.Resolve<IImporter>(nameof(NeighborhoodsImporter)))
            //{
            //    neighborhoodsImporter.Import(@"D:\Ean\NeighborhoodCoordinatesList.txt");
            //}

            //using (var citiesImporter = container.Resolve<IImporter>(nameof(RegionsTypesOfCitiesImporter)))
            //{
            //    citiesImporter.Import(@"D:\Ean\CityCoordinatesList.txt");
            //}

            //using (var pointsOfInterestImporter = container.Resolve<IImporter>(nameof(PointsOfInterestImporter)))
            //{
            //    pointsOfInterestImporter.Import(@"D:\Ean\PointsOfInterestCoordinatesList.txt");
            //}

            //using (var airportsImporter = container.Resolve<IImporter>(nameof(AirportsImporter)))
            //{
            //    airportsImporter.Import(@"D:\Ean\AirportCoordinatesList.txt");
            //}

            //using (var trainMetroStationsImporter = container.Resolve<IImporter>(nameof(TrainMetroStationsImporter)))
            //{
            //    trainMetroStationsImporter.Import(@"D:\Ean\TrainMetroStationCoordinatesList.txt");
            //}

            //using (var regionsCenterImporter = container.Resolve<IImporter>(nameof(RegionsCenterImporter)))
            //{
            //    regionsCenterImporter.Import(@"D:\Ean\RegionCenterCoordinatesList.txt");
            //}

            //using (var typesOfAccommodationsImporter = container.Resolve<IImporter>(nameof(TypesOfAccommodationsImporter)))
            //{
            //    typesOfAccommodationsImporter.Import(@"D:\Ean\PropertyTypeList.txt");
            //}

            //using (var accommodationsImporter = container.Resolve<IImporter>(nameof(AccommodationsImporter)))
            //{
            //    accommodationsImporter.Import(@"D:\Ean\ActivePropertyList.txt");
            //}

            //using (var descriptionsImporter = container.Resolve<IImporter>(nameof(DescriptionsImporter)))
            //{
            //    descriptionsImporter.Import(@"D:\Ean\PropertyDescriptionList.txt");
            //}

            //using (var pathsExtensionsCaptionsImporter =
            //    container.Resolve<IImporter>(nameof(PathsExtensionsCaptionsImporter)))
            //{
            //    pathsExtensionsCaptionsImporter.Import(@"D:\Ean\HotelImageList.txt");
            //}

            //using (var photosOfAccommodationsImporter =
            //    container.Resolve<IImporter>(nameof(PhotosOfAccommodationsImporter)))
            //{
            //    photosOfAccommodationsImporter.Import(@"D:\Ean\HotelImageList.txt");
            //}

            //using (var typesOfRoomsImporter = container.Resolve<IImporter>(nameof(TypesOfRoomsImporter)))
            //{
            //    typesOfRoomsImporter.Import(@"D:\Ean\RoomTypeList.txt");
            //}

            //using (var localizedTypesOfRoomsImporter =
            //    container.Resolve<IImporter>(nameof(LocalizedTypesOfRoomsImporter)))
            //{
            //    localizedTypesOfRoomsImporter.Import(@"D:\Ean\RoomTypeList.txt");
            //}

            //using (var roomsTypesImagesImporter = container.Resolve<IImporter>(nameof(RoomsTypesImagesImporter)))
            //{
            //    roomsTypesImagesImporter.Import(@"D:\Ean\RoomTypeList.txt");
            //}

            //using (var photosOfAccommodationsToTypesOfRoomsImporter = container.Resolve<IImporter>(nameof(PhotosOfAccommodationsToTypesOfRoomsImporter)))
            //{
            //    photosOfAccommodationsToTypesOfRoomsImporter.Import(@"D:\Ean\RoomTypeList.txt");
            //}

            //using (var attributesImporter = container.Resolve<IImporter>(nameof(AttributesImporter)))
            //{
            //    attributesImporter.Import(@"D:\Ean\AttributeList.txt");
            //}

            //using (var attributesImporter = container.Resolve<IImporter>(nameof(LocalizedAttributesDefaultLanguageImporter)))
            //{
            //    attributesImporter.Import(@"D:\Ean\AttributeList.txt");
            //}

            //using (var accommodationsToAttributesDefaultLanguageImporter = container.Resolve<IImporter>(nameof(AccommodationsToAttributesDefaultLanguageImporter)))
            //{
            //    accommodationsToAttributesDefaultLanguageImporter.Import(@"D:\Ean\PropertyAttributeLink.txt");
            //}

            //var language = languagesRepository.Get(1031);

            //if (language == null)
            //{
            //    language = new Language
            //    {
            //        Id = 1031,
            //        EanLanguageCode = "de_DE",
            //        CreatorId = user.Id
            //    };
            //    languagesRepository.Add(language);
            //}

            //using (var accommodationsMultiLanguageImporter = container.Resolve<IImporter>(nameof(AccommodationsMultiLanguageImporter)))
            //{
            //    accommodationsMultiLanguageImporter.Import(@"D:\Ean\ActivePropertyList_de_DE.txt");
            //}

            //language = languagesRepository.Get(1034);

            //if (language == null)
            //{
            //    language = new Language
            //    {
            //        Id = 1034,
            //        EanLanguageCode = "es_ES",
            //        CreatorId = user.Id
            //    };
            //    languagesRepository.Add(language);
            //}

            //using (var accommodationsMultiLanguageImporter = container.Resolve<IImporter>(nameof(AccommodationsMultiLanguageImporter)))
            //{
            //    accommodationsMultiLanguageImporter.Import(@"D:\Ean\ActivePropertyList_es_ES.txt");
            //}

            Write("Imported");
#if DEBUG
            Console.ReadLine();
#endif
        }

        private static async void DownloadFile(string url)
        {
            var fileName = System.IO.Path.GetFileName(url);

            using (var wc = new WebClient())
            {
                await wc.DownloadFileTaskAsync(new Uri(url), @"D:\Ean\" + fileName);
            }
        }

        private static void WriteContent(IWindsorContainer container)
        {
#if DEBUG
            foreach (var handler in container.Kernel
                .GetAssignableHandlers(typeof(object)))
            {
                Write($"{handler.ComponentModel.Services} {handler.ComponentModel.Implementation}");
            }
#endif
        }

        private static WindsorContainer BuildContainer()
        {
            var container = new WindsorContainer();

            //container.Register(Component.For<RoutingDatabaseContext>().ImplementedBy<RoutingDatabaseContext>());
            container.Register(Component.For<IdentityDatabaseContext>().ImplementedBy<IdentityDatabaseContext>());
            //container.Register(Component.For<PropertyDatabaseContext>().ImplementedBy<PropertyDatabaseContext>());
            container.Register(Component.For<GeographyDatabaseContext>().ImplementedBy<GeographyDatabaseContext>());
            container.Register(Component.For<GlobalizationDatabaseContext>().ImplementedBy<GlobalizationDatabaseContext>());

            //  container.Register(Component.For<TravelDatabaseContext>().ImplementedBy<TravelDatabaseContext>());
            // container.Register(Component.For<DbContext>().ImplementedBy<TravelDatabaseContext>().Named(nameof(TravelDatabaseContext)));

            container.Register(Classes.FromAssemblyNamed("Olbrasoft.Travel.Expedia.Affiliate.Network")
                .Where(type => type.Name.EndsWith("Parser"))
                .WithService.AllInterfaces()
            );

            container.Register(Classes.FromAssemblyNamed("Olbrasoft.Travel.Data.Entity")
                   .Where(type => type.Name.EndsWith("Repository"))
                   .WithService.AllInterfaces()
               );

#if DEBUG
            container.Register(Component.For<ILoggingImports>().ImplementedBy<ConsoleLogger>());

#else
            container.Register(Component.For<ILoggingImports>().ImplementedBy<ConsoleLogger>());

#endif
            container.Register(Component.For<IParserFactory>().ImplementedBy<ParserFactory>());

            container.Register(Component.For(typeof(IAdditionalRegionsInfoRepository<>)).ImplementedBy(typeof(AdditionalRegionsInfoRepository<>)));

            container.Register(Component.For(typeof(Travel.Data.Repository.Geography.INamesRepository<>))
                .ImplementedBy(typeof(Travel.Data.Entity.Framework.Repository.Geography.NamesRepository<>)));

            //container.Register(Component.For(typeof(Travel.Data.Repository.Property.INamesRepository<>))
            //    .ImplementedBy(typeof(Travel.Data.Entity.Framework.Repository.Property.NamesRepository<>)));

            container.Register(Component.For(typeof(Travel.Data.Repository.Geography.IManyToManyRepository<>))
                .ImplementedBy(typeof(Travel.Data.Entity.Framework.Repository.Geography.ManyToManyRepository<>)));

            //container.Register(Component.For(typeof(Travel.Data.Repository.Property.IManyToManyRepository<>))
            //    .ImplementedBy(typeof(Travel.Data.Entity.Framework.Repository.Property.ManyToManyRepository<>)));

            container.Register(Component.For(typeof(IOfLocalized<>))
                .ImplementedBy(typeof(LocalizedRepository<>)));

            //container.Register(Component.For(typeof(IMappedPropertiesRepository<>)).ImplementedBy(typeof(MappedPropertiesRepository<>)));

            container.Register(Component.For<IInterceptor>().ImplementedBy<ImportInterceptor>());

            container.Register(Component.For(typeof(IProvider)).ImplementedBy<FileImportProvider>().Named(nameof(FileImportProvider)));

            container.AddFacility<TypedFactoryFacility>();

            container.Register(Component.For<IFactoryOfRepositories>().AsFactory());

            container = RegisterImporters(container);

            return container;
        }

        private static WindsorContainer RegisterImporters(WindsorContainer container)
        {
            RegisterGeographyImporters(container);

           // RegisterAccoImporters(container);

            return container;
        }

        //private static void RegisterAccoImporters(IWindsorContainer container)
        //{
        //    container.Register(Component.For(typeof(IImporter)).ImplementedBy<TypesOfAccommodationsImporter>()
        //        .Named(nameof(TypesOfAccommodationsImporter)).Interceptors<IInterceptor>());

        //    container.Register(Component.For(typeof(IImporter)).ImplementedBy<ChainsImporter>()
        //        .Named(nameof(ChainsImporter)).Interceptors<IInterceptor>());

        //    container.Register(Component.For(typeof(IImporter)).ImplementedBy<AccommodationsImporter>()
        //        .Named(nameof(AccommodationsImporter)).Interceptors<IInterceptor>());

        //    container.Register(Component.For(typeof(IImporter)).ImplementedBy<DescriptionsImporter>()
        //        .Named(nameof(DescriptionsImporter)).Interceptors<IInterceptor>());

        //    container.Register(Component.For(typeof(IImporter)).ImplementedBy<PathsExtensionsCaptionsImporter>()
        //        .Named(nameof(PathsExtensionsCaptionsImporter)).Interceptors<IInterceptor>());

        //    container.Register(Component.For(typeof(IImporter)).ImplementedBy<PhotosOfAccommodationsImporter>()
        //        .Named(nameof(PhotosOfAccommodationsImporter)).Interceptors<IInterceptor>());

        //    container.Register(Component.For(typeof(IImporter)).ImplementedBy<TypesOfRoomsImporter>()
        //        .Named(nameof(TypesOfRoomsImporter)).Interceptors<IInterceptor>());

        //    container.Register(Component.For(typeof(IImporter)).ImplementedBy<LocalizedTypesOfRoomsImporter>()
        //        .Named(nameof(LocalizedTypesOfRoomsImporter)).Interceptors<IInterceptor>());

        //    container.Register(Component.For(typeof(IImporter)).ImplementedBy<RoomsTypesImagesImporter>()
        //        .Named(nameof(RoomsTypesImagesImporter)).Interceptors<IInterceptor>());

        //    container.Register(Component.For(typeof(IImporter))
        //        .ImplementedBy<PhotosOfAccommodationsToTypesOfRoomsImporter>()
        //        .Named(nameof(PhotosOfAccommodationsToTypesOfRoomsImporter)).Interceptors<IInterceptor>());

        //    container.Register(Component.For(typeof(IImporter)).ImplementedBy<AttributesImporter>()
        //        .Named(nameof(AttributesImporter)).Interceptors<IInterceptor>());

        //    container.Register(Component.For(typeof(IImporter))
        //        .ImplementedBy<LocalizedAttributesDefaultLanguageImporter>()
        //        .Named(nameof(LocalizedAttributesDefaultLanguageImporter)).Interceptors<IInterceptor>());

        //    container.Register(Component.For(typeof(IImporter))
        //        .ImplementedBy<AccommodationsToAttributesDefaultLanguageImporter>()
        //        .Named(nameof(AccommodationsToAttributesDefaultLanguageImporter)).Interceptors<IInterceptor>());

        //    container.Register(Component.For(typeof(IImporter))
        //        .ImplementedBy<AccommodationsMultiLanguageImporter>()
        //        .Named(nameof(AccommodationsMultiLanguageImporter)).Interceptors<IInterceptor>());
        //}

        private static void RegisterGeographyImporters(IWindsorContainer container)
        {
            container.Register(Component.For(typeof(IImporter)).ImplementedBy<RegionsImporter>().Named(nameof(RegionsImporter))
                .Interceptors<IInterceptor>());

            //container.Register(Component.For(typeof(IImporter)).ImplementedBy<PointsOfInterestImporter>()
            //    .Named(nameof(PointsOfInterestImporter)).Interceptors<IInterceptor>());

            //container.Register(Component.For(typeof(IImporter)).ImplementedBy<CountriesImporter>()
            //    .Named(nameof(CountriesImporter)).Interceptors<IInterceptor>());

            //container.Register(Component.For(typeof(IImporter)).ImplementedBy<NeighborhoodsImporter>()
            //    .Named(nameof(NeighborhoodsImporter)).Interceptors<IInterceptor>());

            //container.Register(Component.For(typeof(IImporter)).ImplementedBy<RegionsTypesOfCitiesImporter>()
            //    .Named(nameof(RegionsTypesOfCitiesImporter)).Interceptors<IInterceptor>());

            //container.Register(Component.For(typeof(IImporter)).ImplementedBy<AirportsImporter>()
            //    .Named(nameof(AirportsImporter)).Interceptors<IInterceptor>());

            //container.Register(Component.For(typeof(IImporter)).ImplementedBy<TrainMetroStationsImporter>()
            //    .Named(nameof(TrainMetroStationsImporter)).Interceptors<IInterceptor>());

            //container.Register(Component.For(typeof(IImporter)).ImplementedBy<RegionsCenterImporter>()
            //    .Named(nameof(RegionsCenterImporter)).Interceptors<IInterceptor>());
        }

        public static void Write(object s)
        {
#if DEBUG
            Logger.Log(s.ToString());
#endif
        }
    }
}