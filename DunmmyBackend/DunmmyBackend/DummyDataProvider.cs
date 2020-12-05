using System;
using System.Collections.Generic;
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
            using var streetsEnumerator = _streets.GetRandomStreetNames().GetEnumerator();
            var rand = new Random(DateTime.Now.Millisecond);
            for (var i = 0; i < amount; i++)
            {
                streetsEnumerator.MoveNext();
                yield return new DisposalLocation
                {
                    Id = 100 + i,
                    Name = $"{streetsEnumerator.Current} {rand.Next(1, 1200)}",
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
            return 17.0 + rand.Next(6351772, 7166306) / (float) 10000000;
        }

        private static double RandomLat(Random rand)
        {
            return 49.0 + rand.Next(2184089, 2430142) / (float)10000000;
        }

        private static IEnumerable<WasteType> RandomAcceptingTypesOfWaste(Random rand) {
            var numberOfTypes = rand.Next(1, 3);
            var acceptingTypeOfWaste = new List<WasteType>();
            for (var i = 0; i < numberOfTypes; ++i) {
                var wasteTypeValues = Enum.GetValues<WasteType>();
                var wasteType = wasteTypeValues[rand.Next(0, wasteTypeValues.Length - 1)];
                acceptingTypeOfWaste.Add(wasteType);
            }
            return acceptingTypeOfWaste;
        }
    }
}
