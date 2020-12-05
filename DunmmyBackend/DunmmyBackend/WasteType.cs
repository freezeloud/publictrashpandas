using System.Text.Json.Serialization;

namespace DunmmyBackend
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
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