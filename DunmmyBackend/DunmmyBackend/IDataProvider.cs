using System.Collections.Generic;
using System.Threading.Tasks;

namespace DunmmyBackend
{
    public interface IDataProvider
    {
        Task<List<DisposalLocation>> GetDisposalLocationsAsync(int amount = 10);
        Task<List<DisposalLocation>> GetDisposalLocationsForAreaAsync((double latitude, double longitude) latLong, double diameterKm);
        Task<DisposalLocationDetails> GetDisposalLocationDetailsAsync(long id);
    }
}