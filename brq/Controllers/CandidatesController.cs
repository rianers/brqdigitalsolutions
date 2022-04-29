using Microsoft.AspNetCore.Mvc;

using Models;
using DataProvider;
using Application.DTOs;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class CandidatesController : ControllerBase
{
    private readonly BaseContext _context;
    public CandidatesController(BaseContext ctx) => _context = ctx;

    [HttpGet(Name = "/")]
    public IEnumerable<Candidate> Index([FromQuery] QueryListCandidateDTO query)
    {
        var candidates = _context.Candidates.AsQueryable();

        if (query.Name != null)
        {
            candidates = candidates.Where(c => c.Name.Contains(query.Name));
        }

        if (query.Email != null)
        {
            candidates = candidates.Where(c => c.Email.Contains(query.Email));
        }

        if (query.CPF != null)
        {
            candidates = candidates.Where(c => c.CPF.Contains(query.CPF));
        }

        if (query.Skills != null)
        {
            candidates = candidates.Where(c => c.Skills.Where(s => query.Skills.Contains(s.Skill.Name)).Count() > 0);
        }

        if (query.Certifications != null)
        {
            candidates = candidates.Where(c => c.Certifications.Any(s => query.Certifications.Contains(s.Name)));
        }

        return candidates.ToList();
    }

    [HttpPost(Name = "/")]
    public IActionResult Create([FromBody] CandidateDTO item)
    {
        if (item == null)
        {
            return BadRequest();
        }
        var candidate = new Candidate
        {
            Name = item.Name,
            Email = item.Email,
            Phone = item.Phone,
            CPF = item.CPF,
        };

        // var skills = _context.Skills.Where(s => item.Skills.Contains(s.Name)).ToList().AsEnumerable();

        // candidate.Skills = skills;

        _context.Candidates.Add(candidate);
        _context.SaveChanges();
        return Ok(candidate);
    }

    [HttpGet("{id}", Name = "/{id}")]
    public IActionResult Show(int id)
    {
        var item = _context.Candidates.Find(id);
        if (item == null)
        {
            return NotFound();
        }

        return Ok(item);
    }  
    

    [HttpPut("{id}", Name = "/{id}")]
    public IActionResult Update(int id, [FromBody] CandidateDTO item)
    {
        if (item == null)
        {
            return BadRequest();
        }
        var candidate = _context.Candidates.Find(id);
        if (candidate == null)
        {
            return NotFound();
        }
        candidate.Name = item.Name;
        candidate.Email = item.Email;
        candidate.Phone = item.Phone;

        _context.Candidates.Update(candidate);
        _context.SaveChanges();
        return Ok(candidate);
    }
}
