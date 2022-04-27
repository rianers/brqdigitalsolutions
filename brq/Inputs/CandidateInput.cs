using System.ComponentModel.DataAnnotations;

namespace BrqDigitalSolutions.Inputs
{
    public class CandidateInput
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "CPF is required.")]
        public long CPF { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone number is required.")]
        public long Phone { get; set; }
        public string Gender { get; set; }
        [Required(ErrorMessage = "Bithdate is required.")]
        public DateTime Bithdate { get; set; }
        public SkillInput[] Skill { get; set; }
        public CertificationInput[] Certification { get; set; }
    }
}
