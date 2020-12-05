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
                var randomLat = RandomLat(rand);

                yield return new DisposalLocation
                {
                    Id = 100 + i,
                    Name = $"{streetsEnumerator.Current} {rand.Next(1, 1200)}",
                    AcceptingTypeOfWaste = RandomAcceptingTypesOfWaste(rand),
                    LatLng = new LatitudeLongitude(49.0 + RandomLat(rand), 17.0 + RandomLong(rand)),
                    TypeOfDisposalLocation = DisposalLocationType.SortedWasteContainers,
                };
            }
        }

        private static double RandomLong(Random rand)
        {
            return (rand.Next(6351772, 7166306) / (float) 10000000);
        }

        private static double RandomLat(Random rand)
        {
            return rand.Next(2184089, 2430142) / (float)10000000;
        }

        private static List<WasteType> RandomAcceptingTypesOfWaste(Random rand) {
            var numberOfTypes = rand.Next(1, 3);
            var acceptingTypeOfWaste = new List<WasteType>();
            for (var i = 0; i < numberOfTypes; ++i) {
                var wasteTypeValues = Enum.GetValues<WasteType>();
                WasteType wasteType = (WasteType) wasteTypeValues[rand.Next(0, wasteTypeValues.Length - 1)];
                acceptingTypeOfWaste.Add(wasteType);
            }
            return acceptingTypeOfWaste;
        }

        public Task<List<DisposalLocation>> GetDisposalLocationsForAreaAsync((double latitude, double longitude) latLong, double diameterKm)
        {
            throw new NotImplementedException();
        }
    }

    public interface IDataProvider
    {
        Task<List<DisposalLocation>> GetDisposalLocationsAsync(int amount = 10);
        Task<List<DisposalLocation>> GetDisposalLocationsForAreaAsync((double latitude, double longitude) latLong, double diameterKm);
    }

    public class DisposalLocation
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<WasteType> AcceptingTypeOfWaste { get; set; }
        public DisposalLocationType TypeOfDisposalLocation { get; set; }
        public LatitudeLongitude LatLng { get; set; }
    }

    public class LatitudeLongitude
    {
        public LatitudeLongitude(double lat, double lng)
        {
            Lat = lat;
            Lng = lng;
        }

        public double Lat { get; set; }
        public double Lng { get; set; }
    }

    public enum DisposalLocationType
    {
        SortedWasteContainers,
        CollectionYard,
        Landfill,
    }

    public enum WasteType
    {
        Paper,
        Plastic,
        Electronic,
        Dangerous,
        Oil,
        Municipal,
        Tyres,
        Glass,
        Textile
    }
}
