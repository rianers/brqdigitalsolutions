using Microsoft.AspNetCore.Mvc;

using Models;
using Context;
using DTOs;
using DataProvider;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class CandidatesController : ControllerBase
{
    private readonly BaseContext _context;
    public CandidatesController(BaseContext ctx) => _context = ctx;

    [HttpGet(Name = "/")]
    public IEnumerable<Candidate> Index(/*name, email, cpf, skills, certifications*/)
    {
        //return _context.Candidates.Where(name, email, cpf, skills, certifications).ToList();
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
    public IActionResult Update(int id, [FromBody] Candidate item)
    {
        if (item == null || item.Id != id)
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
