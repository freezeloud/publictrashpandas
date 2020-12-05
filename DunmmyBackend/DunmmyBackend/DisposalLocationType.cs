using System.Text.Json.Serialization;

namespace DunmmyBackend
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DisposalLocationType
    {
        SortedWasteContainers,
        CollectionYard,
        Landfill,
    }
}