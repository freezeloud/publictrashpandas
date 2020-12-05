using System.Text.Json.Serialization;

namespace DunmmyBackend
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum WasteType
    {
        Paper = 1,
        Plastic = 2,
        Electronic = 3,
        Dangerous = 4,
        Oil = 5,
        Municipal = 6,
        Tyres = 7,
        Glass = 8,
        Textile = 9,
    }
}