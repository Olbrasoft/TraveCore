using Castle.DynamicProxy;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Olbrasoft.Travel.Data.EntityFrameworkCore;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Repositories;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Repositories.Geography;
using Olbrasoft.Travel.Data.Repositories;
using Olbrasoft.Travel.Data.Repositories.Geography;
using Olbrasoft.Travel.Providers.Expedia.Import.Importers;
using System;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Repositories.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Repositories.Localization;
using Olbrasoft.Travel.Data.Identity;
using Olbrasoft.Travel.Data.Localization;
using Olbrasoft.Travel.Data.Repositories.Accommodation;
using Olbrasoft.Travel.Data.Repositories.Localization;

namespace Olbrasoft.Travel.Providers.Expedia.Import
{
    internal class Program
    {
        public static ILogger Logger = new ConsoleLogger();
        //public static int UserId;

        // ReSharper disable once UnusedParameter.Local
        private static void Main(string[] args)
        {
            var user = new User
            {
                UserName = "ExpediaConsoleImporter"
            };

            var container = BuildContainer();

            WriteContent(container);

            var usersRepository = container.Resolve<IRepositoryFactory>().Users();
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
                    ExpediaCode = "en_US",
                    CreatorId = user.Id
                };
                languagesRepository.Add(defaultLanguage);
            }

            container.Register(
                Component.For<SharedProperties>()
                    .ImplementedBy<SharedProperties>()
                    .DependsOn(Dependency.OnValue("creatorId", user.Id), Dependency.OnValue("defaultLanguageId", defaultLanguage.Id))
            );

            ImportGeography(container);

            ImportAccommodation(container);

            //var language = languagesRepository.Get(1031);

            //if (language == null)
            //{
            //    language = new Language
            //    {
            //        Id = 1031,
            //        ExpediaCode = "de_DE",
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
            //        ExpediaCode = "es_ES",
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

        private static void ImportAccommodation(IWindsorContainer container)
        {
            using (var typesOfAccommodationsImporter = container.Resolve<IImporter>(nameof(PropertyTypesImporter)))
            {
                typesOfAccommodationsImporter.Import(@"D:\Ean\PropertyTypeList.txt");
            }

            using (var accommodationsImporter = container.Resolve<IImporter>(nameof(ChainsImporter)))
            {
                accommodationsImporter.Import(@"D:\Ean\ChainList.txt");
            }

            using (var accommodationsImporter = container.Resolve<IImporter>(nameof(PropertiesImporter)))
            {
                accommodationsImporter.Import(@"D:\Ean\ActivePropertyList.txt");
            }

            using (var descriptionsImporter = container.Resolve<IImporter>(nameof(DescriptionsImporter)))
            {
                descriptionsImporter.Import(@"D:\Ean\PropertyDescriptionList.txt");
            }

            using (var pathsExtensionsCaptionsImporter =
                container.Resolve<IImporter>(nameof(PathsExtensionsCaptionsImporter)))
            {
                pathsExtensionsCaptionsImporter.Import(@"D:\Ean\HotelImageList.txt");
            }

            using (var photosOfAccommodationsImporter =
                container.Resolve<IImporter>(nameof(PhotosOfAccommodationsImporter)))
            {
                photosOfAccommodationsImporter.Import(@"D:\Ean\HotelImageList.txt");
            }

            using (var typesOfRoomsImporter = container.Resolve<IImporter>(nameof(TypesOfRoomsImporter)))
            {
                typesOfRoomsImporter.Import(@"D:\Ean\RoomTypeList.txt");
            }

            using (var localizedTypesOfRoomsImporter =
                container.Resolve<IImporter>(nameof(LocalizedTypesOfRoomsImporter)))
            {
                localizedTypesOfRoomsImporter.Import(@"D:\Ean\RoomTypeList.txt");
            }

            using (var roomsTypesImagesImporter = container.Resolve<IImporter>(nameof(RoomsTypesImagesImporter)))
            {
                roomsTypesImagesImporter.Import(@"D:\Ean\RoomTypeList.txt");
            }

            using (var photosOfAccommodationsToTypesOfRoomsImporter =
                container.Resolve<IImporter>(nameof(PhotosOfAccommodationsToTypesOfRoomsImporter)))
            {
                photosOfAccommodationsToTypesOfRoomsImporter.Import(@"D:\Ean\RoomTypeList.txt");
            }

            using (var attributesImporter = container.Resolve<IImporter>(nameof(AttributesImporter)))
            {
                attributesImporter.Import(@"D:\Ean\AttributeList.txt");
            }

            using (var attributesImporter = container.Resolve<IImporter>(nameof(LocalizedAttributesDefaultLanguageImporter)))
            {
                attributesImporter.Import(@"D:\Ean\AttributeList.txt");
            }

            using (var accommodationsToAttributesDefaultLanguageImporter =
                container.Resolve<IImporter>(nameof(AccommodationsToAttributesDefaultLanguageImporter)))
            {
                accommodationsToAttributesDefaultLanguageImporter.Import(@"D:\Ean\PropertyAttributeLink.txt");
            }
        }

