using System.Collections.Generic;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Geography;
using Olbrasoft.Travel.Data.Repositories;
using Olbrasoft.Travel.Data.Repositories.Accommodation;
using Olbrasoft.Travel.Providers.Expedia.DataTransfer.Objects.Property;
using Chain = Olbrasoft.Travel.Data.Accommodation.Chain;


namespace Olbrasoft.Travel.Providers.Expedia.Import.Importers
{
    /// <summary>
    /// todo https://www.currency-iso.org/dam/downloads/lists/list_one.xml
    /// </summary>
    internal class RealEstatesImporter : Importer<ActiveProperty>
    {
        private IReadOnlyDictionary<int, int> _typesOfAccommodationsExpediaIdsToIds;
        private IReadOnlyDictionary<int, int> _chainsExpediaIdsToIds;
        private IReadOnlyDictionary<string, int> _countriesCodesToIds;
        private IReadOnlyDictionary<string, int> _airportsCodesToIds;

        protected IReadOnlyDictionary<int, int> TypesOfAccommodationsExpediaIdsToIds
        {
            get => _typesOfAccommodationsExpediaIdsToIds ?? (_typesOfAccommodationsExpediaIdsToIds =
                       RepositoryFactory.MappedProperties<RealEstateType>().ExpediaIdsToIds);

            set => _typesOfAccommodationsExpediaIdsToIds = value;
        }

        protected IReadOnlyDictionary<int, int> ChainsExpediaIdsToIds
        {
            get => _chainsExpediaIdsToIds ??
                   (_chainsExpediaIdsToIds = RepositoryFactory.MappedProperties<Chain>().ExpediaIdsToIds);

            set => _chainsExpediaIdsToIds = value;
        }

        protected IReadOnlyDictionary<string, int> CountriesCodesToIds
        {
            get => _countriesCodesToIds ??
                   (_countriesCodesToIds = RepositoryFactory.AdditionalRegionsInfo<Country>().CodesToIds);

            set => _countriesCodesToIds = value;
        }

        protected IReadOnlyDictionary<string, int> AirportsCodesToIds
        {
            get => _airportsCodesToIds ??
                   (_airportsCodesToIds = RepositoryFactory.AdditionalRegionsInfo<Airport>().CodesToIds);

            set => _airportsCodesToIds = value;
        }

        public RealEstatesImporter(IProvider provider, IParserFactory parserFactory,
            IRepositoryFactory repositoryFactory, SharedProperties sharedProperties, ILoggingImports logger)
            : base(provider, parserFactory, repositoryFactory, sharedProperties, logger)
        {
        }

        public override void Import(string path)
        {
            LoadData(path);

            var accommodationsExpediaIdsToIds = ImportAccommodations(ExpediaDataTransferObjects,
                RepositoryFactory.MappedProperties<RealEstate>(), TypesOfAccommodationsExpediaIdsToIds,
                CountriesCodesToIds, AirportsCodesToIds, ChainsExpediaIdsToIds, CreatorId);

            TypesOfAccommodationsExpediaIdsToIds = null;
            CountriesCodesToIds = null;
            AirportsCodesToIds = null;
            ChainsExpediaIdsToIds = null;

            ImportLocalizedAccommodations(ExpediaDataTransferObjects, RepositoryFactory.Localized<LocalizedRealEstate>(),
                accommodationsExpediaIdsToIds, DefaultLanguageId, CreatorId);

            ExpediaDataTransferObjects = null;
        }

        private IReadOnlyDictionary<int, int> ImportAccommodations(
            IEnumerable<ActiveProperty> activeProperties,
            IMappingToProvidersRepository<RealEstate> repository,
            IReadOnlyDictionary<int, int> typesOfAccommodationsExpediaIdsToIds,
            IReadOnlyDictionary<string, int> countriesCodesToIds,
            IReadOnlyDictionary<string, int> airportsCodesToIds,
            IReadOnlyDictionary<int, int> chainsExpediaIdsToIds,
            int creatorId
        )
        {
            //todo Jedno ubytovani pravdepodobne neni validni vraci to builded 79 999 misto 80 000
            LogBuild<RealEstate>();
            var accommodations = BuildAccommodations(
                activeProperties,
                typesOfAccommodationsExpediaIdsToIds,
                countriesCodesToIds,
                airportsCodesToIds,
                chainsExpediaIdsToIds,
                creatorId
            );
            var count = accommodations.Length;
            LogAssembled(count);

            if (count <= 0) return repository.ExpediaIdsToIds;

            LogSave<RealEstate>();
            repository.BulkSave(accommodations);
            LogSaved<RealEstate>();

            return repository.ExpediaIdsToIds;
        }

        private RealEstate[] BuildAccommodations(
            IEnumerable<ActiveProperty> activeProperties,
            IReadOnlyDictionary<int, int> typesOfAccommodationsExpediaIdsToIds,
            IReadOnlyDictionary<string, int> countriesCodesToIds,
            IReadOnlyDictionary<string, int> airportsCodesToIds,
            IReadOnlyDictionary<int, int> chainsExpediaIdsToIds,
            int creatorId
        )
        {
            var accommodations = new Queue<RealEstate>();

            foreach (var activeProperty in activeProperties)
            {
                if (typesOfAccommodationsExpediaIdsToIds.TryGetValue(activeProperty.PropertyCategory,
                        out var typeOfAccommodationId) &&
                    countriesCodesToIds.TryGetValue(activeProperty.Country, out var countryId))
                {
                    var accommodation = new RealEstate
                    {
                        StarRating = activeProperty.StarRating,
                        SequenceNumber = activeProperty.SequenceNumber,
                        ExpediaId = activeProperty.EANHotelID,
                        Address = activeProperty.Address1,
                        AdditionalAddress = activeProperty.Address2,
                        CountryId = countryId,
                        TypeId = typeOfAccommodationId,
                        CenterCoordinates = CreatePoint(activeProperty.Latitude, activeProperty.Longitude),
                        CreatorId = creatorId
                    };

                    accommodation.CenterCoordinates.SRID = 4326;

                    if (!string.IsNullOrEmpty(activeProperty.ChainCodeID) &&
                        chainsExpediaIdsToIds.TryGetValue(int.Parse(activeProperty.ChainCodeID), out var chainId))
                    {
                        accommodation.ChainId = chainId;
                    }

                    if (!string.IsNullOrEmpty(activeProperty.AirportCode) &&
                        airportsCodesToIds.TryGetValue(activeProperty.AirportCode, out var airportId))
                    {
                        accommodation.AirportId = airportId;
                    }

                    if (string.IsNullOrEmpty(accommodation.Address) &&
                        !string.IsNullOrEmpty(accommodation.AdditionalAddress))
                    {
                        accommodation.Address = accommodation.AdditionalAddress;
                        accommodation.AdditionalAddress = null;
                    }

                    if (string.IsNullOrEmpty(accommodation.Address))
                    {
                        accommodation.Address = "not entered";
                    }

                    accommodations.Enqueue(accommodation);
                }
                else
                {
                    Logger.Log(activeProperty.EANHotelID + "Neprošlo type" +
                               activeProperty.PropertyCategory + " country " + activeProperty.Country);
                }
            }

            return accommodations.ToArray();
        }
    }
}