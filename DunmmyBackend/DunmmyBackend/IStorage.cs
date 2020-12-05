using System.Collections.Generic;

namespace DunmmyBackend
{
    public interface IStorage
    {
        void Store(IEnumerable<DisposalLocationDetails> locations);

        IEnumerable<DisposalLocationDetails> GetAllLocations();

        DisposalLocationDetails GetLocationById(long id);
    }
}