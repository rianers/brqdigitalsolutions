using System.Text.Json.Serialization;

namespace BrqDigitalSolutions.DTOs
{
  public record CertificationDTO
  {
    [JsonPropertyName("name")]
    public string Name { get; set; } = default!;

    [JsonPropertyName("description")]
    public string Description { get; set; } = default!;

    [JsonPropertyName("expedition_at")]
    public DateTime ExpeditionAt { get; set; } = default!;

    [JsonPropertyName("expiration_at")]
    public DateTime? ExpirationAt { get; set; }
  }
}
