namespace Application.DTOs
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
  }

  public record CandidateListResponseDTO
  {
    public int Id { get; init; }
    public string Name { get; init; } = default!;
    public string Email { get; init; } = default!;
    public string Phone { get; init; } = default!;
    public string CPF { get; init; } = default!;
    public IEnumerable<CandidateSkillDTO> Skills { get; init; } = default!;
    public IEnumerable<CandidateCertificationDTO> Certifications { get; init; } = default!;
  }
}