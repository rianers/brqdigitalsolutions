using Application.Handler;
using BrqDigitalSolutions.Inputs;
using Microsoft.AspNetCore.Mvc;

namespace BrqDigitalSolutions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Skill : Controller
    {
        [HttpPost("{candidateId}")]
        public async Task<ActionResult> Post([FromBody] SkillInput skillInput, string candidateId, [FromServices] SkillHandler skillHandler)
        {
            try
            {
                await skillHandler.Insert(skillInput.Skill, candidateId);
                return RedirectToAction(nameof(Get), new { id = candidateId });
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, [FromBody] SkillInput skillInput, [FromServices] SkillHandler skillHandler)
        {
            try
            {
                await skillHandler.Update(id, skillInput.Skill);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("{candidateId}")]
        public async Task<ActionResult> Get(string candidateId, [FromServices] SkillHandler skillHandler)
        {
            try
            {
                List<Libraries.Skill> skill = await skillHandler.GetAll(candidateId);
                return Ok(skillHandler);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id, [FromServices] SkillHandler skillHandler)
        {
            try
            {
                await skillHandler.Delete(id);
                return Ok($"The skill from id {id} was deleted sucessful.");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
