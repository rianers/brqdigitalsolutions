namespace BrqDigitalSolutions.DTOs
{
    public class CandidateDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CPF { get; set; }
        public IEnumerable<string> Skills { get; set; }
    }
}