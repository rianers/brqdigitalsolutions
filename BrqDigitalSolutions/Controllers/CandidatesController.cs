using BrqDigitalSolutions.DBContext;
using BrqDigitalSolutions.DTOs;
using BrqDigitalSolutions.Models;
using Microsoft.AspNetCore.Mvc;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class CandidatesController : ControllerBase
{
  private readonly BaseContext _context;
  public CandidatesController(BaseContext ctx) => _context = ctx;

  [HttpGet]
  public IEnumerable<CandidateResponseDTO> Index([FromQuery] QueryListCandidateDTO query)
  {
    var candidates = _context.Candidates.AsQueryable();

    if (query.Name is not null)
      candidates = candidates.Where(c => c.Name.ToLower().Contains(query.Name.ToLower()));

    if (query.Email is not null)
      candidates = candidates.Where(c => c.Email.ToLower().Contains(query.Email.ToLower()));

    if (query.CPF is not null)
      candidates = candidates.Where(c => c.CPF.Contains(query.CPF));

    if (query.Skills is not null)
      candidates = candidates.Where(c => c.Skills.Where(s => query.Skills.Contains(s.Skill.Name)).Count() > 0);

    if (query.Certifications is not null)
      candidates = candidates.Where(c => c.Certifications.Any(s => query.Certifications.Contains(s.Name)));

    return candidates.ToList().Select(c => new CandidateResponseDTO
    {
      Id = c.Id,
      Name = c.Name,
      Email = c.Email,
      Phone = c.Phone,
      CPF = c.CPF,
      BirthAt = c.BirthAt,
      Gender = c.Gender,
      Skills = c.Skills.Select(s => new CandidateSkillDTO { Id = s.Skill.Id, Name = s.Skill.Name }),
      Certifications = c.Certifications.Select(s => new CandidateCertificationDTO { Id = s.Id, Name = s.Name })
    });
  }

  [HttpPost]
  public ActionResult<CandidateResponseDTO> Create([FromBody] CandidateDTO body)
  {
    if (body == null)
    {
      return BadRequest();
    }
    var candidate = new Candidate
    {
      Name = body.Name,
      Email = body.Email,
      Phone = body.Phone,
      CPF = body.CPF,
      BirthAt = body.BirthAt,
      Gender = body.Gender
    };

    var skills = this.SkillsToObject(body.Skills);

    candidate.Skills = this.ToCandidateSkills(candidate, skills);

    foreach (var certification in body.Certifications)
    {
      candidate.Certifications.Add(new Certification
      {
        Name = certification.Name,
        Description = certification.Description,
        ExpeditionAt = certification.ExpeditionAt,
        ExpirationAt = certification.ExpirationAt
      });
    }

    _context.Candidates.Add(candidate);
    _context.SaveChanges();

    return Ok(new CandidateResponseDTO
    {
      Id = candidate.Id,
      Name = candidate.Name,
      Email = candidate.Email,
      Phone = candidate.Phone,
      CPF = candidate.CPF,
      BirthAt = candidate.BirthAt,
      Skills = candidate.Skills.Select(s => new CandidateSkillDTO { Id = s.Skill.Id, Name = s.Skill.Name }),
      Certifications = candidate.Certifications.Select(s => new CandidateCertificationDTO { Id = s.Id, Name = s.Name, Description = s.Description, ExpeditionAt = s.ExpeditionAt, ExpirationAt = s.ExpirationAt })
    });
  }

  [HttpGet("{id}")]
  public ActionResult<CandidateResponseDTO> Show(int id)
  {
    var candidate = _context.Candidates.Find(id);
    if (candidate == null)
    {
      return NotFound();
    }

    return Ok(new CandidateResponseDTO
    {
      Id = candidate.Id,
      Name = candidate.Name,
      Email = candidate.Email,
      Phone = candidate.Phone,
      CPF = candidate.CPF,
      BirthAt = candidate.BirthAt,
      Skills = candidate.Skills.Select(s => new CandidateSkillDTO { Id = s.Skill.Id, Name = s.Skill.Name }),
      Certifications = candidate.Certifications.Select(s => new CandidateCertificationDTO { Id = s.Id, Name = s.Name, Description = s.Description, ExpeditionAt = s.ExpeditionAt, ExpirationAt = s.ExpirationAt })
    });
  }

  [HttpPut("{id}")]
  public ActionResult<CandidateResponseDTO> Update(int id, [FromBody] CandidateDTO body)
  {
    if (body == null)
    {
      return BadRequest();
    }
    var candidate = _context.Candidates.Find(id);
    if (candidate == null)
    {
      return NotFound();
    }
    candidate.Name = body.Name;
    candidate.Email = body.Email;
    candidate.Phone = body.Phone;
    candidate.CPF = body.CPF;
    candidate.BirthAt = body.BirthAt;
    candidate.Gender = body.Gender;

    foreach (var cSkill in candidate.Skills)
    {
      _context.CandidateSkills.Remove(cSkill);
    }

    foreach (var cert in candidate.Certifications)
    {
      _context.Certifications.Remove(cert);
    }

    var skills = this.SkillsToObject(body.Skills);

    candidate.Skills = this.ToCandidateSkills(candidate, skills);

    foreach (var certification in body.Certifications)
    {
      candidate.Certifications.Add(new Certification
      {
        Name = certification.Name,
        Description = certification.Description,
        ExpeditionAt = certification.ExpeditionAt,
        ExpirationAt = certification.ExpirationAt
      });
    }

    _context.Candidates.Update(candidate);
    _context.SaveChanges();

    return Ok(new CandidateResponseDTO
    {
      Id = candidate.Id,
      Name = candidate.Name,
      Email = candidate.Email,
      Phone = candidate.Phone,
      CPF = candidate.CPF,
      BirthAt = candidate.BirthAt,
      Skills = candidate.Skills.Select(s => new CandidateSkillDTO { Id = s.Skill.Id, Name = s.Skill.Name }),
      Certifications = candidate.Certifications.Select(s => new CandidateCertificationDTO { Id = s.Id, Name = s.Name, Description = s.Description, ExpeditionAt = s.ExpeditionAt, ExpirationAt = s.ExpirationAt })
    });
  }

  private ICollection<Skill> SkillsToObject(ICollection<string> skills)
  {
    var skillsList = new List<Skill>();
    foreach (var skill in skills)
    {
      var item = _context.Skills.FirstOrDefault(s => s.Name.ToLower() == skill.ToLower());
      if (item == null)
      {
        item = new Skill { Name = skill };
        _context.Skills.Add(item);
      }
      skillsList.Add(item);
    }

    _context.SaveChanges();

    return skillsList;
  }

  private ICollection<CandidateSkill> ToCandidateSkills(Candidate candidate, ICollection<Skill> skills)
  {
    var skillsList = new List<CandidateSkill>();
    foreach (var skill in skills)
    {
      var item = _context.CandidateSkills.FirstOrDefault(s => s.CandidateId == candidate.Id && s.SkillId == skill.Id);
      if (item == null)
      {
        item = new CandidateSkill { CandidateId = candidate.Id, SkillId = skill.Id };
        _context.CandidateSkills.Add(item);
      }
      skillsList.Add(item);
    }

    return skillsList;
  }
}
