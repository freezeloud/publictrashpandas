using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DunmmyBackend
{
    public class StreetNamesProvider : IStreetNamesProvider
    {
        private List<string> StreetNames => _streetNames ?? GetStreetNamesAsync().GetAwaiter().GetResult();
        private List<string> _streetNames;
        private int _streetNamesCount;

        async Task<List<string>> GetStreetNamesAsync()
        {
            _streetNames = (await File.ReadAllLinesAsync(@"Artifacts/ulice.csv", Encoding.Latin1)).ToList();
            _streetNamesCount = _streetNames.Count;
            return _streetNames;
        }

        public IEnumerable<string> GetRandomStreetNames()
        {
            var rand = new Random(DateTime.Now.Millisecond);
            yield return StreetNames[rand.Next(0, _streetNamesCount)];
        }
    }

    public interface IStreetNamesProvider
    {
        IEnumerable<string> GetRandomStreetNames();
    }
}
