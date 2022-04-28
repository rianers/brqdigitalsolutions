namespace Application.DTOs
{
  public class CandidateDTO
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string CPF { get; set; }
    public IEnumerable<string> Skills { get; set; }
  }
}