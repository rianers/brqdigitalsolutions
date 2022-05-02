using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrqDigitalSolutions.Models
{
    [Table("candidate_skills")]
    public class CandidateSkill : Timestamp
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("candidate_id")]
        public int CandidateId { get; set; } = default!;

        public Candidate Candidate { get; set; } = default!;

        [Column("skill_id")]
        public int SkillId { get; set; } = default!;

        public Skill Skill { get; set; } = default!;
    }
}
