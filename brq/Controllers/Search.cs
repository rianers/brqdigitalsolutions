using Microsoft.AspNetCore.Mvc;

namespace brq.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Search : Controller
    {

        [HttpGet("id")]
        public async Task<ActionResult> GetById(string id)
        {
            return Ok();
        }

        [HttpGet("name")]
        public async Task<ActionResult> GetByName(string name)
        {
            return Ok();
        }
        [HttpGet("email")]
        public async Task<ActionResult> GetByEmail(string email)
        {
            return Ok();
        }
        [HttpGet("cpf")]
        public async Task<ActionResult> GetByCPF(string cpf)
        {
            return Ok();
        }
        [HttpGet("skill")]
        public async Task<ActionResult> GetAllBySkill(string skill)
        {
            return Ok();
        }
        [HttpGet("certification")]
        public async Task<ActionResult> GetAllByCertification()
        {
            return Ok();
        }
    }
}