        private static void ImportGeography(IWindsorContainer container)
        {
            using (var regionsImporter = container.Resolve<IImporter>(nameof(RegionsImporter)))
            {
                regionsImporter.Import(@"D:\Ean\ParentRegionList.txt");
            }

            using (var countriesImporter = container.Resolve<IImporter>(nameof(CountriesImporter)))
            {
                countriesImporter.Import(@"D:\Ean\CountryList.txt");
            }

            //todo Set null CenterCoordinates and Coordinates in Countries ProbablyMissingCountries

            using (var neighborhoodsImporter = container.Resolve<IImporter>(nameof(NeighborhoodsImporter)))
            {
                neighborhoodsImporter.Import(@"D:\Ean\NeighborhoodCoordinatesList.txt");
            }

            using (var citiesImporter = container.Resolve<IImporter>(nameof(RegionsTypesOfCitiesImporter)))
            {
                citiesImporter.Import(@"D:\Ean\CityCoordinatesList.txt");
            }

            using (var pointsOfInterestImporter = container.Resolve<IImporter>(nameof(PointsOfInterestImporter)))
            {
                pointsOfInterestImporter.Import(@"D:\Ean\PointsOfInterestCoordinatesList.txt");
            }

            using (var airportsImporter = container.Resolve<IImporter>(nameof(AirportsImporter)))
            {
                airportsImporter.Import(@"D:\Ean\AirportCoordinatesList.txt");
            }

            using (var trainMetroStationsImporter = container.Resolve<IImporter>(nameof(TrainMetroStationsImporter)))
            {
                trainMetroStationsImporter.Import(@"D:\Ean\TrainMetroStationCoordinatesList.txt");
            }

            using (var regionsCenterImporter = container.Resolve<IImporter>(nameof(RegionsCenterImporter)))
            {
                regionsCenterImporter.Import(@"D:\Ean\RegionCenterCoordinatesList.txt");
            }
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

            container.Register(Component.For<DbContext>().ImplementedBy<TravelDbContext>());

            //  container.Register(Component.For<TravelDatabaseContext>().ImplementedBy<TravelDatabaseContext>());
            // container.Register(Component.For<DbContext>().ImplementedBy<TravelDatabaseContext>().Named(nameof(TravelDatabaseContext)));

            container.Register(Classes.FromAssemblyNamed("Olbrasoft.Travel.Providers.Expedia")
                .Where(type => type.Name.EndsWith("Parser"))
                .WithService.AllInterfaces()
            );

            container.Register(Classes.FromAssemblyNamed("Olbrasoft.Travel.Data.EntityFrameworkCore")
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

            container.Register(Component.For(typeof(INamesRepository<>))
                .ImplementedBy(typeof(NamesRepository<>)));

            container.Register(Component.For(typeof(IManyToManyRepository<>))
                .ImplementedBy(typeof(ManyToManyRepository<>)));

            container.Register(Component.For(typeof(ITranslationsRepository<>))
                .ImplementedBy(typeof(LocalizedRepository<>)));

            container.Register(Component.For(typeof(IMappingToProvidersRepository<>)).ImplementedBy(typeof(MappingToProvidersRepository<>)));

            container.Register(Component.For<IInterceptor>().ImplementedBy<ImportInterceptor>());

            container.Register(Component.For(typeof(IProvider)).ImplementedBy<FileImportProvider>().Named(nameof(FileImportProvider)));

            container.AddFacility<TypedFactoryFacility>();

            container.Register(Component.For<IRepositoryFactory>().AsFactory());

            container = RegisterImporters(container);

            return container;
        }

        private static WindsorContainer RegisterImporters(WindsorContainer container)
        {
            RegisterGeographyImporters(container);

            RegisterPropertyImporters(container);

            container.Register(Component.For(typeof(IImporter)).ImplementedBy<PathsExtensionsCaptionsImporter>()
                .Named(nameof(PathsExtensionsCaptionsImporter)).Interceptors<IInterceptor>());

            return container;
        }

        private static void RegisterPropertyImporters(IWindsorContainer container)
        {
            container.Register(Component.For(typeof(IImporter)).ImplementedBy<PropertyTypesImporter>()
                .Named(nameof(PropertyTypesImporter)).Interceptors<IInterceptor>());

            container.Register(Component.For(typeof(IImporter)).ImplementedBy<ChainsImporter>()
                .Named(nameof(ChainsImporter)).Interceptors<IInterceptor>());

            container.Register(Component.For(typeof(IImporter)).ImplementedBy<PropertiesImporter>()
                .Named(nameof(PropertiesImporter)).Interceptors<IInterceptor>());

            container.Register(Component.For(typeof(IImporter)).ImplementedBy<DescriptionsImporter>()
                .Named(nameof(DescriptionsImporter)).Interceptors<IInterceptor>());

            container.Register(Component.For(typeof(IImporter)).ImplementedBy<PhotosOfAccommodationsImporter>()
                .Named(nameof(PhotosOfAccommodationsImporter)).Interceptors<IInterceptor>());

            container.Register(Component.For(typeof(IImporter)).ImplementedBy<TypesOfRoomsImporter>()
                .Named(nameof(TypesOfRoomsImporter)).Interceptors<IInterceptor>());

            container.Register(Component.For(typeof(IImporter)).ImplementedBy<LocalizedTypesOfRoomsImporter>()
                .Named(nameof(LocalizedTypesOfRoomsImporter)).Interceptors<IInterceptor>());

            container.Register(Component.For(typeof(IImporter)).ImplementedBy<RoomsTypesImagesImporter>()
                .Named(nameof(RoomsTypesImagesImporter)).Interceptors<IInterceptor>());

            container.Register(Component.For(typeof(IImporter))
                .ImplementedBy<PhotosOfAccommodationsToTypesOfRoomsImporter>()
                .Named(nameof(PhotosOfAccommodationsToTypesOfRoomsImporter)).Interceptors<IInterceptor>());

            container.Register(Component.For(typeof(IImporter)).ImplementedBy<AttributesImporter>()
                .Named(nameof(AttributesImporter)).Interceptors<IInterceptor>());

            container.Register(Component.For(typeof(IImporter))
                .ImplementedBy<LocalizedAttributesDefaultLanguageImporter>()
                .Named(nameof(LocalizedAttributesDefaultLanguageImporter)).Interceptors<IInterceptor>());

            container.Register(Component.For(typeof(IImporter))
                .ImplementedBy<AccommodationsToAttributesDefaultLanguageImporter>()
                .Named(nameof(AccommodationsToAttributesDefaultLanguageImporter)).Interceptors<IInterceptor>());

            //    container.Register(Component.For(typeof(IImporter))
            //        .ImplementedBy<AccommodationsMultiLanguageImporter>()
            //        .Named(nameof(AccommodationsMultiLanguageImporter)).Interceptors<IInterceptor>());
        }

        private static void RegisterGeographyImporters(IWindsorContainer container)
        {
            container.Register(Component.For(typeof(IImporter)).ImplementedBy<RegionsImporter>().Named(nameof(RegionsImporter))
                .Interceptors<IInterceptor>());

            container.Register(Component.For(typeof(IImporter)).ImplementedBy<CountriesImporter>()
                .Named(nameof(CountriesImporter)).Interceptors<IInterceptor>());

            container.Register(Component.For(typeof(IImporter)).ImplementedBy<NeighborhoodsImporter>()
                .Named(nameof(NeighborhoodsImporter)).Interceptors<IInterceptor>());

            container.Register(Component.For(typeof(IImporter)).ImplementedBy<RegionsTypesOfCitiesImporter>()
                .Named(nameof(RegionsTypesOfCitiesImporter)).Interceptors<IInterceptor>());

            container.Register(Component.For(typeof(IImporter)).ImplementedBy<PointsOfInterestImporter>()
                .Named(nameof(PointsOfInterestImporter)).Interceptors<IInterceptor>());

            container.Register(Component.For(typeof(IImporter)).ImplementedBy<AirportsImporter>()
                .Named(nameof(AirportsImporter)).Interceptors<IInterceptor>());

            container.Register(Component.For(typeof(IImporter)).ImplementedBy<TrainMetroStationsImporter>()
                .Named(nameof(TrainMetroStationsImporter)).Interceptors<IInterceptor>());

            container.Register(Component.For(typeof(IImporter)).ImplementedBy<RegionsCenterImporter>()
                .Named(nameof(RegionsCenterImporter)).Interceptors<IInterceptor>());
        }

        public static void Write(object s)
        {
#if DEBUG
            Logger.Log(s.ToString());
#endif
        }
    }
}