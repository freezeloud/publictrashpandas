using System.Text.Json.Serialization;

namespace DunmmyBackend
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DisposalLocationType
    {
        SortedWasteContainers = 1,
        CollectionYard = 2,
        Landfill = 3,
    }
}