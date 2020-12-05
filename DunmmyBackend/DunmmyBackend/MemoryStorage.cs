using System.Collections.Generic;
using System.Linq;

namespace DunmmyBackend
{
    internal class MemoryStorage : IStorage
    {
        private IEnumerable<DisposalLocationDetails> _locations;

        public void Store(IEnumerable<DisposalLocationDetails> locations)
        {
            _locations ??= locations;
        }

        public IEnumerable<DisposalLocationDetails> GetAllLocations()
        {
            return _locations;
        }

        public DisposalLocationDetails GetLocationById(long id)
        {
            return _locations.Single(x => x.Id == id);
        }
    }
}