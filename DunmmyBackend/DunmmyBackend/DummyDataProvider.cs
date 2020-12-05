using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DunmmyBackend
{
    public class DummyDataProvider : IDataProvider
    {
        private readonly IStreetNamesProvider _streets;
        private readonly IStorage _storage;

        public DummyDataProvider(IStreetNamesProvider streets, IStorage storage)
        {
            _streets = streets;
            _storage = storage;
            var locations = GenerateDisposalLocationDetails(10);
            _storage.Store(locations);
        }

        public Task<List<DisposalLocation>> GetDisposalLocationsAsync(int amount = 10)
        {
            return Task.FromResult(_storage.GetAllLocations().Cast<DisposalLocation>().ToList());
        }

        private IEnumerable<DisposalLocationDetails> GenerateDisposalLocationDetails(int amount)
        {
            var rand = new Random(DateTime.Now.Millisecond);
            for (var i = 0; i < amount; i++)
            {
                yield return new DisposalLocationDetails
                {
                    Id = 100 + i,
                    Name = $"{_streets.GetRandomStreetNames(rand)} {rand.Next(1, 1200)}",
                    AcceptingTypeOfWaste = RandomAcceptingTypesOfWaste(rand),
                    LatLng = new LatitudeLongitude(RandomLat(rand), RandomLong(rand)),
                    TypeOfDisposalLocation = DisposalLocationType.SortedWasteContainers,
                };
            }
        }

        public Task<List<DisposalLocation>> GetDisposalLocationsForAreaAsync((double latitude, double longitude) latLong, double diameterKm)
        {
            throw new NotImplementedException();
        }

        public Task<DisposalLocationDetails> GetDisposalLocationDetailsAsync(long id)
        {
            return Task.FromResult(_storage.GetLocationById(id));
        }

        private static double RandomLong(Random rand)
        {
            return 17.0 + rand.Next(6351772, 7166306) / (float)10000000;
        }

        private static double RandomLat(Random rand)
        {
            return 49.0 + rand.Next(2184089, 2430142) / (float)10000000;
        }

        private static IEnumerable<WasteType> RandomAcceptingTypesOfWaste(Random rand)
        {
            var wasteTypeValues = Enum.GetValues<WasteType>();
            return wasteTypeValues.Where(type => rand.Next(0, 2) == 0).ToList();
        }
    }
}
