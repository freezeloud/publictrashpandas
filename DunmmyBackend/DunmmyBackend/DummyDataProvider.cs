using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DunmmyBackend
{
    public class DummyDataProvider : IDataProvider
    {
        private readonly IStreetNamesProvider _streets;

        public DummyDataProvider(IStreetNamesProvider streets)
        {
            _streets = streets;
        }

        public Task<List<DisposalLocation>> GetDisposalLocationsAsync(int amount = 10)
        {
            var disposalLocations = new List<DisposalLocation>
            {
                new DisposalLocation
                {
                    Id = 1,
                    Name = "Mostní 958",
                    AcceptingTypeOfWaste = new List<WasteType>
                    {
                        WasteType.Paper,
                        WasteType.Plastic
                    },
                    LatLng = new LatitudeLongitude(49.2190744, 17.6554547),
                    TypeOfDisposalLocation = DisposalLocationType.SortedWasteContainers,
                }
            };

            disposalLocations.AddRange(GenerateDisposalLocations(amount - 1));
            return Task.FromResult(disposalLocations);
        }

        private IEnumerable<DisposalLocation> GenerateDisposalLocations(int amount)
        {
            var rand = new Random(DateTime.Now.Millisecond);
            for (var i = 0; i < amount; i++)
            {
                yield return new DisposalLocation
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
