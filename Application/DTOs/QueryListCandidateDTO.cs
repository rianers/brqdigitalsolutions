
namespace Application.DTOs
{
    public class QueryListCandidateDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public IEnumerable<string> Skills { get; set; }
        public IEnumerable<string> Certifications { get; set; }
    }
}