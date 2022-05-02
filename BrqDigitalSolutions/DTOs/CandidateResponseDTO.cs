using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using BrqDigitalSolutions.Models;

namespace BrqDigitalSolutions.DTOs
{
  public record CandidateSkillDTO
  {
    public int Id { get; init; }
    public string Name { get; init; } = default!;
  }

  public record CandidateCertificationDTO
  {
    public int Id { get; init; }
    public string Name { get; init; } = default!;
    public string Description { get; init; } = default!;
    public DateTime ExpeditionAt { get; set; }
    public DateTime? ExpirationAt { get; set; }
  }

  public record CandidateResponseDTO
  {
    public int Id { get; init; }
    public string Name { get; init; } = default!;
    public string Email { get; init; } = default!;
    public string Phone { get; init; } = default!;
    public string CPF { get; init; } = default!;
    public DateTime BirthAt { get; init; }
    [JsonConverter(typeof(StringEnumConverter))]
    public GenderType Gender { get; set; } = GenderType.Other;
    public IEnumerable<CandidateSkillDTO> Skills { get; init; } = default!;
    public IEnumerable<CandidateCertificationDTO> Certifications { get; init; } = default!;
  }
}
