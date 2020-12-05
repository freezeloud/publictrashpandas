using System.Collections.Generic;

namespace DunmmyBackend
{
    public class DisposalLocation
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<WasteType> AcceptingTypeOfWaste { get; set; }
        public DisposalLocationType TypeOfDisposalLocation { get; set; }
        public LatitudeLongitude LatLng { get; set; }
    }
}