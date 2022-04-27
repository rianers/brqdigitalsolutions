using BrqDigitalSolutions.Inputs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace brq.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Candidate : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CandidateInput candidate)
        {
            return Ok();
        }
    }
}
