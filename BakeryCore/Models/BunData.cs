using System.Text.Json.Serialization;

namespace BakeryCore.Models;

public record BunData 
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("type")]
    public string? Type { get; set; }
    [JsonPropertyName("expectedPrice")]
    public double ExpectedPrice { get; set; }
    [JsonPropertyName("estimatedTime")]
    public string? EstimatedTime { get; set; }
    [JsonPropertyName("price")]
    public double Price { get; set; }
}
